using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Complite
{
    public enum BrowerType
    {
        Firefox,
        Chrome,
        IE,
        Edge
    }


    [TestFixture]
    public class Hooks : BaseClassForParallelyTestExecution
    {
        //INITILIZE THE DRIVER OBJECT HERE 
        private BrowerType _browerType;//_this is a local veriable browerType
        public Hooks(BrowerType brower)
        {
            //set the value for local veriable ie _browerType
            _browerType = brower;
            // Driver = new FirefoxDriver();

        }

        [SetUp]
        public void InitializeTest()
        {
            chooseBrowser(_browerType);
        }

        private void chooseBrowser(BrowerType browerType)
        {
            if (browerType == BrowerType.Chrome)
            {
                Driver = new ChromeDriver();
            }
            else if (browerType == BrowerType.Firefox)
            {
                Driver = new FirefoxDriver();
            }
            else if (browerType == BrowerType.IE)
            {
                Driver = new InternetExplorerDriver();
            }
            else if (browerType == BrowerType.Edge)
            {
                Driver = new EdgeDriver();
            }
        }

        internal void SelectBrowser(BrowerType browerType)
        {
            switch (browerType)
            {
                case BrowerType.Chrome:

                    //ChromeOptions options = new ChromeOptions();
                    //options.AddArgument("headless");
                    //_driver = new ChromeDriver(options);
                    //_objectContainer.RegisterInstanceAs<IWebDriver>(_driver);

                    break;
                case BrowerType.Firefox:
                    //var driverDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(driverDir, "geckodriver.exe");
                    //service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                    //service.HideCommandPromptWindow = true;
                    //service.SuppressInitialDiagnosticInformation = true;
                    //_driver = new FirefoxDriver(service);
                    //_objectContainer.RegisterInstanceAs<RemoteWebDriver>(_driver);
                    break;
                case BrowerType.IE:
                    break;
                case BrowerType.Edge:
                    break;
                default:
                    break;
            }
        }


            
        










    }


}
