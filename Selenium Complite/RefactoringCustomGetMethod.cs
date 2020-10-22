using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Complite
{
    class RefactoringCustomGetMethod
    {

        public static string GetText(string element, Elementtype elementtype)
        {
            //EnterText(driver,element,value,elementtype)
            if (elementtype == Elementtype.Id)
            {
                return PropertiesCollection.driver.FindElement(By.Id(element)).GetAttribute("value");
            }
            if (elementtype == Elementtype.Name)
            {
                return PropertiesCollection.driver.FindElement(By.Name(element)).GetAttribute("value");
            }
            if (elementtype == Elementtype.ClassName)
            {
                return PropertiesCollection.driver.FindElement(By.ClassName(element)).GetAttribute("value");
            }
            else
            {
                return string.Empty;
            }
        }

        public static string GetTextFromDDL(string element, Elementtype elementtype)
        {
            //EnterText(driver,element,value,elementtype)
            if (elementtype == Elementtype.Id)
            {
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).AllSelectedOptions.SingleOrDefault().Text;
            }
            if (elementtype == Elementtype.Name)
            {
                return new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).AllSelectedOptions.SingleOrDefault().Text;

            }
            if (elementtype == Elementtype.ClassName)
            {
                return new SelectElement(PropertiesCollection.driver.FindElement(By.ClassName(element))).AllSelectedOptions.SingleOrDefault().Text;

            }
            else
            {
                return string.Empty;
            }
        }


    }
}
