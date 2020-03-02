using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using BbcTestProject.Utils;

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
            Utils.Utils.WaitForJqueryAjax(driver);
            bool staleElement = true;
            while (staleElement)
            {

                try
                {
                    FootballScoresMoreButton = driver.FindElement(By.XPath("//div[2]//div/button"));
                    staleElement = false;
                    FootballScoresMoreButton.Click();
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
                    MoreScottishPremButton = driver.FindElement(By.XPath("//div[2]//div[2]//ul/li[2]/button"));
                    staleElement = false;
                    MoreScottishPremButton.Click();
                }
                catch (StaleElementReferenceException)
                {
                    staleElement = true;
                    continue;

                }
                catch(ElementNotInteractableException)
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
                    ViewAllButton.Click();

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
           
            return new BbcSportAllScoresPage(driver);
        }
    }
}
