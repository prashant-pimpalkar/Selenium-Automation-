using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;  //IWebDriver
using OpenQA.Selenium.Firefox; // FirefoxDriver
using System.Threading;  //Thread
using System.Drawing;   // Point
using System.Linq;  //count of CSSSelector
using System.Collections.ObjectModel; //ReadOnlyCollection
using OpenQA.Selenium.Support.UI;//1st insall the pkg Selenium.Support then type SelectElement for that add this namesapce  
using System.Collections.Generic; //IList<IWebElement>
using OpenQA.Selenium.Interactions;//Actions
using System.Diagnostics;//Stopwatch
using System.Drawing.Imaging;//ImageFormat
using Microsoft.Expression.Encoder.ScreenCapture;//ScreenCaptureJob....1st u have to add a refrences of Encoder
using OpenQA.Selenium.Chrome; //ChromeDriver ... 1st u have instoll the crom driver from neu get magackage manager 
using OpenQA.Selenium.IE;//InternetExplorerDriver
using OpenQA.Selenium.Edge;//EdgeDriver
using WDSE;//TakeScreenshot 1st u have to install the Noksa.WebDriver.ScreenshotsExtensions
using WDSE.Decorators;//VerticalCombineDecorator
using WDSE.ScreenshotMaker;//ScreenshotMaker
using OpenQA.Selenium.Support.Events;//Events
using System.IO;//FileInfo
using OfficeOpenXml;//ExcelPackage
using log4net.Config;//log4net instoll the pkg from new get pkg Mgr
using log4net;
//using NUnit.Framework;

//using OpenQA.Selenium.PhantomJS;

namespace Selenium_Complite
{
    [TestClass]
    public class SeleniumBasic
    {
        [TestMethod]
        public void LaunchBrowser()
        {
            IWebDriver driver = new FirefoxDriver();  //run the borwser
            driver.Url = "https://www.irctc.co.in";   //open the Url or set the Url

            driver.Quit(); //close the borwser 
        }

        [TestMethod]
        public void Get_PageTitle_Url_and_PageSource()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "https://www.irctc.co.in";    //open the Url

            Console.WriteLine(driver.Title); //Get the page title 

            Console.WriteLine(driver.Url); //Get the Url  

            driver.Url = "http://www.uitestpractice.com/"; //open the Url or set the Url
            Console.WriteLine(driver.PageSource); //Get all the page code ur source 
            driver.Quit();  //close the borwser 
        }

        [TestMethod]
        public void ManageBrowserWindo()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/"; //open the Url or set the Url

            driver.Manage().Window.FullScreen(); //browser will goes to full screen mode
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  

            driver.Manage().Window.Maximize(); //browser will goes to Maximize mode if not Maximize 
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result

            driver.Manage().Window.Minimize(); //browser will goes to Minimize mode if not minimize 
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result

            driver.Manage().Window.Position = new Point(400, 200); // set the postion of browser windo
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result on browser windo

            Point point = driver.Manage().Window.Position; // get the postion of browser windo (o/p)
            Console.WriteLine(point); //view the result in visual studio o/p...it will give u x aixs and y aixs posion 

            driver.Manage().Window.Size = new Size(400, 600); // set the size (resize)of browser windo
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result on browser windo

            Size size = driver.Manage().Window.Size; // get the size (resize) of browser windo (o/p)
            Console.WriteLine(size); //view the result in visual studio o/p...it will give u width and height 

