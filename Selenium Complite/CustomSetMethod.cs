using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Complite
{
    class CustomSetMethod
    {

        //EnterText by using id,name ,classname
        public static void EnterText(IWebDriver driver, string element,string value,string elementtype)
        {
            //EnterText(driver,element,value,elementtype)
            if (elementtype == "Id")
            {
                driver.FindElement(By.Id(element)).SendKeys(value);
            }
            if (elementtype == "Name")
            {
                driver.FindElement(By.Name(element)).SendKeys(value);
            }
            if (elementtype == "ClassName")
            {
                driver.FindElement(By.ClassName(element)).SendKeys(value);
            }
        }


        //click into a btn, dropdown option 
        public static void Click(IWebDriver driver, string element, string elementtype)
        {
            //EnterText(driver,element,value,elementtype)
            if (elementtype == "Id")
            {
                driver.FindElement(By.Id(element)).Click();
            }
            if (elementtype == "Name")
            {
                driver.FindElement(By.Name(element)).Click();
            }
            if (elementtype == "ClassName")
            {
                driver.FindElement(By.ClassName(element)).Click();
            }
           
        }

        //selecting a DropDown  control
        public static void SelectDropDown(IWebDriver driver, string element, string value, string elementtype)
        {

            //EnterText(driver,element,value,elementtype)
            if (elementtype == "Id")
            {
                new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
            }
            if (elementtype == "Name")
            {
                new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
            }
            if (elementtype == "ClassName")
            {
                new SelectElement(driver.FindElement(By.ClassName(element))).SelectByText(value);
            }
        }


    }
}
