using Microsoft.Playwright;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionTestFramework.src.Core
{
    public class TestManager
    {
        private IWebDriver seleniumDriver;
        private IPage playwrightPage;

        public TestManager(IWebDriver seleniumDriver, IPage playwrightPage)
        {
            this.seleniumDriver = seleniumDriver;
            this.playwrightPage = playwrightPage;
        }

        public void ExecuteStep(string stepType, Locator locator, string value)
        {
            switch (stepType.ToLower())
            {
                case "navigation":
                    seleniumDriver.Navigate().GoToUrl(value);
                    break;

                case "interaction":
                    // Use Playwright for interaction
                    playwrightPage.Locator(locator.Value).FillAsync(value).Wait();
                    break;

                default:
                    throw new ArgumentException("Invalid step type");
            }
        }
    }
}
