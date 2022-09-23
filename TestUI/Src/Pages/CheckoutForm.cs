using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SoftekTest.TestUI.Test.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftekTest.TestUI.Src.Pages
{
    public class CheckoutForm
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public CheckoutForm(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }
        public CheckoutForm(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public IWebElement CheckoutButton => driver.FindElement(By.XPath("//button[contains(text(), 'Continue to checkout')]"));

        public IWebElement FirstNameError => driver.FindElement(By.XPath("//label[contains(text(), 'First name')]/../div[@class='invalid-feedback']"));
        public IWebElement LastNameError => driver.FindElement(By.XPath("//label[contains(text(), 'Last name')]/../div[@class='invalid-feedback']"));
        public IWebElement NameOnCardError => driver.FindElement(By.XPath("//label[contains(text(), 'Name on card')]/../div[@class='invalid-feedback']"));
        public IWebElement CreditCardNumberError => driver.FindElement(By.XPath("//label[contains(text(), 'Credit card number')]/../div[@class='invalid-feedback']"));
        public IWebElement ExpirationError => driver.FindElement(By.XPath("//label[contains(text(), 'Expiration')]/../div[@class='invalid-feedback']"));
        public IWebElement CvvError => driver.FindElement(By.XPath("//label[contains(text(), 'CVV')]/../div[@class='invalid-feedback']"));

        
        public IWebElement totalPrice => wait.Until(driver => driver.FindElement(By.XPath("//*[@id='totalAmount' and text() != '']")));
        public IWebElement promoInput => driver.FindElement(By.XPath("//input[@id='promoCode']"));
        public IWebElement redeemButton => driver.FindElement(By.XPath("//button[contains(text(), 'Redeem')]"));

    }
}
