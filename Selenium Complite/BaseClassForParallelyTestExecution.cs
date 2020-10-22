using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Complite
{
  public  class BaseClassForParallelyTestExecution
    {
        //hold the driver property which which will be used across the framwork
        public  IWebDriver Driver { get; set; }
    }
}
