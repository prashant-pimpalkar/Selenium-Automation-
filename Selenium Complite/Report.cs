using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework; //[Test] attribute used then nuit need 
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Selenium_Complite
{
    class Report
    {

        IWebDriver driver = new FirefoxDriver();  //run the borwser
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void ExtentReportInitialize()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Prashant Pimpalkar\source\repos\Selenium Complite\Selenium Complite\ExtentReport\pp.html");

            //string machineName = null;
            string hostName = Dns.GetHostName();
            
            OperatingSystem oSVersions = Environment.OSVersion;
                         
            extent.AttachReporter(htmlReporter);
           // extent.AddSystemInfo("Operating System : ", "windos 10");
            extent.AddSystemInfo("Operating System : ", oSVersions.ToString());

            // extent.AddSystemInfo("Host Name : ", "Prashant PC ");
            extent.AddSystemInfo("Host Name : ", hostName);

            extent.AddSystemInfo("Browse : ", "Google Chrom and Firefox");
            extent.AddSystemInfo("Host By : ", "Prashant ");
            extent.AddSystemInfo("Project Name : ", "Selenium Complite ");
           
        }

       
        [Test]//run the test case ----make method as a calleable 
        public void ExtentReporGeneratedTestMethod()
        {
            ExtentTest Test = null;
            Test = extent.CreateTest("ExtentReporGeneratedTestMethod").Info("...Test Start...");

            try
            {
                  Test.Log(Status.Info, "Firefox open");

                //Initialization  of browser every time so put it as a separate
                driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Form");
                Test.Log(Status.Info, "uitestpractice Students Form open");

                //EnterText(driver,element,value,elementtype)
                CustomSetMethod.EnterText(driver, "firstname", "prashant", "Id");
                Test.Log(Status.Info, "firstname entered");

                CustomSetMethod.SelectDropDown(driver, "sel1", "India", "Id");
                Test.Log(Status.Info, "DropDown value entered");

                Console.WriteLine("the value of firstname is-" + CustomGetMethod.GetText(driver, "firstname", "Id"));
                Console.WriteLine("the value of drop down is-" + CustomGetMethod.GetText(driver, "sel1", "Id"));

                CustomSetMethod.Click(driver, "btn", "ClassName");
                Test.Log(Status.Info, "btn  clicked");
               
                driver.Close();
                Test.Log(Status.Info, "...test  passed...");
                Test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath("Screenshot.png").Build());
                Test.Pass("Screenshot").AddScreenCaptureFromPath("Screenshot.png");
            }
            catch (Exception ex)
            {
                Test.Log(Status.Fail, ex.ToString());
                throw;
            }
            finally
            {
                if (driver !=null)
                {
                    driver.Quit();
                }

            }
           

        }

        
        [OneTimeTearDown]
        public void ExtentReportCleanUp()
        {
            //close the browser evry time so make it as seprate
            //  driver.Close();
            extent.Flush();
        }
    }
}
