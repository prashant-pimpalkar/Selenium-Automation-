using Microsoft.VisualStudio.TestTools.UnitTesting;//[TestMethod] attribute used 
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
    class SeleniumAdvancedPart3
    {
        //--------RefactoringCustomeExecuteTest--------------------------//
        //-----1)reduces its parameter iwebdriver here 2)bring strongly type parameter by using enum 3)more reusability

        //insted of this use property i.e.- PropertiesCollection
        //IWebDriver driver = new FirefoxDriver(); 

        [SetUp]//called immiteatly before each test case is run
        public void Initialize()
        {
            PropertiesCollection.driver = new FirefoxDriver();
            //Initialization  of browser every time so put it as a separate
            PropertiesCollection.driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Form");
        }


        [Test]//run the test case ----make method as a calleable 
        public void RefactoringCustomeExecuteTest()
        {
            //EnterText(driver,element,value,elementtype)
            RefactoringCustomSetMethod.EnterText("firstname", "prashant", Elementtype.Id);
            RefactoringCustomSetMethod.SelectDropDown("sel1", "India", Elementtype.Id);
            Console.WriteLine("the value of firstname is-" + RefactoringCustomGetMethod.GetText("firstname", Elementtype.Id));
            Console.WriteLine("the value of drop down is-" + RefactoringCustomGetMethod.GetText("sel1", Elementtype.Id));
            RefactoringCustomSetMethod.Click("btn", Elementtype.ClassName);

        }


        [TearDown]//called immediately  after each test case is run
        public void CleanUp()
        {
            //close the browser evry time so make it as seprate
            PropertiesCollection.driver.Close();
        }




    }
}
