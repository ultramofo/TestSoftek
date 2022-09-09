using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace TestSoftek
{
    public partial class TestAPI
    {
        [Test]
        public async Task TestDiscountCalculation()
        {
            bool discountCalculated = false;
            var promoCode = "myPromoCode";

            int targetDiscount = promoCode.Length;
            string url = $"{api}/coupon?coupon={promoCode}";

            var client = new HttpClient();

            TestContext.WriteLine("Checking discount percent calculation..");

            using (var message = new HttpRequestMessage(HttpMethod.Post, url))
            {
                using (HttpResponseMessage resp = await client.SendAsync(message))
                {
                    try
                    {
                        string response = await resp.Content.ReadAsStringAsync();
                        TestContext.WriteLine(response);

                        JObject obj = JObject.Parse(response);
                        var discount = obj["discount"].Value<int>();
                        if (discount == targetDiscount)
                        {
                            discountCalculated = true;
                        }
                        else
                        {
                            TestContext.WriteLine($"{targetDiscount} != {discount}");
                        }
                    }
                    catch (Exception e)
                    {
                        TestContext.WriteLine(e.Message);
                    }
                }
            }

            Assert.IsTrue(discountCalculated, "Incorrect discount!");
        }
    }
}
