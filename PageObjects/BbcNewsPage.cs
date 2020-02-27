using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BbcTestProject.PageObjects
{

    class BbcNewsPage : BasePage
    {

        [FindsBy(How = How.XPath, Using = "//div//div[1]/div/div/div[1]/div/a/h3")]
        private IWebElement MainMewsTitle { get; set; }


        [FindsBy(How = How.CssSelector, Using = "div.nw-c-top-stories__secondary-item a.gs-c-promo-heading h3")]
        private IList<IWebElement> SecondaryNewsTitles { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.nw-c-top-stories-primary__story a.gs-c-section-link span")]
        private IWebElement MainMewsCategoryLink { get; set; }

        [FindsBy(How = How.Id, Using = "orb-search-q")]
        private IWebElement SearchField { get; set; }

        [FindsBy(How = How.Id, Using = "orb-search-button")]
        private IWebElement SearchButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".nw-o-news-wide-navigation .nw-c-nav__wide-morebutton")]
        private IWebElement MoreButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".nw-c-nav__wide-overflow ul li a")]
        private IList<IWebElement> MoreSectionLinks { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".nw-c-nav__wide-overflow ul li a span")]
        private IList<IWebElement> MoreSectionLinksTitles { get; set; }

        public BbcNewsPage(IWebDriver driver)
           : base(driver) { }

        public BbcHaveYouSayPage GoToHaveYouSayPage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            MoreButton.Click();
            for (int i = 0; i < MoreSectionLinks.Count; i++)
            {
                //string.Format(LinkWithText, my text)
                if (MoreSectionLinksTitles[i].Text == "Have Your Say")
                {
                    MoreSectionLinks[i].Click();
                    break;
                }
            }
            return new BbcHaveYouSayPage(driver);
        }

        public void SearchValue(string value)
        {
            SearchField.Clear();
            SearchField.SendKeys(value);
            SearchButton.Click();
        }


        public string GetMainNewsCategory()
        {
            return MainMewsCategoryLink.Text;
        }

        public string GetMainNewsTitleText()
        {
            return MainMewsTitle.Text;
        }
        public List<string> GetSeconaryTitleText()
        {
            List<string> titles = new List<string>();
            for (int i = 0; i < SecondaryNewsTitles.Count; i++)
            {
                titles.Add(SecondaryNewsTitles[i].Text);
            }
            return titles;
        }

    }
}
