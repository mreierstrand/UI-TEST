using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UserInterfaceTest
{
    [TestClass]
    public class UnitTest1
    {
        private static string driverFolder = "C:\\SeleniumDrivers";
        private static IWebDriver _webDriver;

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _webDriver = new ChromeDriver(driverFolder);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _webDriver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _webDriver.Navigate().GoToUrl("http://localhost:3000/");
            string Title =  _webDriver.Title;
            Assert.AreEqual("Coding Template", Title);

            IWebElement inputElementWordInput = _webDriver.FindElement(By.Id("wordInput"));
            inputElementWordInput.SendKeys("Oliver");
            IWebElement inputElementButton = _webDriver.FindElement(By.Id("saveButton"));
            inputElementButton.Click();

            IWebElement inputElementShowButton = _webDriver.FindElement(By.Id("showButton"));
            inputElementShowButton.Click();

            IWebElement outputElement = _webDriver.FindElement(By.Id("Output"));
            string text = outputElement.Text;

            Assert.AreEqual("Oliver", text);
        }
    }
}
