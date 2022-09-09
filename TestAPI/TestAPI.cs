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
    [Parallelizable(ParallelScope.All)]
    public partial class TestAPI
    {
        const string api = "https://fg1ap986e9.execute-api.eu-west-1.amazonaws.com/Dev";

        [SetUp]
        public void SetUp()
        {
        }
    }
}
