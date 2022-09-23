using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftekTest
{
    [TestFixture]    
    public class ApiTest
    {
        internal const string apiUri = "https://fg1ap986e9.execute-api.eu-west-1.amazonaws.com/Dev";

        [SetUp]
        public void SetUp()
        {
        }
    }
}
