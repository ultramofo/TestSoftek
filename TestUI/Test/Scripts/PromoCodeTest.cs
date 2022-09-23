using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SoftekTest.TestUI.Src.Pages;
using System.Diagnostics;
using System.Globalization;
using static System.Net.WebRequestMethods;

namespace SoftekTest.TestUI.Test.Scripts
{
    [Parallelizable(ParallelScope.All)]
    public class PromoCodeTest : UiTest
    {
        [Test]
        public void DiscountTest()
        {
            CheckoutForm checkoutForm = new CheckoutForm(driver);

            var promoCode = "myPromoCode";
            float discount = (float)(100 - promoCode.Length) / 100;

            bool promoCodeWorking = false;

            TestContext.WriteLine("Checking promo code..");

            try
            {
                driver.Url = checkoutFormUri;
                
                float price = float.Parse(checkoutForm.totalPrice.Text, CultureInfo.InvariantCulture.NumberFormat);
                float newPrice = price * discount;             
                checkoutForm.promoInput.SendKeys(promoCode);            
                checkoutForm.redeemButton.Click();
                Thread.Sleep(500); // waiting for price field refresh
                price = float.Parse(checkoutForm.totalPrice.Text, CultureInfo.InvariantCulture.NumberFormat);
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