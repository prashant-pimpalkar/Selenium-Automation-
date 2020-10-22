using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Complite.Utility
{
   public class BrowserUtility
    {
     
        public IWebDriver  Init(IWebDriver driver)
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.uitestpractice.com/Students/Form";
            return driver;
        }
        
    }
}
