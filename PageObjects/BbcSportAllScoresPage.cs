using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using BbcTestProject.Utils;

namespace BbcTestProject.PageObjects
{
    class BbcSportAllScoresPage:BasePage
    {
        public BbcSportAllScoresPage(IWebDriver driver)
           : base(driver) { }

        [FindsBy(How = How.CssSelector, Using = "div.sp-c-date-picker-timeline__group:nth-child(2) ul li:first-child a")]
        private IWebElement CurrentMonthResultButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.qa-match-block ul li a")]
        public IList<IWebElement> MatchResultsLinks { get; set; }

        private IList<IWebElement> MatchResultsLeftTeamScore { get; set; }

        private IList<IWebElement> MatchResultsRightTeamScore { get; set; }


        private void DisplayCurrentMonthMatches()
        {
            Utils.Utils.WaitForJqueryAjax(driver);
            bool staleElement = true;
            while (staleElement)
            {

                try
                {
                    CurrentMonthResultButton = driver.FindElement(By.CssSelector("div.sp-c-date-picker-timeline__group:nth-child(2) ul li:first-child a"));
                    staleElement = false;

                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    continue;
                }
                catch (ElementNotInteractableException)
                {
                    staleElement = true;
                    continue;

                }
            }
            CurrentMonthResultButton.Click();
        }

        private List<string> GetMatchResultsLeftTeamScore()
        {
            Utils.Utils.WaitForJqueryAjax(driver);
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    MatchResultsLeftTeamScore = driver.FindElements(By.CssSelector("div.qa-match-block ul li a article div>span:nth-child(1)>span:nth-child(2)"));
                    staleElement = false;

                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    continue;
                }
                catch (ElementNotInteractableException)
                {
                    staleElement = true;
                    continue;

                }
            }
            List<string> LeftTeamScoreText= new List<string>(MatchResultsLeftTeamScore.Count);
            for(int i=0; i< MatchResultsLeftTeamScore.Count; i++)
            {
                LeftTeamScoreText.Add(MatchResultsLeftTeamScore[i].Text);
            }
            return LeftTeamScoreText;
        }


        private List<string> GetMatchResultsRightTeamScore()
        {
            Utils.Utils.WaitForJqueryAjax(driver);
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    MatchResultsRightTeamScore = driver.FindElements(By.CssSelector("div.qa-match-block ul li a article div>span:nth-child(3)>span:nth-child(2)"));
                    staleElement = false;

                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    continue;
                }
                catch (ElementNotInteractableException)
                {
                    staleElement = true;
                    continue;

                }
            }
            List<string> RightTeamScoreText = new List<string>(MatchResultsRightTeamScore.Count);
            for (int i = 0; i < MatchResultsRightTeamScore.Count; i++)
            {
                RightTeamScoreText.Add(MatchResultsRightTeamScore[i].Text);
            }
            return RightTeamScoreText;
        }

        public List<Tuple<string, string>> GetMatchesResults()
        {
            DisplayCurrentMonthMatches();
            List<string> leftTeam = new List<string>();
            List<string> rightTeam = new List<string>();            
            leftTeam = GetMatchResultsLeftTeamScore();
            rightTeam = GetMatchResultsRightTeamScore();
            List<Tuple<string,string>> totalResults = new List<Tuple<string, string>>(rightTeam.Count);
            for(int i=0;i< rightTeam.Count; i++)
            {
                totalResults.Add(new Tuple<string, string>(leftTeam[i], rightTeam[i]));
            }
            return totalResults;
        }

        public IList<IWebElement> GetMatchesLinks()
        {
            Utils.Utils.WaitForJqueryAjax(driver);
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    MatchResultsLinks = driver.FindElements(By.CssSelector("div.qa-match-block ul li a"));
                    staleElement = false;

                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    continue;
                }
                catch (ElementNotInteractableException)
                {
                    staleElement = true;
                    continue;

                }
            }
            return MatchResultsLinks;
        }

        
        public Tuple<string, string> GetSelectedMatchResult()
        {
            Utils.Utils.WaitForJqueryAjax(driver);
            string leftMatch = string.Empty;
            string rightMatch = string.Empty;
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    leftMatch = driver.FindElement(By.CssSelector("section.fixture--live-session-header div.fixture__wrapper>span:first-child>span:last-child span")).Text;
                    staleElement = false;
                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    continue;
                }
                catch (ElementNotInteractableException)
                {
                    staleElement = true;
                    continue;

                }
            }
            staleElement = true;

            while (staleElement)
            {
                try
                {
                    rightMatch = driver.FindElement(By.CssSelector("section.fixture--live-session-header div.fixture__wrapper span.fixture__team:nth-of-type(2)>span:nth-child(2) span")).Text;
                    staleElement = false;
                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    continue;
                }
                catch (ElementNotInteractableException)
                {
                    staleElement = true;
                    continue;

                }
            }         
            return new Tuple<string, string>(leftMatch,rightMatch);
        }
    }
}
