using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace FusionTestFramework.src.Playwright
{    
public class PlaywrightProxySetup
    {
        public static async Task<IPage> InitializePageWithProxyAsync()
        {
            var playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Proxy = new Proxy
                {
                    Server = "http://localhost:8080" // Replace with your proxy address
                }
            });

            return await browser.NewPageAsync();
        }
    }
}
