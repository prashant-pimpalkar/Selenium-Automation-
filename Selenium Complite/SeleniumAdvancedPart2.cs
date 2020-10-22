//using Microsoft.VisualStudio.TestTools.UnitTesting;//[TestMethod] attribute used 
using NUnit.Framework; //[Test] attribute used then nuit need 
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Complite
{
    class SeleniumAdvancedPart2
    {
        // here  CustomSetMethod and CustomGetMethod implimenation done 

        IWebDriver driver = new FirefoxDriver();  //run the borwser

        [SetUp]//called immiteatly before each test case is run
        public void Initialize()
        {
            //Initialization  of browser every time so put it as a separate
            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Form");
        }

        
        [Test]
        [Author("prashant","3impalkar@gmail.com")]
        //[Description("verification")]
        //[TestCaseSource("DataDrivenTesting")]
        public void CustomeExecuteTest()
        {
            //EnterText(driver,element,value,elementtype)
            CustomSetMethod.EnterText(driver, "firstname", "prashant", "Id");
            CustomSetMethod.SelectDropDown(driver, "sel1", "India", "Id");
            Console.WriteLine("the value of firstname is-" + CustomGetMethod.GetText(driver, "firstname", "Id"));
            Console.WriteLine("the value of drop down is-" + CustomGetMethod.GetText(driver, "sel1", "Id"));
            CustomSetMethod.Click(driver, "btn", "ClassName");
           
        }


        [TearDown]//called immediately  after each test case is run
        public void CleanUp()
        {
            //close the browser evry time so make it as seprate
            driver.Close();
        }


    }
}