            driver.Quit();  //close the borwser 
        }


        [TestMethod]
        public void BrowserNavigation()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "https://www.irctc.co.in"; //open the Url or set the Url
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  

            driver.Navigate().GoToUrl("http://www.uitestpractice.com/"); //navigate from one url to anather url
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  

            driver.Navigate().Back(); //move back to the single entry in the browser's history  (back previouse)
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  

            driver.Navigate().Forward(); //move Forward to the single entry in the browser's history  (next page)
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  

            driver.Navigate().Refresh(); //Refresh the current page (intrnally presing f5 button)
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  

            driver.Quit();  //close the borwser 
        }

        [TestMethod]
        public void LocateById()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Account/Login"; //open the Url or set the Url
            driver.FindElement(By.Id("Email")).SendKeys("a@d.com");
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  
            driver.Quit();  //close the borwser 
        }

        [TestMethod]
        public void LocateByName()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Account/Login"; //open the Url or set the Url
            driver.FindElement(By.Name("Email")).SendKeys("a@d.com");
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  
            driver.Quit();  //close the borwser 
        }

        [TestMethod]
        public void LocateByClassName()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/"; //open the Url or set the Url
            string Output = driver.FindElement(By.ClassName("jumbotron")).Text;//get the text element in the class 
            Console.WriteLine(Output);
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  
            driver.Quit();  //close the borwser 
        }

        [TestMethod]
        public void LocateByTagName()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/"; //open the Url or set the Url
            var Output = driver.FindElements(By.TagName("p"));
            Console.WriteLine(Output.Count);
            foreach (var item in Output)
            {
                Console.WriteLine(item.Text);
            }
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  
            driver.Quit();  //close the borwser 
        }


        [TestMethod]
        public void LocateByLinkTextName()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/"; //open the Url or set the Url
            driver.FindElement(By.LinkText("Register")).Click();  //click on register lick to open this link text 

            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  
            driver.Quit();  //close the borwser 
        }


        [TestMethod]
        public void LocateByPartialLinkTextName()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/"; //open the Url or set the Url
            driver.FindElement(By.PartialLinkText("Reg")).Click();  //by passing part of link it will open the link 

            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  
            driver.Quit();  //close the borwser 
        }


        [TestMethod]
        public void CSSSelector()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Account/Login"; //open the Url or set the Url
            int countOutput = driver.FindElements(By.CssSelector("*")).Count();  //all the css element 
            Console.WriteLine("no of elements found with above CSS Selector" + countOutput);
            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  
            driver.Quit();  //close the borwser 
        }

        [TestMethod]
        public void CSSSelectorById()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Account/Login"; //open the Url or set the Url
            driver.FindElement(By.CssSelector("#Email")).SendKeys("a@d.com");  // By passing Id ="Email" we can select dom element by using # ...# refere to id 

            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  
            driver.Quit();  //close the borwser 
        }

        [TestMethod]
        public void CSSSelectorByClass()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Account/Login"; //open the Url or set the Url
            driver.FindElements(By.CssSelector(".form-control"))[1].SendKeys("123456");  // By passing Id ="Email" we can select dom element by using dot ..  . refere to class 

            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  
            driver.Quit();  //close the borwser 
        }


        [TestMethod]
        public void CSSSelectorByTag()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Account/Login"; //open the Url or set the Url

            driver.FindElement(By.CssSelector("input[name='Email']")).SendKeys("a@a.com");  //select by  tag[attribute='value']

            int totalCount = driver.FindElements(By.CssSelector("a[href^='/Home']")).Count();  // ^ indicate that  whouse element satrt with /Home 
            Console.WriteLine(totalCount);

            driver.FindElement(By.CssSelector("a[href$='Training']")).Click();  // $ indicate that whouse element end with Training 

            string textOutput = driver.FindElement(By.CssSelector("footer p")).Text;  // tag ke under ka tag selecter 
            Console.WriteLine(textOutput);

            //IWebDriver driver = new FirefoxDriver(); //run the borwser
            //driver.Url = "http://ankpro.com/"; //open the Url or set the Url
            string textOutput1 = driver.FindElement(By.CssSelector("h1+p")).Text;  //h1 tag ke ke bad me p ko tag ko select krne ke liye 
            Console.WriteLine(textOutput1);

            string textOutput2 = driver.FindElement(By.CssSelector("form[role]")).Text;  //tag[attribute] 
            Console.WriteLine(textOutput2);

            driver.FindElement(By.Id("RememberMe")).Click();
            bool checkboxselected = driver.FindElement(By.CssSelector("input[type='checkbox']:checked")).Selected;  //select by  tag[attribute='value']
            Console.WriteLine(checkboxselected);

            Thread.Sleep(4000);// wait for 4000 mili sec to view the result  
            driver.Quit();  //close the borwser footer
        }


        [TestMethod]
        public void AbsoluteXPathLocator()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Account/Login"; //open the Url or set the Url
            string textOutput = driver.FindElement(By.XPath("html/body/div[2]/footer/p")).Text;  // in the AbsoluteXPathLocator complite path requred to find the element 
            Console.WriteLine(textOutput);
        }


        [TestMethod]
        public void RelativeXPathLocator()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Account/Login"; //open the Url or set the Url
            int CountOutput = driver.FindElements(By.XPath(".//*")).Count;  //count all the tag element by using xpath
            Console.WriteLine("All tag Element CountOutput = " + CountOutput);

            int CountOutput1 = driver.FindElements(By.XPath(".//input")).Count;  //count all the input tag element by using xpath
            Console.WriteLine("input tag Element CountOutput1 = " + CountOutput1);

            driver.FindElement(By.XPath(".//input[@id='Email']")).SendKeys("a@a.com");  //send data using attribut element by using xpath

            // driver.FindElement(By.XPath(".//input[@id='Password'][@name='Password']")).SendKeys("123456");  //multiple attribut using id , name , class etc 
            driver.FindElement(By.XPath(".//input[@id='Password' and @name='Password']")).SendKeys("123456");  //it will check for both the condtion are true 
            driver.FindElement(By.XPath(".//input[@id='Password' or @name='Passwordddd']")).SendKeys("123456");  //it will check for any one condtion are true  
        }


        [TestMethod]
        public void XPathLocatorUsingIndex()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Home/Training"; //open the Url or set the Url
            string textOutput = driver.FindElement(By.XPath("//tr[2]/td[2]")).Text;  //find the value by using indexer by using xpath 
            Console.WriteLine("XPath select 2nd td element in a 2nd row tr - textOutput = " + textOutput);
        }

        [TestMethod]
        public void XPathLocatorUsingFunction()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/"; //open the Url or set the Url
            string textOutput = driver.FindElement(By.XPath(".//h2[text()='Our People']")).Text;  //select the element which content the text 'Our People'
            Console.WriteLine("textOutput = " + textOutput);


            driver.Url = "http://ankpro.com/Account/Login"; //open the Url or set the Url
            driver.FindElement(By.XPath(".//input[starts-with(@id,'Rem')]")).Click();  // id start with - some satring  part of value or text  
            driver.FindElement(By.XPath(".//input[contains(@id,'me')]")).Click();  // id contains with - (rememberme)this word contentme then click 
            driver.FindElement(By.XPath(".//input[@type='checkbox' and not(@checked)]")).Click();  // not function in xpath -if attribute not contain checked then click 

            driver.Url = "http://ankpro.com/Home/Training"; //open the Url or set the Url
            string textOutput1 = driver.FindElement(By.XPath(".//tbody/tr[last()]")).Text;  // select last element in the table 
            Console.WriteLine("XPath select last element in the table  - textOutput1 = " + textOutput1);

            string textOutput2 = driver.FindElement(By.XPath(".//tbody/tr[last()-1]")).Text;  // select last element in the table 
            Console.WriteLine("XPath select last -1 value  (it mines prreviouse value) in the table  - textOutput2 = " + textOutput2);

            driver.Url = "http://ankpro.com/Account/Register"; //open the Url or set the Url
            driver.FindElement(By.XPath("(.//input[@type = 'password'])[position=2]")).SendKeys("12345");  // if attribute having same name then select by using postion 

        }

        [TestMethod]
        public void XPathAxes()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/"; //open the Url or set the Url
            string textOutput = driver.FindElement(By.XPath(".//h1/parent::div")).Text;
            Console.WriteLine("it will select the parent div of h1 tag " +  textOutput);

            string textOutput1 = driver.FindElement(By.XPath(".//footer/child::p")).Text;
            Console.WriteLine("it will select the child p tag of footer tag " + textOutput1);

            driver.Url = "http://ankpro.com/Home/Training";
            int CountOutput = driver.FindElements(By.XPath("//tr[6]/following-sibling::tr")).Count();
            Console.WriteLine("it will give u the 6 tr from below all tr from a table " + CountOutput);

            int CountOutput1 = driver.FindElements(By.XPath("//tr[6]/following::*")).Count();
            Console.WriteLine("it will give u the 6 tr from below all tr from a table " + CountOutput1);

            int CountOutput2 = driver.FindElements(By.XPath("//tr[6]/preceding-sibling::tr")).Count();
            Console.WriteLine("it will give u the 6 tr from above all tr from a table " + CountOutput2);

            int CountOutput3 = driver.FindElements(By.XPath("//tr[6]/preceding::*")).Count();
            Console.WriteLine("it will give u the 6 tr from above all tr from a table " + CountOutput3);
            //table/ancestor::div
            //table/descendant::td
        }

        [TestMethod]
        public void WebElementsProperty()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Home/Training";
            bool ImageDisplayed  = driver.FindElement(By.ClassName("img-responsive")).Displayed;
            Console.WriteLine("Image Displayed on web page " + ImageDisplayed);

            driver.Url = "http://ankpro.com/Account/Login"; //open the Url or set the Url
            bool TextboxEnabled = driver.FindElement(By.Id("Email")).Enabled;
            Console.WriteLine("Email Textbox Enabled " + TextboxEnabled);


            Point point = driver.FindElement(By.Id("Email")).Location;//it is use when some text box size is missmatch 
            Console.WriteLine("Location OF Email Textbox is " + point.X + point.Y);

            bool CheckboxSelectedOrNot = driver.FindElement(By.Id("RememberMe")).Selected;
            Console.WriteLine("verifing the Checkbox Selected Or Not " + CheckboxSelectedOrNot);

            Size SizeOfTextBox = driver.FindElement(By.Id("Email")).Size;
            Console.WriteLine("geting the Size (width and height) Of Email TextBox " + SizeOfTextBox);

            string tagName = driver.FindElement(By.Id("Email")).TagName;
            Console.WriteLine("geting the tagName of email. tagName such as input,div,h1,p...etc " + tagName);

            driver.Url = "http://ankpro.com/"; //open the Url or set the Url
            string text = driver.FindElement(By.XPath(".//h2")).Text;
            Console.WriteLine("captuaring  the text in h2 tag " + text);

        }

        [TestMethod]
        public void WebElementsMethod()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Account/Login"; //open the Url or set the Url
             driver.FindElement(By.Id("Email")).SendKeys("p@p.com");//Enter the value in the text box
            Thread.Sleep(4000);
            driver.FindElement(By.Id("Email")).Clear();//Clear/deleteing text box value
            driver.FindElement(By.LinkText("registerLink")).Click();//click on registerLink
            //FindElement
            //FindElements
            //SendKeys

            driver.FindElement(By.XPath(".//input[@type='submit']")).Submit();//click on submit button 

            string color = driver.FindElement(By.LinkText("registerLink")).GetCssValue("color");//it will give rgb value combination of red green and blue 
            Console.WriteLine("it will give rgb value combination of red green and blue" + color);

            driver.Url = "http://ankpro.com/Home/Training";
            string ImagePath = driver.FindElement(By.TagName("img")).GetAttribute("src");
            Console.WriteLine("Image path on web page or Get src Attribute value " + ImagePath);

        }

        [TestMethod]
        public void DiffrenecesBetweenFindElementAndFindElements()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Home/Training";

            //1st diffrences 
            // if no match 
            //FindElement returen error 
            //FindElements returen emptyor zero 
            IWebElement element = driver.FindElement(By.Id("sample"));
           Console.WriteLine("if id=sample not present then it will return the eroor 'no such element exception ' " + element);


            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("sample"));
            Console.WriteLine("if id=sample not present then it will return the o/p is zero 0 " + elements.Count);

            //2nd diffrences 
            // if one match 
            //FindElement returen one match value  
            //FindElements returen Collection of one match value  

            IWebElement element1 = driver.FindElement(By.TagName("h2"));
            Console.WriteLine("if TagName=h2 one watch o/p shown " + element1.Text);

            ReadOnlyCollection<IWebElement> elements1 = driver.FindElements(By.TagName("h2"));
            Console.WriteLine("if TagName=h2 then count" + elements1.Count);
            foreach (var item in elements1)
            {
                Console.WriteLine("if TagName=h2 then display the text " + item.Text);
            }

            //3rd diffrences 
            // if multiple match
            //FindElement returen 1st value only 
            //FindElements returen all value 
        }


        [TestMethod]
        public void CountCheckedUnCheckedCheckboxs()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Form";
            //all checkbox are unchecked on form so 1st click on 2 checkbox (below 2 line indiacte)
            driver.FindElement(By.XPath(".//input[@value='dance']")).Click();
            driver.FindElement(By.XPath(".//input[@value='cricket']")).Click();

            ReadOnlyCollection<IWebElement> webElements = driver.FindElements(By.XPath(".//input[@type='checkbox']"));
            int CheckedCount = 0;
            int UnCheckedCount = 0;

            foreach (var element in webElements)
            {
                if (element.Selected == true)
                {
                    CheckedCount++;
                }
                else
                {
                    UnCheckedCount++;
                }
            }

            Console.WriteLine("No of checked checkbox are -" + CheckedCount);
            Console.WriteLine("No of Unchecked checkbox are -" + UnCheckedCount);
            driver.Quit();
        }

        
        [TestMethod]
        public void NewLineAndTab()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Form";
            driver.FindElement(By.Id("comment")).SendKeys("good \n morning");// \n satrt the morning word from next line 
            driver.FindElement(By.Id("comment")).SendKeys("good \t night"); // tab giving some sppace in between goodnight 
            Thread.Sleep(4000);
            driver.Quit();
        }

        [TestMethod]
        public void Dropdown()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Select";

            //single drop down 
            //count the dropdown value and display all drowpdown values 
            IWebElement element = driver.FindElement(By.Id("countriesSingle"));
            SelectElement selectElement = new SelectElement(element);
            IList<IWebElement> elements = selectElement.Options;
            Console.WriteLine(elements.Count);
            foreach (var item in elements)
            {
                Console.WriteLine(item.Text);
            }

            //selected value from drop down 
            IWebElement SelectedOption = selectElement.SelectedOption;
            Console.WriteLine(SelectedOption.Text);
        }

        [TestMethod]
        public void MultiSelectDropdownOrNot()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Select";
            
            IWebElement element = driver.FindElement(By.Id("countriesMultiple"));
            SelectElement selectElement = new SelectElement(element);

            bool isMultiple = selectElement.IsMultiple; //drop down is multi select dropdown or not ..it will return true or false
            Console.WriteLine(isMultiple);

        }

        [TestMethod]
        public void MultiSelectDropdown()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Select";

            //MultiSelectDropdown 
            
            IWebElement element = driver.FindElement(By.Id("countriesMultiple"));
            SelectElement selectElement = new SelectElement(element);
            
            //select one value from  MultiSelectDropdown

            selectElement.SelectByText("India"); //selecting the Dropdown value by passsing the test
            //or
            selectElement.SelectByIndex(1); //selecting the Dropdown value by passsing the Index
            //or
            selectElement.SelectByValue("india"); //selecting the Dropdown value by passsing the value

            //Deselect one value from  MultiSelectDropdown
            selectElement.DeselectByText("India"); //Deselecting the Dropdown value by passsing the test
            //or
            selectElement.DeselectByIndex(1); //Deselecting the Dropdown value by passsing the Index
            //or
            selectElement.DeselectByValue("india"); //Deselecting the Dropdown value by passsing the value

            //select one or more value from  MultiSelectDropdown 

            selectElement.SelectByIndex(1);
            selectElement.SelectByIndex(2);
            IList<IWebElement> elements = selectElement.AllSelectedOptions;
            Console.WriteLine(elements.Count);
            foreach (var item in elements)
            {
                Console.WriteLine(item.Text);
            }

            //Deselect selected value
         
                selectElement.DeselectAll();
        }


        [TestMethod]
        public void BootStrapDropdown()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Select";
            driver.FindElement(By.Id("dropdownMenu1")).Click(); //click on drop down 

            //SelectElement from dropdwon
            driver.FindElement(By.XPath("//a[text()='India']")).Click();

            //capture the text selected in the dropdown 
           string selectedText = driver.FindElement(By.Id("dropdownMenu1")).Text;
            Console.WriteLine(selectedText);

        }

        [TestMethod]
        public void ActionMoveTOElement()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(By.Id("div2"))).Build().Perform();//move the mouse pointer on a perticular elememt like div2

            actions.MoveToElement(driver.FindElement(By.Id("div2")), 20, 20).Build().Perform();//move the mouse pointer on a perticular elememt like div2 of area x and y offset

            actions.MoveToElement(driver.FindElement(By.Id("div2")), 20, 20,MoveToElementOffsetOrigin.TopLeft)//move the mouse pointer on a perticular elememt like div2 of area x and y offset of a top left
             .ContextClick() // click the r/c of mouse button  
            // every action method required build and perform
             .Build()
             .Perform();
        }

        [TestMethod]
        public void ActionClick()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            Actions actions = new Actions(driver);

            //without parameter
            actions.MoveToElement(driver.FindElement(By.Name("click"))).Click().Build().Perform();//move the mouse pointer on a perticular elememt like div2 and click

            //or
            //with parameter
            actions.Click(driver.FindElement(By.Name("click"))).Build().Perform();//find the element and click
        }


        [TestMethod]
        public void ActionDoubleClick()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            Actions actions = new Actions(driver);
            //without parameter
            actions.MoveToElement(driver.FindElement(By.Name("dblClick"))).DoubleClick().Build().Perform();//move the mouse pointer on a perticular elememt like button and DoubleClick 
               //or
             //with parameter               
           actions.DoubleClick(driver.FindElement(By.Name("dblClick"))).Build().Perform();//find the element like button and DoubleClick
        }

        [TestMethod]
        public void ActionClickAndHoldAndRelease()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            Actions actions = new Actions(driver);
            //without parameter
            
            actions.MoveToElement(driver.FindElement(By.Name("one")))//move the mouse pointer on a perticular elememt  
                     .ClickAndHold() //click and hold the mouse
                     .MoveToElement(driver.FindElement(By.Name("twelve")))//move the mouse pointer on a perticular elememt
                     .Release()//relese the holding of mause 
                     .Build()
                     .Perform();
            //or
            //with parameter 

            actions.ClickAndHold(driver.FindElement(By.Name("one")))//click and hold the mouse  
                    .MoveToElement(driver.FindElement(By.Name("twelve")))//move the mouse pointer on a perticular elememt
                    .Release()//relese the holding of mause 
                    .Build()
                    .Perform();
            //or

            actions.ClickAndHold(driver.FindElement(By.Name("one")))//click and hold the mouse  
                    .Release(driver.FindElement(By.Name("twelve")))//and relese on twelve automaticaly MoveToElement this step covered  
                    .Build()
                    .Perform();
        }

        [TestMethod]
        public void ActionMoveByOffset()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            Actions actions = new Actions(driver);
            
            actions.MoveByOffset(200,200)//move the mouse pointer on a perticular elememt by passing x&y coordinate 
                   .ContextClick() // click the r/c of mouse button      
                   .Build()
                   .Perform();
        }


        [TestMethod]
        public void ActionDragAndDrop()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            Actions actions = new Actions(driver);
            //DragAndDrop (sources,target)
            actions.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable")))
                   .Build()
                   .Perform();
        }

        [TestMethod]
        public void ActionDragAndDropToOffset()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            Actions actions = new Actions(driver);
            //DragAndDrop (sources,target(x,y))
            actions.DragAndDropToOffset(driver.FindElement(By.Id("draggable")),150,20)
                   .Build()
                   .Perform();
        }

        [TestMethod]
        public void ActionKeyDownAndKeyUp()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            Actions actions = new Actions(driver);
          
            actions.KeyDown(Keys.Control) //press the control key
                   .Click(driver.FindElement(By.Name("one")))  //click on one 
                   .Click(driver.FindElement(By.Name("six")))  //click on six 
                   .Click(driver.FindElement(By.Name("eleven"))) //click on eleven 
                   .KeyUp(Keys.Control) //release the control key 
                   .Build()
                   .Perform();
        }


        [TestMethod]
        public void ActionSendKeys()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            Actions actions = new Actions(driver);
           //it will scroll the page down and scroll the page up 
            actions.SendKeys(Keys.End) //it will scroll the page down 
                   .Perform();

            Thread.Sleep(2000);

            actions.SendKeys(Keys.Home) //it will scroll the page up 
                  .Perform();
        }


        [TestMethod]
        public void ActionSendKeysOneMoreEX()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Actions";

            Actions actions = new Actions(driver);
            //SendKeys(web element,key to perform the action )
            actions.SendKeys(driver.FindElement(By.Id("click")),Keys.Enter)
                  .Perform();
        }

        [TestMethod]
        public void FillFormUsingSendKeys()
        {
            //fill entire form in a single statment using action sendkeys mehod 
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Account/Register"; //open the Url or set the Url
            Actions actions = new Actions(driver);//create a obj for action class and pass the driver
            actions.Click(driver.FindElement(By.Id("Email")))//Click on Email textbox
                .SendKeys("a@a.com" + Keys.Tab)//enter the email data and press tab for next textbox 
                .SendKeys("12345" + Keys.Tab) //enetr the data in the next texttbox and press tab
                .SendKeys("12345" + Keys.Tab) ///same 
                .Build() //build mehod (when multiple method avaialabe in a one test case the use build otherwise directly use perform)
                .Perform();
        }

        [TestMethod]
        public void ClearTextWithoutUsingClearMethod()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://ankpro.com/Account/Register"; //open the Url or set the Url
            Actions actions = new Actions(driver);//create a obj for action class and pass the driver
           driver.FindElement(By.Id("Email")).SendKeys("a@a.com");
            actions.Click(driver.FindElement(By.Id("Email")))
                   
               // ctrl + a = select all
                   .KeyDown(Keys.Control) //press ctrl
                   .SendKeys("a") //press a
                   .KeyUp(Keys.Control)//reliease contrrol 
                   .SendKeys(Keys.Backspace)//remove all 
                   .Build() //build mehod (when multiple method avaialabe in a one test case the use build otherwise directly use perform)
                   .Perform();
        }

        [TestMethod]
        public void ThreadWait()
        {
            //
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Contact"; //open the Url or set the Url
            driver.FindElement(By.PartialLinkText("This is")).Click();

           Thread.Sleep(12000);

           string result = driver.FindElement(By.ClassName("ContactUs")).Text;
            Console.WriteLine(result.Contains("Python"));
            driver.Quit();
        }

        [TestMethod]
        public void ImpilcitWait()
        {
            //
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Contact"; //open the Url or set the Url

            //here applaying the wait for entair state
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);

            driver.FindElement(By.PartialLinkText("This is")).Click();
            string result = driver.FindElement(By.ClassName("ContactUs")).Text;
            Console.WriteLine(result.Contains("Python"));
            driver.Quit();
        }

        [TestMethod]
        [Obsolete("Message")]
        public void ExplicitWait()
        {
            //
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Contact"; //open the Url or set the Url
            driver.FindElement(By.PartialLinkText("This is")).Click();

            //create the obj of web driver wait 
            //here applaying the wait for perticular state
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(12));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("ContactUs")));
                
            string result = driver.FindElement(By.ClassName("ContactUs")).Text;
            Console.WriteLine(result.Contains("Python"));
            driver.Quit();
        }

        [TestMethod]
        public void PageLoadWait()
        {
            //
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(12);

            //here it will wait 12sec to load the perticular page 
            driver.Url = "http://www.uitestpractice.com/Students/Contact"; //open the Url or set the Url
            driver.Quit();
        }

        [TestMethod]
        public void MixingImpilcitWait()
        {
            //
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Contact"; //open the Url or set the Url
             //here applaying the wait for entair state                                                             
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
            Stopwatch watch = null;
            try
            {
                watch = Stopwatch.StartNew();
                driver.FindElement(By.PartialLinkText("somethinge")).Click();

            }
            catch (Exception e)
            {
                watch.Stop();
                Console.WriteLine(e);
                Console.WriteLine(watch.ElapsedMilliseconds + "MiliSeconds");
            }
            
            driver.Quit();
        }

       // Note - allways used ExplicitWait
        [TestMethod]
        [Obsolete("Message")]//ExpectedConditions worning msg not shown so that take 
        public void MixingExplicitWait()
        {
            //
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Contact"; //open the Url or set the Url

            Stopwatch watch = null;
            try
            {
                watch = Stopwatch.StartNew();
                
                //here applaying the wait for perticular state
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(12));
                wait.Until(ExpectedConditions.ElementExists(By.ClassName("ContactUs")));

            }
            catch (Exception e)
            {
                watch.Stop();
                Console.WriteLine(e);
                Console.WriteLine(watch.ElapsedMilliseconds + "MiliSeconds");
            }

            driver.Quit();
        }


        [TestMethod]
        public void CustomExpectedCondtion()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Contact"; //open the Url or set the Url
            driver.FindElement(By.PartialLinkText("This is")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(12));

            //custome expected condtion 
            //calling the method waitFor
            wait.Until<IWebElement>(waitFor);
            string result = driver.FindElement(By.ClassName("ContactUs")).Text;
            Console.WriteLine(result);
            driver.Quit();
        }
        private IWebElement waitFor(IWebDriver driver)
        {
         IWebElement element = driver.FindElement(By.ClassName("ContactUs"));
            if (element.Displayed &&element.Enabled && element.Text.Contains("C#"))
            {
                return element;
            }
            return null;
        }



        [TestMethod]
        public void CustomExpectedCondtionUsingLambdaExprestion()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Contact"; //open the Url or set the Url
            driver.FindElement(By.PartialLinkText("This is")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(12));

            //custome expected condtion 
            wait.Until(d => {

                IWebElement element = driver.FindElement(By.ClassName("ContactUs"));
                if (element.Displayed && element.Enabled && element.Text.Contains("C#"))
                {
                    return element;
                }
                return null;
            });

            string result = driver.FindElement(By.ClassName("ContactUs")).Text;
            Console.WriteLine(result);
            driver.Quit();
        }



        [TestMethod]
        public void CustomExpectedCondtionUsingClass()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Contact"; //open the Url or set the Url
            driver.FindElement(By.PartialLinkText("This is")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(12));

            //callling the below class in the main method  
            wait.Until(CustomExpectedCondtions.WaitForElementToContainText(By.ClassName("ContactUs")));

            string result = driver.FindElement(By.ClassName("ContactUs")).Text;
            Console.WriteLine(result);
            driver.Quit();
        }

        public class CustomExpectedCondtions
        {
            public static Func<IWebDriver, bool> WaitForElementToContainText(By by)
            {
                Func<IWebDriver, bool> myCustomCondtion;
                myCustomCondtion = driver =>
                {
                    IWebElement element = driver.FindElement(by);
                    if (element != null)
                    {
                        if (element.Displayed && element.Enabled && element.Text.Contains("C#"))
                            return true;
                        else
                            return false;
                    }
                    return false;
                };
                return myCustomCondtion;
            }
        }




        [TestMethod]
        public void SimpleAlert()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //open the Url or set the Url
            driver.FindElement(By.Id("alert")).Click();
            Thread.Sleep(2000);

            string result = driver.SwitchTo().Alert().Text;
            Console.WriteLine(result);
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(2000);
            driver.Quit();
        }


        [TestMethod]
        public void PromptAlertAccept()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //open the Url or set the Url
            driver.FindElement(By.Id("prompt")).Click();
            Thread.Sleep(2000);

            driver.SwitchTo().Alert().SendKeys("prashant");
            Thread.Sleep(2000);
            //click on ok button - by using Accept();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
            driver.Quit();
        }

        [TestMethod]
        public void PromptAlertDismiss()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //open the Url or set the Url
            driver.FindElement(By.Id("prompt")).Click();
            Thread.Sleep(2000);
            driver.SwitchTo().Alert().SendKeys("prashant");
            Thread.Sleep(2000);
            //click on cancle button - by using Dismiss();
            driver.SwitchTo().Alert().Dismiss();
            Thread.Sleep(2000);
            driver.Quit();
        }



        [TestMethod]
        public void ConfirmAlertAccept()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //open the Url or set the Url
            driver.FindElement(By.Id("confirm")).Click();
            Thread.Sleep(2000);

            string result = driver.SwitchTo().Alert().Text;
            Console.WriteLine(result);
            //click on ok button - by using Accept();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
            driver.Quit();
        }

        [TestMethod]
        public void Frame()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //open the Url or set the Url
            //insert below line without this u can not entared into frame 
            driver.SwitchTo().Frame("iframe_a");

            driver.FindElement(By.Id("name")).SendKeys("abc");

            //go back to main page
            driver.SwitchTo().DefaultContent();
            Actions actions = new Actions(driver);
            actions.KeyDown(Keys.Control) //press the control key
                   .Click(driver.FindElement(By.LinkText("uitestpractice.com")))
                   .KeyUp(Keys.Control) //press the control key
                   .Build() 
                  .Perform();
             // Thread.Sleep(2000);
            //driver.Quit();
        }

        [TestMethod]
        public void MultipleWindoHandle()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            //open 1st windo
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //open the Url or set the Url
            // capure the no of open windo and id
            Console.WriteLine("Before Click");
            Console.WriteLine("No Of Windo Opened By Selenium "+driver.WindowHandles.Count);
            foreach (var item in driver.WindowHandles)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Current Window Handles " + driver.CurrentWindowHandle);

            //then click on 2nd windo
            driver.FindElement(By.LinkText("Opens in a new window")).Click();
            Console.WriteLine("After Click");
            Thread.Sleep(2000);
            //capure the no of open windo and id same as above 
            Console.WriteLine("No Of Windo Opened By Selenium " + driver.WindowHandles.Count);
            foreach (var item in driver.WindowHandles)
            {
                Console.WriteLine(item);
            }
            //when 2nd windo open as per the above code ...swich to the 2nd windo 
            driver.SwitchTo().Window(driver.WindowHandles[1]);

            //perform the operation on 2nd windo 
            string result = driver.FindElement(By.Id("draggable")).Text;
            //print the result 
            Console.WriteLine(result);
            Console.WriteLine("Current Window Handles " + driver.CurrentWindowHandle);
            Console.WriteLine("After close");
            //and close current open windo mines - 2nd windo
            driver.Close();
            //u have close one windo so capture the open windo again
            Console.WriteLine("No Of Windo Opened By Selenium " + driver.WindowHandles.Count);
            foreach (var item in driver.WindowHandles)
            {
                Console.WriteLine(item);
            }
            //switch to 1st windo 
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(2000);
            driver.Quit();
        }



        [TestMethod]
        public void ModelWindo()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //open the Url or set the Url
            //lauch model
            driver.FindElement(By.XPath("//button[contains(text(),'Launch modal')]")).Click();

            //capture the modal title text
            string modal_title_result = driver.FindElement(By.ClassName("modal-title")).Text;
            Console.WriteLine("modal title result "+ modal_title_result);
            //capture the modal body text
            string modal_body_result = driver.FindElement(By.ClassName("modal-body")).Text;
            Console.WriteLine("modal body result " + modal_body_result);
            //wait and click on close btn
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[contains(text(),'Ok')]")).Click();
           
            driver.Quit();
        }


        [TestMethod]
        public void ScreenShot()
        {
           //it will take full page screenshoot (only page)
           //image store in 
           //1) r/c on project-open folder in file explorer 2)go to bin folder 3)go to debug folder
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "https://www.selenium.dev/"; //open the Url or set the Url
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("Test.png", ScreenshotImageFormat.Png);
             driver.Quit();
        }

        [TestMethod]
        public void ScreenShotOffullWebPage()
        {
            string FileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".jpg";
            //it will take full page screenshoot (scroll page allso )
            //image store in 
            //1) r/c on project-open folder in file explorer 2)go to bin folder 3)go to debug folder
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.selenium.dev/"; //open the Url or set the Url
            VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker().RemoveScrollBarsWhileShooting());                                                         //((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("Test.png", ScreenshotImageFormat.Png);
            //plz make sure that compatablity version of Magick.NET-Q8-AnyCPU is- 7.9.1
            driver.TakeScreenshot(vcd).ToMagickImage().ToBitmap().Save(string.Format(FileName, ImageFormat.Png));
            driver.Quit();
        }

        [TestMethod]
        public void ScreenShotOfPerticularElement()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //open the Url or set the Url
            //click on bootstrap model
            driver.FindElement(By.XPath("//button[contains(text(),'Launch modal')]")).Click();
            //cl this TakeScreenshot method ...inise that pass the class name to capture only that class scrrenshot
            TakeScreenshotMethod(driver, driver.FindElement(By.ClassName("modal-content")));
        }
        

        public void TakeScreenshotMethod(IWebDriver driver,IWebElement element)
        {
            //give the file name - date + extenstion of image 
            string FileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")+".jpg";
            //take a screenshot and store into byte arry
            byte[] byteArryVariable = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            // create a obj. of bitmap - to save the memory
            Bitmap screenshoot = new Bitmap(new System.IO.MemoryStream(byteArryVariable));
            //create a obj for reactangle
            Rectangle croppedImageVariable = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
            //use the veriable of bit -screenshoot
            screenshoot = screenshoot.Clone(croppedImageVariable, screenshoot.PixelFormat);
            screenshoot.Save(string.Format(FileName,ImageFormat.Png));
        }


        [TestMethod]
        public void ScreenShotOfPerticularElementUsingExtenstionMethod()
        {
            
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //open the Url or set the Url
            //click on bootstrap model
            driver.FindElement(By.XPath("//button[contains(text(),'Launch modal')]")).Click();
            //cl this TakeScreenshot method ...inise that pass the class name to capture only that class scrrenshot
            driver.TakeScreenshotExtenstionMethodByCreatingClass(driver.FindElement(By.ClassName("modal-content")));
        }

        [TestMethod]
        public void VideoRecording()
        {
            ScreenCaptureJob scj = new ScreenCaptureJob();
            string FileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".avi";
            scj.OutputScreenCaptureFileName = @"E:\SeleniumVideoRecordingTestCase\"+ FileName;
            scj.Start();
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Switchto"; //open the Url or set the Url
            Thread.Sleep(200);
            scj.Stop();
            driver.Quit();
        }

        [TestMethod]
        public void JavaScriptDemo()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Form"; //open the Url or set the Url

            ////create a alert popup windo using JavaScript Executor
            //((IJavaScriptExecutor)driver).ExecuteScript("alert('Hello')");
            //Thread.Sleep(2000);

            ////((IJavaScriptExecutor)driver).ExecuteScript("driver.SwitchTo().Alert().Accept()");
            ////Thread.Sleep(7000);
            // driver.SwitchTo().Alert().Accept();

            //refresh the  windo using JavaScript Executor
            ((IJavaScriptExecutor)driver).ExecuteScript("history.go(0)");
            Thread.Sleep(2000);

            //check box checked using JavaScript Executor
            ((IJavaScriptExecutor)driver).ExecuteScript("document.querySelectorAll('input[value = read]')[0].click()");
            Thread.Sleep(2000);

            //again we will click it will unchecked checkbox
            ((IJavaScriptExecutor)driver).ExecuteScript("document.querySelectorAll('input[value = read]')[0].click()");
            Thread.Sleep(2000);


            //capture the inner text of the page 
            string InnerTextOfPageResult = ((IJavaScriptExecutor)driver).ExecuteScript("return document.documentElement.innerText;").ToString();
            Console.WriteLine("Inner Text Of Page Result" + InnerTextOfPageResult);
            Thread.Sleep(2000);

            //capture the Title text of the page 
            string TitleOfPageResult = ((IJavaScriptExecutor)driver).ExecuteScript("return document.title;").ToString();
            Console.WriteLine("Title Of Page Result " + TitleOfPageResult);
            Thread.Sleep(2000);

            //capture the Domain of the page 
            string DomainOfPageResult = ((IJavaScriptExecutor)driver).ExecuteScript("return document.domain;").ToString();
            Console.WriteLine("Domain Of Page Result " + DomainOfPageResult);
            Thread.Sleep(2000);


            //capture the URL of the page 
            string URLOfPageResult = ((IJavaScriptExecutor)driver).ExecuteScript("return document.URL;").ToString();
            Console.WriteLine("URL Of Page Result " + URLOfPageResult);
            Thread.Sleep(2000);


            //Scroll the page vertically for 500px
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,100)");
             Thread.Sleep(2000);

            //Scroll the page vertically tillthe end 
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
            Thread.Sleep(2000);

            //naviagte to other page 
            ((IJavaScriptExecutor)driver).ExecuteScript("window.location='http://www.uitestpractice.com/Students/Index'");
            Thread.Sleep(2000);

            //get the height of the page 
            string heightOfThePage =((IJavaScriptExecutor)driver).ExecuteScript("return window.innerHeight;").ToString();
            Console.WriteLine("Height Of The Page Result - " + heightOfThePage);
            Thread.Sleep(2000);

            //get the width of the page
            string WidthOfThePage =((IJavaScriptExecutor)driver).ExecuteScript("return window.innerWidth;").ToString();
            Console.WriteLine("Width Of The Page Result - " + WidthOfThePage);
            Thread.Sleep(2000);

            //type the text in the textbox
            ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('Search_Data').value='prashant';");
            Thread.Sleep(2000);

            driver.Quit();
        }



        [TestMethod]
        public void HiddenField()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Index"; //open the Url or set the Url
            driver.FindElement(By.XPath("//tbody//tr[2]//td[4]//button[1]")).Click();
            //get the value of hidden fields
            string result = ((IJavaScriptExecutor)driver).ExecuteScript("return document.getElementById('Id').value").ToString();
            Console.WriteLine(" hidden filed value- " + result);
        }




        [TestMethod]
        public void FirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Index"; //open the Url or set the Url
            driver.FindElement(By.XPath("//tbody//tr[2]//td[4]//button[1]")).Click();
            
        }

        [TestMethod]
        public void ChromeDriver()
        {
            IWebDriver driver = new ChromeDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Index"; //open the Url or set the Url
            //click on edit link
            driver.FindElement(By.XPath("//tbody//tr[2]//td[4]//button[1]")).Click();
            
        }

        [TestMethod]
        public void InternetExplorerDriver()
        {
            IWebDriver driver = new InternetExplorerDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Index"; //open the Url or set the Url
            //click on edit link
            driver.FindElement(By.XPath("//tbody//tr[2]//td[4]//button[1]")).Click();

        }

        [TestMethod]
        public void EdgeDriver()
        {
            IWebDriver driver = new EdgeDriver(); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Index"; //open the Url or set the Url
            //click on edit link
            driver.FindElement(By.XPath("//tbody//tr[2]//td[4]//button[1]")).Click();

        }


        //[TestMethod]
        //public void PhantomJSDrivers()
        //{
        //     IWebDriver driver = new PhantomJSDriver(); //run the borwser
        //    driver.Url = "http://www.uitestpractice.com/Students/Index"; //open the Url or set the Url
        //    click on edit link
        //    driver.FindElement(By.XPath("//tbody//tr[2]//td[4]//button[1]")).Click();

        //}

        [TestMethod]
        public void ChromeDriverHeadless()
        {
            //when the browser lounches it will lounch the browser in headless
            //ui not shown in headless mode but exixute the test case becouse of that exicution is fast
             ChromeOptions options = new ChromeOptions();
             options.AddArgument("headless");
             IWebDriver driver = new ChromeDriver(options); //run the borwser
             driver.Url = "http://www.uitestpractice.com/Students/Index";
        }

        [TestMethod]
        public void FirefoxDriverHeadless()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");
            IWebDriver driver = new FirefoxDriver(options); //run the borwser
            driver.Url = "http://www.uitestpractice.com/Students/Index";
        }

        [TestMethod]
        public void EventFiringWebDriver()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.uitestpractice.com/";
            EventFiringWebDriver eventFiringWebDriver = new EventFiringWebDriver(driver);

            //click event
            //type that eventFiringWebDriver.ElementClicking += then tab
            eventFiringWebDriver.ElementClicking += EventFiringWebDriver_ElementClicking;
            //clicked event
            eventFiringWebDriver.ElementClicked += EventFiringWebDriver_ElementClicked;

            //Element Value Changing
            eventFiringWebDriver.ElementValueChanging += EventFiringWebDriver_ElementValueChanging;
            //Element Value Changed
            eventFiringWebDriver.ElementValueChanged += EventFiringWebDriver_ElementValueChanged;

            //Navigating Event
            eventFiringWebDriver.Navigating += EventFiringWebDriver_Navigating;
            //Navigated Event
            eventFiringWebDriver.Navigated += EventFiringWebDriver_Navigated;

            //Navigating Forward
            eventFiringWebDriver.NavigatingForward += EventFiringWebDriver_NavigatingForward;
            // Navigated Forward
            eventFiringWebDriver.NavigatedForward += EventFiringWebDriver_NavigatedForward;
            // Navigating Back
            eventFiringWebDriver.NavigatingBack += EventFiringWebDriver_NavigatingBack;
            // Navigated Back
            eventFiringWebDriver.NavigatedBack += EventFiringWebDriver_NavigatedBack;

            //Script Executing Event
            eventFiringWebDriver.ScriptExecuting += EventFiringWebDriver_ScriptExecuting;
            //Script Executed Event
            eventFiringWebDriver.ScriptExecuted += EventFiringWebDriver_ScriptExecuted;

            //Exception Thrown Event
            eventFiringWebDriver.ExceptionThrown += EventFiringWebDriver_ExceptionThrown;

            //attach event to the web driver..
            driver = eventFiringWebDriver;

            //click event will trigger here 
            driver.FindElement(By.LinkText("Form")).Click();
            //event value change event here
            driver.FindElement(By.Id("firstname")).SendKeys("prashant");
            //naviagation event here 
            driver.Navigate().GoToUrl("http://www.uitestpractice.com/Students/Index");
            driver.Navigate().Back();
            driver.Navigate().Forward();

            //script exicution here
            ((IJavaScriptExecutor)driver).ExecuteScript("alert('JavaScript Executing alert popup')");
            driver.SwitchTo().Alert().Accept();

            //exception thrown event ..here test  case fail becouse of id not present 
            driver.FindElement(By.Id("NonExistantId")).Click();
           driver.Quit();
        }

        private void EventFiringWebDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Console.WriteLine("Exception Thrown Event" + e.ThrownException);
        }

        private void EventFiringWebDriver_ScriptExecuted(object sender, WebDriverScriptEventArgs e)
        {
            Console.WriteLine("Script Executed Event" + e.Script);
        }

        private void EventFiringWebDriver_ScriptExecuting(object sender, WebDriverScriptEventArgs e)
        {
            Console.WriteLine("Script Executing Event" + e.Script);
        }

        private void EventFiringWebDriver_NavigatedForward(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Element Value Navigated Forward" + e.Url);
        }

        private void EventFiringWebDriver_NavigatingForward(object sender, WebDriverNavigationEventArgs e)
        {
                Console.WriteLine("Element Value Navigating Forward" + e.Url);
        }

        private void EventFiringWebDriver_NavigatedBack(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Element Value Navigated Back" + e.Url);
        }

        private void EventFiringWebDriver_NavigatingBack(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Element Value Navigating Back" + e.Url);
        }

        private void EventFiringWebDriver_Navigated(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Element Value Navigated" + e.Url);
        }

        private void EventFiringWebDriver_Navigating(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine("Element Value Navigating" + e.Url);
        }

        private void EventFiringWebDriver_ElementValueChanged(object sender, WebElementValueEventArgs e)
        {
            Console.WriteLine("Element Value Changed" + e.Element.Text);
        }

        private void EventFiringWebDriver_ElementValueChanging(object sender, WebElementValueEventArgs e)
        {
            Console.WriteLine("Element Value Changing" + e.Element.Text);
        }

        private void EventFiringWebDriver_ElementClicked(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("Element Clicked");
        }

        private void EventFiringWebDriver_ElementClicking(object sender, WebElementEventArgs e)
        {
            Console.WriteLine("Element Clicking");
        }




        [TestMethod]
        public void HighlightElement()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.uitestpractice.com/Students/Index";
           IWebElement element = driver.FindElement(By.Id("Search_Data"));
            //Highlight the Element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px dotted blue'", element);
            Thread.Sleep(2000);
        }


        [TestMethod]
        public void HighlightElementUsingMethod()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.uitestpractice.com/Students/Index";
            IWebElement element = driver.FindElement(By.Id("Search_Data"));
            //Highlight the Element
            HighlightElementInAction(element, driver);
            Thread.Sleep(2000);
        }

        private IWebElement HighlightElementInAction(IWebElement element, IWebDriver driver)
        {
          ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px dotted blue'", element);
            return element;
        }


        [TestMethod]
        public void HighlightElementWheneverTheElementChange()
        {
            IWebDriver driver = new FirefoxDriver(); //run the borwser
            driver.Manage().Window.Maximize();
            driver.Url = "http://www.uitestpractice.com/Students/Index";

            EventFiringWebDriver eventFiringWebDriver = new EventFiringWebDriver(driver);
            //ElementClicking or ElementValueChanging ...any element value changing/clicking then 
            //EventFiringWebDriver_ElementValueChanging1
            //EventFiringWebDriver_ElementClicking1    ...   this method called
            eventFiringWebDriver.ElementClicking += EventFiringWebDriver_ElementClicking1;
            eventFiringWebDriver.ElementValueChanging += EventFiringWebDriver_ElementValueChanging1;

            driver = eventFiringWebDriver;
            driver.FindElement(By.LinkText("Create New")).Click();
            driver.FindElement(By.Id("FirstName")).SendKeys("prashant");
            driver.FindElement(By.Id("LastName")).SendKeys("pimpalkar");
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys("12/10/1999");
            driver.FindElement(By.XPath("//input[@value ='Create']")).Click();
            driver.FindElement(By.Id("Search_Data")).SendKeys("prashant");
            driver.FindElement(By.XPath("//input[@value ='Find']")).Click();

            Thread.Sleep(2000);
        }

        private void EventFiringWebDriver_ElementValueChanging1(object sender, WebElementValueEventArgs e)
        {
            //Highlight Element method called 
            HighlightElementInAction(e.Element, e.Driver);
        }

        private void EventFiringWebDriver_ElementClicking1(object sender, WebElementEventArgs e)
        {
            HighlightElementInAction(e.Element, e.Driver);
        }




        [TestMethod]
        public void VerifyFileDownload()
        {
            string expectedFilePath = @"C:\Downloads\images.png";
            bool fileExists = false;

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", @"C:\Downloads");
            var driver = new ChromeDriver(chromeOptions);

            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.SetPreference("browser.download.folderList", 2);
            firefoxOptions.SetPreference("browser.download.dir", @"C:\Downloads");
            firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "image/png");

            // mimetype
            // "application/msword, application/binary, application/ris, text/csv, image/png, application/pdf, text/html, text/plain, application/zip, application/x-zip, application/x-zip-compressed, application/download, application/octet-stream "

            //var driver = new FirefoxDriver(firefoxOptions);            

            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Widgets";
            driver.FindElement(By.XPath("//button/a")).Click();
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until<bool>(x => fileExists = File.Exists(expectedFilePath));

                Console.WriteLine("File exists : " + fileExists);

                FileInfo fileInfo = new FileInfo(expectedFilePath);

                Console.WriteLine("File Length : " + fileInfo.Length);
                Console.WriteLine("File Name : " + fileInfo.Name);
                Console.WriteLine("File Full Name :" + fileInfo.FullName);

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(1517, fileInfo.Length);
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(fileInfo.Name, "images.png");
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(fileInfo.FullName, @"C:\Downloads\images.png");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (File.Exists(expectedFilePath))
                    File.Delete(expectedFilePath);

            }
            driver.Quit();
        }


        [TestMethod]
        public void FileUpload()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Widgets";
            //C:\Users\Prashant Pimpalkar\Downloads\download.jpg
            //@ symobl is a back slash
            //click on chouse file btn and select the file 
            driver.FindElement(By.Id("image_file")).SendKeys(@"C:\Users\Prashant Pimpalkar\Downloads\download.jpg");
            //click on upload btn 
            driver.FindElement(By.XPath("//input[@value = 'Upload']")).Click();
            Thread.Sleep(4000);
            driver.Quit();
        }





        [TestMethod]
        public void HandleInvalidSSLCertificateError()
        {
            //ChromeOptions chromeOptions = new ChromeOptions();
            //chromeOptions.AcceptInsecureCertificates = true;

            FirefoxOptions firefoxOptions = new FirefoxOptions();

            //if it false then it is not all the bad expierd sertificate webiside,bad host name webiside,outdated algotidam webside 
            firefoxOptions.AcceptInsecureCertificates = true;

            IWebDriver driver = new FirefoxDriver(firefoxOptions);
            driver.Manage().Window.Maximize();
            driver.Url = "https://expired.badssl.com/";

            Console.WriteLine(driver.FindElement(By.Id("content")).Text);
            Thread.Sleep(2000);
            driver.Quit();
        }




       
            [TestMethod]
            //exicuting 3 time for 3 data set 
            [DataRow("Narendra", "Modi", "01/01/2019")]//1st latter upper case
            [DataRow("donald", "trump", "07/01/2020")]//all are lower case 
            [DataRow("BORIS", "JOHNSON", "12/31/2021")]//all are capital latter 
            public void DataDrivenTestingUsingDataRow(string fName, string lName, string eDate)
            {
                IWebDriver driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Url = "http://uitestpractice.com/Students/Create";

                driver.FindElement(By.Id("FirstName")).SendKeys(fName);
                driver.FindElement(By.Id("LastName")).SendKeys(lName);
                driver.FindElement(By.Id("EnrollmentDate")).SendKeys(eDate);
                driver.FindElement(By.XPath("//input[@type='submit']")).Click();

                driver.Quit();
            }



            [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
            [TestMethod]
            public void DataDrivenTestingUsingDynamicData(string fName, string lName, string eDate)
            {
                IWebDriver driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Url = "http://uitestpractice.com/Students/Create";

                driver.FindElement(By.Id("FirstName")).SendKeys(fName);
                driver.FindElement(By.Id("LastName")).SendKeys(lName);
                driver.FindElement(By.Id("EnrollmentDate")).SendKeys(eDate);
                driver.FindElement(By.XPath("//input[@type='submit']")).Click();

                driver.Quit();
            }

            public static IEnumerable<object[]> GetData()
            {
                yield return new object[] { "Narendra", "Modi", "01/01/2019" };
                yield return new object[] { "donald", "trump", "07/01/2020" };
                yield return new object[] { "BORIS", "JOHNSON", "12/31/2021" };
            }






        public static IEnumerable <object[]> ReadExcel()
        {
            //creating the worksheet object
            using (ExcelPackage package = new ExcelPackage(new FileInfo("Data.xlsx")))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int rowCount = worksheet.Dimension.End.Row;     //get row count..count the no of row
                for (int row = 2; row <= rowCount; row++)
                {
                    yield return new object[] {
                        worksheet.Cells[row, 1].Value?.ToString().Trim(), // First name
                        worksheet.Cells[row, 2].Value?.ToString().Trim(), // Last name
                        worksheet.Cells[row, 3].Value?.ToString().Trim()  // Enrollment date
                    };
                }
            }
        }

        //Test method code:
        // cl here ReadExcel method
        [DynamicData(nameof(ReadExcel), DynamicDataSourceType.Method)]
        [TestMethod]
        public void DataDrivenTestingUsingExcelSheet(string fName, string lName, string eDate)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";

            driver.FindElement(By.Id("FirstName")).SendKeys(fName);
            driver.FindElement(By.Id("LastName")).SendKeys(lName);
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys(eDate);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            driver.Quit();
        }


        public TestContext TestContext { get; set; }
        //data acess from -data sources name ,location of the file,table name,dataacess method name
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data.csv", "data#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void DataDrivenTestingUsingCSVFile()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";

            driver.FindElement(By.Id("FirstName")).SendKeys(TestContext.DataRow[0].ToString());
            driver.FindElement(By.Id("LastName")).SendKeys(TestContext.DataRow[1].ToString());
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys(TestContext.DataRow[2].ToString());
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            Thread.Sleep(2000);
            driver.Quit();
        }



        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\Data.xml", "user", DataAccessMethod.Sequential)]
        [TestMethod]
        public void DataDrivenTestingUsingXMLFile()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";

            driver.FindElement(By.Id("FirstName")).SendKeys(TestContext.DataRow[0].ToString());
            driver.FindElement(By.Id("LastName")).SendKeys(TestContext.DataRow[1].ToString());
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys(TestContext.DataRow[2].ToString());
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            Thread.Sleep(2000);
            driver.Quit();
        }



        //connection string for server
        //[DataSource("System.Data.SqlClient","Server=.\\SQLExpress; Database=DataDrivenTesting;User Id=sa; Password=Ankpro01*","Student", DataAccessMethod.Sequential)]

        //connection string for local
        //tablename - Student 
        [DataSource("System.Data.SqlClient", "Server=.\\PRASHANT; Database=SeleniumWitnC#UsingDataDrivenTesting;User Id=sa; Password=1234567890", "Student", DataAccessMethod.Sequential)]

        [TestMethod]
        public void DataDrivenTestingUsingSQL()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://uitestpractice.com/Students/Create";

            driver.FindElement(By.Id("FirstName")).SendKeys(TestContext.DataRow[0].ToString().Trim());
            driver.FindElement(By.Id("LastName")).SendKeys(TestContext.DataRow[1].ToString().Trim());
            driver.FindElement(By.Id("EnrollmentDate")).SendKeys(TestContext.DataRow[2].ToString());
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            Thread.Sleep(5000);
            driver.Quit();
        }





        //undustanding of Assert Concepts
        [TestMethod]
        public void UndustandingOfAssertConcepts_1()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.irctc.co.in");
            try
            {
                Console.WriteLine(driver.Title);
                Assert.AreEqual("IRCTC Next Generation eTicketing System", driver.Title);

                
                Console.WriteLine("Assertion AreEqual Method pass");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Assertion AreEqual Method are not pass " + ex);
            }
            driver.Quit();
        }

        [TestMethod]
        public void UndustandingOfAssertConcepts_2()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Index");
            try
            {
                //Assert.IsTrue(driver.FindElement(By.ClassName("btn btn-info")).Displayed);
                //Compound class names not permitted it mines that 2class name so we can used xpath and pass the name of classes 
                Assert.IsTrue(driver.FindElement(By.XPath("//*[@class='btn btn-info']")).Displayed);
                Console.WriteLine("btn display and Assertion IsTrue Method pass");
            }
            catch (Exception ex)
            {
                Console.WriteLine("btn display and Assertion IsTrue Method are not pass " + ex);
            }
            driver.Quit();
        }

        [TestMethod]
        public void UndustandingOfAssertConcepts_3()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Form");
            driver.FindElement(By.XPath(".//input[@type='checkbox' and @value='read']")).Click();  // not function in xpath -if attribute not contain checked then click 
            Thread.Sleep(2000);
            try
            {
                //checkbox selected or not
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(driver.FindElement(By.XPath(".//input[@type='checkbox' and @value='read']")).Selected);
                Console.WriteLine("checkbox Selected and Assertion IsTrue Method pass");
            }
            catch (Exception ex)
            {
                Console.WriteLine("checkbox not Selected and Assertion IsTrue Method are pass " + ex);
            }
            driver.Quit();
        }


        //logger -------it is used to replasing Console.WriteLine by using logger ---------------

        
       
        //write log in our test cases 
       
        [TestMethod]
        public void BasicConfigurationOfLogger()
        {
            //configure the log4net 
            BasicConfigurator.Configure();
            //creating a logger
            ILog logger = LogManager.GetLogger(typeof(SeleniumBasic));//file name 

            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            string StudentFormurl = "http://uitestpractice.com/Students/Form";
            driver.Navigate().GoToUrl(StudentFormurl);
            logger.Debug("Navigating to url"+ StudentFormurl);

            logger.Info("click to checkbox where value is Reading..");
            driver.FindElement(By.XPath(".//input[@type='checkbox' and @value='read']")).Click();  // not function in xpath -if attribute not contain checked then click 
          
            logger.Debug("waiting for 200 sec");
            Thread.Sleep(200);
            try
            {
                //checkbox selected or not
                Assert.IsTrue(driver.FindElement(By.XPath(".//input[@type='checkbox' and @value='read']")).Selected);
                logger.Info("checkbox checked as well as Selected and Assertion IsTrue Method pass");
            }
            catch (Exception ex)
            {
                logger.Debug("checkbox not Selected and Assertion IsTrue Method are pass " + ex);
            }
            logger.Info("close the browser");
            driver.Quit();
        }





        [TestMethod]
        public void AdvanceConfigurationOfLogger()
        {
            //configure the log4net by using app.config file
            XmlConfigurator.Configure();
            //creating a logger
            ILog logger = LogManager.GetLogger(typeof(SeleniumBasic));//file name 

            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            string StudentFormurl = "http://uitestpractice.com/Students/Form";
            driver.Navigate().GoToUrl(StudentFormurl);
            logger.Debug("Navigating to url" + StudentFormurl);

            logger.Info("click to checkbox where value is Reading..");
            driver.FindElement(By.XPath(".//input[@type='checkbox' and @value='read']")).Click();  // not function in xpath -if attribute not contain checked then click 

            logger.Debug("waiting for 200 sec");
            Thread.Sleep(200);
            try
            {
                //checkbox selected or not
                Assert.IsTrue(driver.FindElement(By.XPath(".//input[@type='checkbox' and @value='read']")).Selected);
                logger.Info("checkbox checked as well as Selected and Assertion IsTrue Method pass");
            }
            catch (Exception ex)
            {
                logger.Debug("checkbox not Selected and Assertion IsTrue Method are pass " + ex);
            }
            logger.Info("close the browser");
            driver.Quit();
        }

        
    }



    static class Utils
    {
        public static void TakeScreenshotExtenstionMethodByCreatingClass(this IWebDriver driver, IWebElement element)
        {
            //give the file name - date + extenstion of image 
            string FileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".jpg";
            //take a screenshot and store into byte arry
            byte[] byteArryVariable = ((ITakesScreenshot)driver).GetScreenshot().AsByteArray;
            // create a obj. of bitmap - to save the memory
            Bitmap screenshoot = new Bitmap(new System.IO.MemoryStream(byteArryVariable));
            //create a obj for reactangle
            Rectangle croppedImageVariable = new Rectangle(element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
            //use the veriable of bit -screenshoot
            screenshoot = screenshoot.Clone(croppedImageVariable, screenshoot.PixelFormat);
            screenshoot.Save(string.Format(FileName, ImageFormat.Png));
        }
    }





}
