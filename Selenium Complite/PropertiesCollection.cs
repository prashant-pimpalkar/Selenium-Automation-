using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Complite
{
    class PropertiesCollection
    {
        //created auto implimented property
        public static IWebDriver driver { get; set; }
       
    }

    enum Elementtype
    {
        Id,
        Name,
        ClassName
    }
}
