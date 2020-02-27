using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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
            }
            CurrentMonthResultButton.Click();
        }

        private List<string> GetMatchResultsLeftTeamScore()
        {
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    MatchResultsLeftTeamScore = driver.FindElements(By.CssSelector("div.sp-c-date-picker-timeline__group:nth-child(2) ul li:first-child a"));
                    staleElement = false;

                }
                catch (StaleElementReferenceException)
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
            }
            List<string> RightTeamScoreText = new List<string>(MatchResultsRightTeamScore.Count);
            for (int i = 0; i < MatchResultsRightTeamScore.Count; i++)
            {
                RightTeamScoreText.Add(MatchResultsRightTeamScore[i].Text);
            }
            return RightTeamScoreText;
        }

        //List<Results> Class Results
        //попробывать создавать элемент ближе к месту, где это необходимо
        public List<string[]> GetMatchesResults()
        {
            DisplayCurrentMonthMatches();
            List<string> leftTeam = new List<string>();
            List<string> rightTeam = new List<string>();            
            leftTeam = GetMatchResultsLeftTeamScore();
            rightTeam = GetMatchResultsRightTeamScore();
            List<string[]> totalResults = new List<string[]>(rightTeam.Count);
            for(int i=0;i< rightTeam.Count; i++)
            {
                totalResults[i][0] = leftTeam[i];
                totalResults[i][1] = rightTeam[i];
            }
            return totalResults;
        }

        public IList<IWebElement> GetMatchesLinks()
        {
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
            }
            return MatchResultsLinks;
        }

        
        public string[] GetSelectedMatchResult()
        {
            string[] result = new string[2];
            string leftMatch;
            string rightMatch;
            bool staleElement = true;
            while (staleElement)
            {
                try
                {
                    leftMatch = driver.FindElement(By.CssSelector("section.fixture--live-session-header div.fixture__wrapper>span:first-child>span:last-child span")).Text;
                    staleElement = false;
                    result[0] = leftMatch;

                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    continue;
                }
            }

            while (staleElement)
            {
                try
                {
                    rightMatch = driver.FindElement(By.CssSelector("section.fixture--live-session-header div.fixture__wrapper span.fixture__team:nth-of-type(2)>span:nth-child(2) span")).Text;
                    staleElement = false;
                    result[1] = rightMatch;
                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    continue;
                }
            }         
            return result;
        }
    }
}
