using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_Complite.BaseClass; //namesapce added and invertited the class
using OpenQA.Selenium;

namespace Selenium_Complite
{
   [TestFixture]
 public class Module1 : BaseTest 
    {
        [Test,Category("Regression Testing")] //creating group of test cases baseed on Category but not longer in visual studio 17 and 19
        //[TestCaseSource(typeof(Module1DataService),"GetData1")]
        //[Test]
        public void TestMethod1()
        {
            driver.FindElement(By.Id("comment")).SendKeys("good \n morning");
            
        }


        [Test, Category("Smoke Testing")]
        //[TestCaseSource(typeof(Module1DataService),"GetData1")]
        //[Test]
        public void TestMethod2()
        {
            driver.FindElement(By.Id("comment")).SendKeys("good \n morning");

        }

        [Test, Category("Regression Testing")]
        //[TestCaseSource(typeof(Module1DataService),"GetData1")]
        //[Test]
        public void TestMethod3()
        {
            driver.FindElement(By.Id("comment")).SendKeys("good \n morning");

        }
    }
}
