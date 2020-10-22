using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium_Complite.Utility;
//-------------------------------
//below code added to AssemblyInfo.cs make sure that when we run the below test cases then uncommet after that commentout 
//add below code to the AssemblyInfo.cs file ---->AssemblyInfo.cs

//to define test attribite
//[assembly: Parallelizable(ParallelScope.Children)]

//how many browser u want to lounch at a time if u have a 3 test method then 2 method open at a time called as paralisum 
//[assembly: LevelOfParallelism(2)]
//and one namespace
//using NUnit.Framework;
//---------------------------
namespace Selenium_Complite
{
    class ParallelyTestExicutionUsingNunit
    {
        private IWebDriver driver;

        [Test, Category("parallizum")]//run the test case ----make method as a calleable 
        public void Method1()
        {
            var Driver = new BrowserUtility().Init(driver);
            driver.FindElement(By.Id("comment")).SendKeys("good \n morning");
            Driver.Close();
        }

        [Test, Category("parallizum")]
        public void Method2()
        {
            var Driver = new BrowserUtility().Init(driver);
            driver.FindElement(By.Id("comment")).SendKeys("good \n morning");
            Driver.Close();
        }

        [Test, Category("parallizum")]
        public void Method3()
        {
            var Driver = new BrowserUtility().Init(driver);
            driver.FindElement(By.Id("comment")).SendKeys("good \n morning");
            Driver.Close();
        }
    }
}


