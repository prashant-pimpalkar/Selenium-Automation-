using Microsoft.VisualStudio.TestTools.UnitTesting;//[TestMethod] attribute used 
using NUnit.Framework; //[Test] attribute used then nuit need 
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Selenium_Complite
{
    [TestFixture]
    [Parallelizable]
   public class ParallelyTestExecution :Hooks
    {
        public ParallelyTestExecution():base(BrowerType.Firefox)
        {

        }

        [Test]
        public void FirefoxDriver()
        {
            //IWebDriver driver = new FirefoxDriver(); //run the borwser
            Driver.Url = "http://www.uitestpractice.com/Students/Index"; //open the Url or set the Url
            Driver.FindElement(By.XPath("//tbody//tr[2]//td[4]//button[1]")).Click();
            Thread.Sleep(20000);

        }

    }


    [TestFixture]
    [Parallelizable]
    public class ParallelyTestExecution1 : Hooks
    {
        public ParallelyTestExecution1() : base(BrowerType.Chrome)
        {

        }
        [Test]
        public void ChromeDriver()
        {
            //IWebDriver driver = new ChromeDriver(); //run the borwser
            Driver.Url = "http://www.uitestpractice.com/Students/Index"; //open the Url or set the Url
            //click on edit link
            Driver.FindElement(By.XPath("//tbody//tr[2]//td[4]//button[1]")).Click();
            Thread.Sleep(20000);

        }
    }












}
