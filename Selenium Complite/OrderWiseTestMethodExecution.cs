using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Complite
{
    class OrderWiseTestMethodExecution
    {
        IWebDriver driver = new FirefoxDriver();

        [Test, Order(1)]//run the test case ----make method as a calleable 
        public void Method1()
        {
            driver.Quit(); //close the borwser 
        }

        [Test,Order(0)]
        public void Method2()
        {
            driver.Url = "https://www.irctc.co.in";   //open the Url or set the Url
        }
        [Test, Order(2)]
        public void Method3()
        {
            Assert.Ignore("defect...this method not exicute it will skip  ");
            driver.Url = "https://www.irctc.co.in";   //open the Url or set the Url
        }
    }
}
