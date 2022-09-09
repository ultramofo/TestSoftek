using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;

namespace TestSoftek
{
    public partial class TestUI
    {
        [Test]
        public void TestMandatoryFields()
        {
            bool firstNameDisplayed = false;
            bool lastNameDisplayed = false;
            bool nameOnCardDisplayed = false;
            bool creditCardNumberDisplayed = false;
            bool expirationDisplayed = false;
            bool cvvDisplayed = false;
            TestContext.WriteLine("Checking error descriptions of mandatory fields..");
            try
            {
                driver.Url = checkoutForm;
                IWebElement element = driver.FindElement(By.XPath("//button[contains(text(), 'Continue to checkout')]"));
                element.Click();
                if (driver.FindElement(By.XPath("//label[contains(text(), 'First name')]/../div[@class='invalid-feedback']")).Displayed) firstNameDisplayed = true;
                if (driver.FindElement(By.XPath("//label[contains(text(), 'Last name')]/../div[@class='invalid-feedback']")).Displayed) lastNameDisplayed = true;
                if (driver.FindElement(By.XPath("//label[contains(text(), 'Name on card')]/../div[@class='invalid-feedback']")).Displayed) nameOnCardDisplayed = true;
                if (driver.FindElement(By.XPath("//label[contains(text(), 'Credit card number')]/../div[@class='invalid-feedback']")).Displayed) creditCardNumberDisplayed = true;
                if (driver.FindElement(By.XPath("//label[contains(text(), 'Expiration')]/../div[@class='invalid-feedback']")).Displayed) expirationDisplayed = true;
                if (driver.FindElement(By.XPath("//label[contains(text(), 'CVV')]/../div[@class='invalid-feedback']")).Displayed) cvvDisplayed = true;
            }
            catch (Exception e)
            {
                TestContext.WriteLine(e.Message);
            }
            Assert.Multiple(() =>
            {
                Assert.IsTrue(firstNameDisplayed, "Error description of the 'First name' field is not visible");
                Assert.IsTrue(lastNameDisplayed, "Error description of the 'Last name' field is not visible");
                Assert.IsTrue(nameOnCardDisplayed, "Error description of the 'Name on card' field is not visible");
                Assert.IsTrue(creditCardNumberDisplayed, "Error description of the 'Credit card number' field is not visible");
                Assert.IsTrue(expirationDisplayed, "Error description of the 'Expiration' field is not visible");
                Assert.IsTrue(cvvDisplayed, "Error description of the 'CVV' field is not visible");
            });
            TestContext.WriteLine("success");
        }
    }
}