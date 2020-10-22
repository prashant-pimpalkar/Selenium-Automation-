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
    class StudentPageObject
    {

        //constructor to initialize the property 
        public StudentPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "FirstName")]
        public IWebElement enterFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "LastName")]
        public IWebElement enterLastName { get; set; }

        [FindsBy(How = How.Id, Using = "EnrollmentDate")]
        public IWebElement enterEnrollmentDate { get; set; }


        [FindsBy(How = How.ClassName, Using = "btn")]
        public IWebElement btnCreate { get; set; }


        public EAPageObject CreateStudent(string firstName, string lastName, string enrollmentDate)
        {
            //here directly passing the property 
            enterFirstName.SendKeys(firstName);
            enterLastName.SendKeys(lastName);
            enterEnrollmentDate.SendKeys(enrollmentDate);
            btnCreate.Submit();
            //return EAPageObject
            return new EAPageObject();
        }


        public EAPageObject CreateStudent_PageObjectRefactoringCustomSetMethod(string firstName, string lastName, string enrollmentDate)
        {
            //here we r using the customizing the code by again reducing the parameter and pass by susing method 
            PageObjectRefactoringCustomSetMethod.EnterText(enterFirstName, firstName);
            PageObjectRefactoringCustomSetMethod.EnterText(enterLastName, lastName);
            PageObjectRefactoringCustomSetMethod.EnterText(enterEnrollmentDate, enrollmentDate);
            PageObjectRefactoringCustomSetMethod.Click(btnCreate);
            return new EAPageObject();
        }

        public EAPageObject CreateStudentUsing_ExtensionMethod(string firstName, string lastName, string enrollmentDate)
        {
            //here we r using the customizing the code by again reducing the parameter and pass by susing method 
            enterFirstName.EnterText(firstName);
            enterLastName.EnterText(lastName);
            enterEnrollmentDate.EnterText(enrollmentDate);
            btnCreate.Clicks();
            return new EAPageObject();
        }

    }
}
