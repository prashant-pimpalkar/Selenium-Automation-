using OpenQA.Selenium; //IWebElement
//using OpenQA.Selenium.Support.PageObjects;//[FindsBy]
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Complite
{

 public  class EAPageObject  //page object model
    {
        //constructor to initialize the property 
        public EAPageObject()
        {
        PageFactory.InitElements(PropertiesCollection.driver, this); //this mines EAPageObject here 
        }

        [FindsBy(How =How.Id,Using = "firstname")]
        public IWebElement txtfirstname { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn")]
        public IWebElement btnsubmit { get; set; }



        //this code used for SeleniumAdvancedPart5
        public void FillStudentForm(string enterfirstname)
        {
            //here directly using property not using method 
            txtfirstname.SendKeys(enterfirstname);
            btnsubmit.Submit();
        }

        public void FillStudentFormUsing_PageObjectRefactoringCustomSetMethod(string enterfirstname)
        {
            //more dinamic and custmize as compare to above method 
            //here using method PageObjectRefactoringCustomSetMethod 
            PageObjectRefactoringCustomSetMethod.EnterText(txtfirstname, enterfirstname);
            PageObjectRefactoringCustomSetMethod.Click(btnsubmit);
        }

        public void FillStudentFormUsing_ExtensionMethod(string enterfirstname)
        {
            txtfirstname.EnterText(enterfirstname);
            //click method allready available so its ambiguti problem so we will not created extenstion method like click ...so we will created as name -clicks
            btnsubmit.Clicks();
        }

    }
}
