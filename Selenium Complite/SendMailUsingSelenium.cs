using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Mail;
using System.Net;
using OpenQA.Selenium;

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
//using NUnit.Framework; //[Test] attribute used then nuit need 
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Selenium_Complite
{
    [TestClass]
    public class Mailing
    {
        [TestMethod]
        public void SendEmail()
        {
            try
            {
                //sender's email,sender's password ,To/receiver email,subject ,body,cc, attachment
                MailMessage mail = new MailMessage();
                string FromEmail = "UrGmailName@gmail.com";
                string Password = "1234567890";
                string ToEmail = "Ur2ndGmailName@gmail.com";
                string Subject = "subject -: redarding test case of selenium complite project";
                string ContentBody = "<h3>content body here ...selenium complite project....</h3>";
                mail.From = new MailAddress(FromEmail);
                mail.To.Add(ToEmail);
                mail.Subject = Subject;
                mail.Body = ContentBody;
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment(@"C:\Users\Prashant Pimpalkar\source\repos\Selenium Complite\Selenium Complite\ExtentReport/index.html"));
                SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
                //if u r using outlook then use below line insted of above line 
                // SmtpClient smtp = new SmtpClient("smtp.live.com", 587);
                smtp.EnableSsl = true;
                smtp.Timeout = 10000;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(FromEmail, Password);
               
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
                throw;
            }
            finally
            {
                Console.WriteLine("inside finally exicute");
            }
        }


        [TestMethod]
        public void TriggerEmail()
        {
            try
            {
                Assert.AreEqual(1, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(2000);
                SendAnEmailNow(ex.Message.Trim(), ex.StackTrace);
                //throw;
            }
            finally
            {
               
            }
        }

       
        public void SendAnEmailNow(string Subject, string ContentBody)
        {
            //sender's email,sender's password ,To/receiver email,subject ,body,cc, attachment
            MailMessage mail = new MailMessage();
            string FromEmail = "UrGmailName@gmail.com";
            string Password = "1234567890";
            string ToEmail = "Ur2ndGmailName@gmail.com";
            //string Subject = "subject -: redarding test case of selenium complite project";
            //string ContentBody = "<h3>content body here ...selenium complite project....</h3>";
            mail.From = new MailAddress(FromEmail);
            mail.To.Add(ToEmail);
            mail.Subject = Subject;
            mail.Body = ContentBody;
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment(@"C:\Users\Prashant Pimpalkar\source\repos\Selenium Complite\Selenium Complite\ExtentReport/index.html"));
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //if u r using outlook then use below line insted of above line 
            // SmtpClient smtp = new SmtpClient("smtp.live.com", 587);
            smtp.EnableSsl = true;
            smtp.Timeout = 10000;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(FromEmail, Password);
            smtp.Send(mail);
        }

      
        

       
        



    }
}
