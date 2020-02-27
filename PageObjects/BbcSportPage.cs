using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BbcTestProject.PageObjects
{
    class BbcSportPage: BasePage
    {
        public BbcSportPage(IWebDriver driver)
           : base(driver) { }


       
        private IWebElement FootballScoresMoreButton { get; set; }

        private IWebElement MoreScottishPremButton { get; set; }

        private IWebElement ViewAllButton { get; set; }


        public BbcSportAllScoresPage GoToAllScoresPage()
        {
            bool staleElement = true;
            while (staleElement)
            {

                try
                {
                    FootballScoresMoreButton = driver.FindElement(By.XPath("//div[2]//div/button"));
                    staleElement = false;
                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    continue;
                }
            }
            FootballScoresMoreButton.Click();

            staleElement = true;
            while (staleElement)
            {

                try
                {
                    MoreScottishPremButton = driver.FindElement(By.XPath("//div[2]//div[2]//ul/li[2]/button"));
                    staleElement = false;
                    MoreScottishPremButton.Click();
                }
                catch (StaleElementReferenceException)
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
                    ViewAllButton = driver.FindElement(By.XPath("//div[2]//div[2]/div[2]/a"));
                    staleElement = false;
                    
                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    continue;
                }
            }
            ViewAllButton.Click();
            return new BbcSportAllScoresPage(driver);
        }
    }
}
