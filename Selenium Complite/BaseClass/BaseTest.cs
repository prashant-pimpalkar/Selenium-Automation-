using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//observ the namespace Selenium_Complite ia project name and BaseClass is a folder that content class file BaseTest
namespace Selenium_Complite.BaseClass //import this namespace and inherit the class
{
    public class BaseTest
    {
        public IWebDriver driver;

       // [OneTimeSetUp]//it will run only one time before run all test cases (only one time for all test method)
        [SetUp] //it will run  before every test cases ...every test method exicuted seprately 
        public void Open()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Form");
        }

      //  [OneTimeTearDown]// it will run only one time after run any test cases
         [TearDown]
        public void Close()
        {
            driver.Close();
        }
    }
}
