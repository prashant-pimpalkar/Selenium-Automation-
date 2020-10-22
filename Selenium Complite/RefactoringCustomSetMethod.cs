using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Complite
{
    class RefactoringCustomSetMethod
    {

        //EnterText by using id,name ,classname
     //instated of passing -IWebDriver driver- as parameter ,create a property and use it
        public static void EnterText( string element, string value, Elementtype elementtype)
        {
            //EnterText(driver,element,value,elementtype)
            if (elementtype == Elementtype.Id)
            {
                PropertiesCollection.driver.FindElement(By.Id(element)).SendKeys(value);
            }
            if (elementtype == Elementtype.Name)
            {
                PropertiesCollection.driver.FindElement(By.Name(element)).SendKeys(value);
            }
            if (elementtype == Elementtype.ClassName)
            {
                PropertiesCollection.driver.FindElement(By.ClassName(element)).SendKeys(value);
            }
        }


        //click into a btn, dropdown option 
        public static void Click(string element, Elementtype elementtype)
        {
            //EnterText(driver,element,value,elementtype)
            if (elementtype == Elementtype.Id)
            {
                PropertiesCollection.driver.FindElement(By.Id(element)).Click();
            }
            if (elementtype == Elementtype.Name)
            {
                PropertiesCollection.driver.FindElement(By.Name(element)).Click();
            }
            if (elementtype == Elementtype.ClassName)
            {
                PropertiesCollection.driver.FindElement(By.ClassName(element)).Click();
            }

        }

        //selecting a DropDown  control
        public static void SelectDropDown(string element, string value, Elementtype elementtype)
        {

            //EnterText(driver,element,value,elementtype)
            if (elementtype == Elementtype.Id)
            {
                new SelectElement(PropertiesCollection.driver.FindElement(By.Id(element))).SelectByText(value);
            }
            if (elementtype == Elementtype.Name)
            {
                new SelectElement(PropertiesCollection.driver.FindElement(By.Name(element))).SelectByText(value);
            }
            if (elementtype == Elementtype.ClassName)
            {
                new SelectElement(PropertiesCollection.driver.FindElement(By.ClassName(element))).SelectByText(value);
            }
        }



    }
}





