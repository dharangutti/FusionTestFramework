using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FusionTestFramework.src.Selenium
{
    public class SeleniumProxySetup
    {
        public static IWebDriver InitializeDriverWithProxy()
        {
            var proxy = new OpenQA.Selenium.Proxy
            {
                HttpProxy = "localhost:8080", // Replace with your proxy address
                SslProxy = "localhost:8080"
            };

            var options = new ChromeOptions();
            options.Proxy = proxy;

            return new ChromeDriver(options);
        }
    }
}
