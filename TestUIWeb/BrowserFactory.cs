using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUIWeb
{
    public static class BrowserFactory
    {
        public static IWebDriver GetWebDriver(int x)
        {

            if (x == 2) return new FirefoxDriver();
            if (x == 3) return new InternetExplorerDriver();
            return new ChromeDriver();

        }
    }
}
