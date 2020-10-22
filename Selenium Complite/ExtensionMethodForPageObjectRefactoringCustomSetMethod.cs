using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Complite
{
   public static class ExtensionMethodForPageObjectRefactoringCustomSetMethod
    {


        //if u used this keyword then this method called as ExtensionMethod
        //create a class and method static 
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }


        //click into a btn, dropdown option 
        public static void Clicks (this IWebElement element)
        {
            element.Click();
        }

        //selecting a DropDown  control
        public static void SelectDropDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

    }
}
