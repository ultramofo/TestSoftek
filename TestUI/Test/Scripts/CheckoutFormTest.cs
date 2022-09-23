using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SoftekTest.TestUI.Src.Pages;
using static System.Net.WebRequestMethods;

namespace SoftekTest.TestUI.Test.Scripts
{
    [Parallelizable(ParallelScope.All)]
    public class CheckoutFormTest : UiTest
    {
        [Test]
        public void TestMandatoryFields()
        {
            CheckoutForm checkoutForm = new CheckoutForm(driver);

            bool firstNameDisplayed = false;
            bool lastNameDisplayed = false;
            bool nameOnCardDisplayed = false;
            bool creditCardNumberDisplayed = false;
            bool expirationDisplayed = false;
            bool cvvDisplayed = false;

            TestContext.WriteLine("Checking error descriptions of mandatory fields..");

            try
            {
                driver.Url = checkoutFormUri;

                checkoutForm.CheckoutButton.Click();

                if (checkoutForm.FirstNameError.Displayed) firstNameDisplayed = true;
                if (checkoutForm.LastNameError.Displayed) lastNameDisplayed = true;
                if (checkoutForm.NameOnCardError.Displayed) nameOnCardDisplayed = true;
                if (checkoutForm.CreditCardNumberError.Displayed) creditCardNumberDisplayed = true;
                if (checkoutForm.ExpirationError.Displayed) expirationDisplayed = true;
                if (checkoutForm.CvvError.Displayed) cvvDisplayed = true;
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