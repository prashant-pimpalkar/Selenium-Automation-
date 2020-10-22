using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Complite
{
    class PageObjectRefactoringCustomSetMethod
    {

        //EnterText by using id,name ,classname
        //instated of passing -IWebDriver driver- as parameter ,create a property and use it
        public static void EnterText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }


        //click into a btn, dropdown option 
        public static void Click(IWebElement element)
        {
            element.Click();
        }

        //selecting a DropDown  control
        public static void SelectDropDown(IWebElement element, string value)
        {
                new SelectElement(element).SelectByText(value);
        }


    }
}
