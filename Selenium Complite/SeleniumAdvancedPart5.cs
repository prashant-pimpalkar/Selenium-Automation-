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
    class SeleniumAdvancedPart5
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

            PropertiesCollection.driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Create");
        }


        [Test]//run the test case ----make method as a calleable 
        public void PageObjectModel_RefactoringCustomeExecuteTest()
        {
            StudentPageObject studentPageObject = new StudentPageObject();
            //EAPageObject PageEA = studentPageObject.CreateStudent("prashant", "pimpalkar", "01/01/2012");
            studentPageObject.CreateStudent("prashant", "pimpalkar", "01/01/2012");

            EAPageObject PageEA = new EAPageObject();
           // PageEA.txtfirstname.SendKeys("prashant");
            PageEA.FillStudentForm("sw");
        }


        [Test]//run the test case ----make method as a calleable 
        public void PageObjectModel_RefactoringCustomeExecuteTest_PageObjectRefactoringCustomGetMethod()
        {
            StudentPageObject studentPageObject = new StudentPageObject();
            //EAPageObject PageEA = studentPageObject.CreateStudent("prashant", "pimpalkar", "01/01/2012");
            EAPageObject PageEA = studentPageObject.CreateStudent_PageObjectRefactoringCustomSetMethod("prashant", "pimpalkar", "01/01/2012");

            ///EAPageObject PageEA = new EAPageObject();
             PageEA.FillStudentFormUsing_PageObjectRefactoringCustomSetMethod("sw");
        }


        [Test]//run the test case ----make method as a calleable 
        public void ExtenstionMethodcl()
        {
            StudentPageObject studentPageObject = new StudentPageObject();
            //EAPageObject PageEA = studentPageObject.CreateStudent("prashant", "pimpalkar", "01/01/2012");
            EAPageObject PageEA = studentPageObject.CreateStudentUsing_ExtensionMethod("prashant", "pimpalkar", "01/01/2012");

            ///EAPageObject PageEA = new EAPageObject();
            PageEA.FillStudentFormUsing_ExtensionMethod("sw");
        }


        [TearDown]//called immediately  after each test case is run
        public void CleanUp()
        {
            //close the browser evry time so make it as seprate
            PropertiesCollection.driver.Close();
        }

    }
}
