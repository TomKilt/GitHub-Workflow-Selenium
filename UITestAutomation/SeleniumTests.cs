using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITestAutomation
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        [Test]
        public void TestBbcUrl()
        {
            var options = new ChromeOptions();

            options.AddArguments("--no-sandbox"); //Bypass OS security model   
            options.AddArguments("--start-maximized");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--headless");

            driver = new ChromeDriver(options);
            var navigate = driver.Navigate();

            var bbcScotlandUrl = "https://www.bbc.co.uk/scotland";
            bbcScotlandUrl = "https://www.bbc.com/scotland";
            var bbcUrl = "https://www.bbc.co.uk/";

            navigate.GoToUrl(bbcScotlandUrl);

            driver.Url.Should().Be(bbcScotlandUrl, "URL is not BBC Scotland");
            //driver.FindElement(By.XPath("//button[text()='Yes, I agree']")).Click();
            //var b = driver.FindElements(By.CssSelector("a[href='https://www.bbc.co.uk']"));

            //b[0].Click();
            //driver.Url.Should().Be(bbcUrl, "URL is not BBC");
        }
    }
}