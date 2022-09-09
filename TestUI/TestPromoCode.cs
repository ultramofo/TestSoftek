using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Globalization;
using static System.Net.WebRequestMethods;

namespace TestSoftek
{
    public partial class TestUI
    {
        [Test]
        public void TestPromoCode()
        {
            var promoCode = "myPromoCode";
            float discount = (float)(100 - promoCode.Length) / 100;

            bool promoCodeWorking = false;

            TestContext.WriteLine("Checking promo code..");

            try
            {
                driver.Url = checkoutForm;
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                IWebElement totalPrice = wait.Until(driver => driver.FindElement(By.XPath("//*[@id='totalAmount' and text() != '']")));
                float price = float.Parse(totalPrice.Text, CultureInfo.InvariantCulture.NumberFormat);
                float newPrice = price * discount;
                IWebElement promoInput = driver.FindElement(By.XPath("//input[@id='promoCode']"));
                promoInput.SendKeys(promoCode);
                IWebElement redeemButton = driver.FindElement(By.XPath("//button[contains(text(), 'Redeem')]"));
                redeemButton.Click();
                Thread.Sleep(500); // waiting for price field refresh
                price = float.Parse(totalPrice.Text, CultureInfo.InvariantCulture.NumberFormat);
                if (price == newPrice)
                {
                    promoCodeWorking = true;
                }
                else
                {
                    TestContext.WriteLine($"{price} != {newPrice}");
                }
            }
            catch (Exception e)
            {
                TestContext.WriteLine(e.Message);
            }

            Assert.IsTrue(promoCodeWorking, "Promo code is not working!");

            TestContext.WriteLine("success");
        }
    }
}