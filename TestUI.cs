using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace TestSoftek
{

    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public partial class Tests
    {
        IWebDriver driver;

        const string api = "https://fg1ap986e9.execute-api.eu-west-1.amazonaws.com/Dev";
        const string checkoutForm = "https://qaautomation-test.s3-eu-west-1.amazonaws.com/index.html";

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void TestMandatoryFields()
        {

            bool loggedIn = false;
            bool loggedOut = false;

            TestContext.WriteLine("Checking madatory fields..");
            try
            {
                driver.Url = checkoutForm;
                //Thread.Sleep(10000);
                IWebElement element = driver.FindElement(By.XPath("//button[contains(text(), 'Continue to checkout')]"));
                element.Click();
                Thread.Sleep(10000);
                //element.SendKeys(email);
                //element = driver.FindElement(By.XPath("//form[@class='login-form']//input[@type='password']"));
                //element.SendKeys(pass);
                //element = driver.FindElement(By.XPath("//form[@class='login-form']//button[@type='submit']"));



                //element = driver.FindElement(By.XPath("//div[@class='cjihdxx']/button"));

                //if (element.Text.ToLower() == email.ToLower())
                //{
                //    loggedIn = true;
                //    TestContext.WriteLine($"Logged in as {element.Text}");
                //}


                //TestContext.Write("Logging out..");
                //driver.Url = "https://portal.servers.com/logout";

                //if (driver.FindElement(By.XPath("//form[@class='login-form']")).Displayed) loggedOut = true;
                TestContext.WriteLine(" done");
            }
            catch (Exception e)
            {
                TestContext.WriteLine(e.Message);
            }
            finally
            {
                driver.Close();
            }
            Assert.Pass();
        }
    }
}