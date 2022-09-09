using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSoftek
{
    [TestFixture]
    public partial class TestUI
    {
        IWebDriver driver;

        const string checkoutForm = "https://qaautomation-test.s3-eu-west-1.amazonaws.com/index.html";

        [SetUp]
        public void StartBrowser()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            // options.AddArguments("--window-size=1600,1000");
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
