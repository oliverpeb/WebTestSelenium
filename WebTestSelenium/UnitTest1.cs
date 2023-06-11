using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebTestSelenium

{
    [TestClass]
    public class SeleniumTest
    {

        private static readonly string DriverDirectory = "C:\\Users\\ofh8\\Webdrivers";

        private static IWebDriver _driver;


        [ClassInitialize]
        public static void setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
            //_driver = new FirefoxDriver(DriverDirectory);
            //_driver = new EdgeDriver(DriverDirectory);
            // Driver file must be renamed to MicrosoftWebDriver.exe OR msedgedriver.exe
            // depending on the version of Selenium?
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void TestMethod()
        {
            string url = "https://stringmanipulationoliver.azurewebsites.net";
            _driver.Navigate().GoToUrl(url);

            Assert.AreEqual("Document", _driver.Title);

            IWebElement inputElement = _driver.FindElement(By.TagName("input"));
            inputElement.SendKeys("hello");

            IWebElement buttonElement = _driver.FindElement(By.TagName("button"));
            buttonElement.Click();

            IList<IWebElement> tableCells = _driver.FindElements(By.XPath("//table//tr//td"));

            string firstTableCell = tableCells[0].Text;
            string secondTableCell = tableCells[1].Text;
            string thirdTableCell = tableCells[2].Text;
            // ... and so on for all the cells

            Assert.AreEqual("hello", firstTableCell, "First table cell is not as expected.");
            Assert.AreEqual("hello", secondTableCell.ToLower(), "Second table cell is not as expected.");
            Assert.AreEqual("HELLO", thirdTableCell, "Third table cell is not as expected.");


        }


    }
}