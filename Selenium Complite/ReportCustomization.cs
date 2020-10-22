using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
//using NUnit.Framework; //[Test] attribute used then nuit need 
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Mail;
using System.Threading;

namespace Selenium_Complite
{
    [TestClass]
   public class ReportCustomization
    {
        IWebDriver driver = new FirefoxDriver();  //run the borwser
        static ExtentHtmlReporter extentHtmlReporter = new ExtentHtmlReporter(@"C:\Users\Prashant Pimpalkar\source\repos\Selenium Complite\Selenium Complite\ExtentReport\pp.html");
        static ExtentReports extentReports = new ExtentReports();

        [TestInitialize]
        public void SetUP()
        {
            extentReports.AttachReporter(extentHtmlReporter);
        }

        public static string ScreenshotCaptureMethod(IWebDriver driver, string ScreenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string uptobinpath = path.Substring(0, path.LastIndexOf("bin")) + "ExtentReportScreenshots\\" + ScreenshotName + ".png";
            string localpath = new Uri(uptobinpath).LocalPath;
            screenshot.SaveAsFile(localpath,ScreenshotImageFormat.Png);
            return localpath;
        }

        [TestMethod]
        public void EnvironmentVariables()
        {
            string hostName = Dns.GetHostName();
            OperatingSystem oSVersions = Environment.OSVersion;
            extentReports.AddSystemInfo("Operating System : ", oSVersions.ToString());
            extentReports.AddSystemInfo("Host Name : ", hostName);
        }


        [TestMethod]
        public void PassedTestMethod()
        {
                var Test = extentReports.CreateTest("PassedTestMethod").Info("<h4>...this Test method gets passed...</h4>");

                //screenshot....cl ScreenshotCaptureMethod and pass parameter  
                string screenshotPath = ScreenshotCaptureMethod(driver, "prashant");

                Test.Log(Status.Info, "first step of PassedTestMethod");
                Test.Pass("<div style='font-family: verdana; font-size: 15px; font-weight: bold; font-style: italic; background: #ffffcc; color: green; line-height: 18px;'>Passed Test Method gets complited</div>");
                Test.AddScreenCaptureFromPath(screenshotPath);
                //driver.Quit();

        }

        [TestMethod]
        public void FailedTestMethod()
        {
            string screenshotPath = ScreenshotCaptureMethod(driver, "prashant");
            var Test = extentReports.CreateTest("FailedTestMethod").Info("<h4>...this Test method gets passed...</h4>");
            Test.Log(Status.Info, "first step of FailedTestMethod");
            Test.Fail("<div style='font-family: verdana; font-size: 15px; font-weight: bold; font-style: italic; background: #ffffcc; color: darkred; line-height: 18px;'>Failed Test Method gets complited</div>");
            Test.AddScreenCaptureFromPath(screenshotPath);
        }

        [TestMethod]
        public void SkipedTestMethod()
        {
            var Test = extentReports.CreateTest("SkipedTestMethod").Info("<h4>...this Test method gets passed...</h4>");
            Test.Log(Status.Info, "first step of SkipedTestMethod");
            Test.Skip("<div style='font-family: verdana; font-size: 15px; font-weight: bold; font-style: italic; background: #ffffcc; color: orangered; line-height: 18px;'>Skiped Test Method gets complited</div>");
        }

        [TestMethod]
        public void WarningTestMethod()
        {
            var Test = extentReports.CreateTest("WarningTestMethod").Info("<h4>...this Test method gets passed...</h4>");
            Test.Log(Status.Info, "first step of WarningTestMethod");
            Test.Warning("<div style='font-family: verdana; font-size: 15px; font-weight: bold; font-style: italic; background: #ffffcc; color: orange; line-height: 18px;'>Warning Test Method gets complited</div>");

        }

        [TestCleanup]
        public void Cleanup()
        {
            extentReports.Flush();
        }



   


    }
}



