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
    class SeleniumAdvancedPart4
    {

        //--------PageObjectModel_RefactoringCustomeExecuteTest--------------------------//
        //-----1)reduces its parameter 2)bring strongly type parameter 3)more reusability

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
        public void PageObjectModel_RefactoringCustomeExecuteTest()
        {
            //RefactoringCustomSetMethod.EnterText("firstname", "prashant", Elementtype.Id);
            EAPageObject page = new EAPageObject();
            page.txtfirstname.SendKeys("prashant");
            //RefactoringCustomSetMethod.Click("btn", Elementtype.ClassName);
            page.btnsubmit.Click();
        }


        [Test]//run the test case ----make method as a calleable 
        public void PageObjectModel_RefactoringCustomeExecuteTest_PageObjectRefactoringCustomGetMethod()
        {
            //RefactoringCustomSetMethod.EnterText("firstname", "prashant", Elementtype.Id);
            EAPageObject page = new EAPageObject();
            page.FillStudentFormUsing_PageObjectRefactoringCustomSetMethod("prashant");
        }

        [Test]//run the test case ----make method as a calleable 
        public void ExtenstionMethodcl()
        {
            //RefactoringCustomSetMethod.EnterText("firstname", "prashant", Elementtype.Id);
            EAPageObject page = new EAPageObject();
            page.FillStudentFormUsing_ExtensionMethod("prashant");
        }

        [TearDown]//called immediately  after each test case is run
        public void CleanUp()
        {
            //close the browser evry time so make it as seprate
            PropertiesCollection.driver.Close();
        }

    }
}
