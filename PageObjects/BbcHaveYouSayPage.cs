using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BbcTestProject.PageObjects
{
    class BbcHaveYouSayPage : BasePage
    {
        public BbcHaveYouSayPage(IWebDriver driver)
            : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = "div[aria-labelledby='nw-c-Getintouch__title'] a")]
        private IList<IWebElement> GetInTouchLinks { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[aria-labelledby='nw-c-Getintouch__title'] a h3")]
        private IList<IWebElement> GetInTouchLinksTitles { get; set; }


        private void FindGetInTouchLink(string text)
        {
           
            for (int i = 0; i < GetInTouchLinks.Count; i++)
            {
                if (GetInTouchLinksTitles[i].Text == text)
                {
                    GetInTouchLinks[i].Click();
                    break;
                }
            }
        }
        public BbcQuestionsPage GoToQuestionPage()
        {
            FindGetInTouchLink("Do you have a question for BBC News?");
            return new BbcQuestionsPage(driver);
        }

        public BbcShareNewsPage GoToShareNewsPage()
        {
            FindGetInTouchLink("How to share with BBC News");
            return new BbcShareNewsPage(driver);
        }

    }
}
