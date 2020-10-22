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
    //[TestClass] -used by using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestFixture] //-used by using NUnit.Framework; 
    public class SeleniumAdvancedPart1 
    {

        //-------------------------N-unit-----------------------------//

        [TestMethod]
        public void LaunchBrowser()
        {
            IWebDriver driver = new FirefoxDriver();  //run the borwser
            driver.Navigate().GoToUrl("https://www.google.co.in/");
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys("executeautomation");
            driver.Close();
        }

        //above 1st TestMethod separted into 3part(Initialize,ExecuteTest,CleanUp) below ....

        //IWebDriver -set it as a global veriable 
        IWebDriver driver = new FirefoxDriver();  //run the borwser
        [SetUp]//called immiteatly before each test case is run
        public void Initialize()
        {
            //Initialization  of browser every time so put it as a separate
            driver.Navigate().GoToUrl("https://www.google.co.in/");
        }

        [Test]//run the test case ----make method as a calleable 
        public void ExecuteTest()
        {
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys("http://www.uitestpractice.com/Students/Form");

        }
        [TearDown]//called immediately  after each test case is run
        public void CleanUp()
        {
            //close the browser evry time so make it as seprate
            driver.Close();
        }

        //-------------------------***-----------------------------//

    }
}
