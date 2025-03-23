using NUnit.Framework;
using OpenQA.Selenium;
using Microsoft.Playwright;
using FusionTestFramework.src.Selenium;
using FusionTestFramework.src.Playwright;

namespace FusionTestFramework.Tests
{
    [TestFixture]
    public class IntegrationTests
    {
        private IWebDriver? seleniumDriver;
        private IPage? playwrightPage;

        [SetUp]
        public async Task Setup()
        {
            try
            {
                // Initialize tools
                seleniumDriver = SeleniumProxySetup.InitializeDriverWithProxy();
                playwrightPage = await PlaywrightProxySetup.InitializePageWithProxyAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Setup failed: {ex.Message}");
                throw;
            }
        }

        [Test]
        public async Task TestNavigationAndInteraction()
        {
            // Step 1: Use Selenium for navigation
            seleniumDriver!.Navigate().GoToUrl("https://example.com");
            Assert.That(seleniumDriver.Url, Is.EqualTo("https://example.com"));

            // Step 2: Use Playwright for form filling
            await playwrightPage!.GotoAsync("https://example.com");
            await playwrightPage.FillAsync("#username", "testuser");
            await playwrightPage.ClickAsync("#submit");

            Assert.Pass("Navigation and interaction completed successfully.");
        }

        [TearDown]
        public async Task Cleanup()
        {
            try
            {
                seleniumDriver?.Quit();
                if (playwrightPage?.Context?.Browser != null)
                {
                    await playwrightPage.Context.Browser.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cleanup failed: {ex.Message}");
                throw;
            }
        }
    }
}



