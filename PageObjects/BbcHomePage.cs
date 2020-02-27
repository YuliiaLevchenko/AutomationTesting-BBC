using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace BbcTestProject.PageObjects
{

    class BbcHomePage : BasePage
    {
        public BbcHomePage(IWebDriver driver)
            : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//div[@id='orb-nav-links']//li/a[text()='News']")]
        private IWebElement NewsButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='orb-nav-links']//li/a[text()='Sport']")]
        private IWebElement SportButton { get; set; }


        public BbcHomePage GoToPage()
        {
            driver.Navigate().GoToUrl("http://bbc.com");
            return new BbcHomePage(driver);
        }

        public BbcNewsPage GoToNewsPage()
        {
            NewsButton.Click();
            return new BbcNewsPage(driver);
        }

        public BbcSportPage GoToSportPage()
        {
            SportButton.Click();
            return new BbcSportPage(driver);
        }


    }
}
