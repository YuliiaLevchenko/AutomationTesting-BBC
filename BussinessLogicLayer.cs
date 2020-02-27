﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using BbcTestProject.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace BBCTestProject
{
    [Binding]
    public sealed class BussinessLogicLayer
    {
        private IWebDriver driver;
        private Dictionary<string, string> fields;
        BbcHomePage home;
        BbcNewsPage news;
        BbcSportPage sport;
        BbcSportAllScoresPage allScoresPage;
        BbcHaveYouSayPage haveYouSay;
        BbcQuestionsPage question;
        private string text;
        private List<string> SecondaryNewsCorrectTitles;
        private string TextSearched;
        List<string[]> expectedMatchesResults;
        List<string[]> actualMatchesResults;

    [BeforeScenario]
        public void SetupDrivers()
        {
            driver = new ChromeDriver("D:\\С#\\BBCTestProject");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Given(@"User generates text for all input fields but (.*)")]
        public Dictionary<string, string> GivenUserGeneratesTextForAllInputFieldsBut(string fieldName)
        {
            fields = new Dictionary<string, string>()
            {
                {"Name", "Julie" },
                {"Email address", "aaa@ukr.net"},
                {"Age", "20" },
                {"Postcode", "1234" },
                {"Question", "Why everything is about coronavirus?" }
            };

            fields.Remove(fieldName);
            return fields;
        }

        [When(@"User navigates to BBC Question Page")]
        public void WhenUserNavigatesToBBCQuestionPage()
        {
            home = new BbcHomePage(driver);
            home.GoToPage();
            news = home.GoToNewsPage();
            haveYouSay = news.GoToHaveYouSayPage();
            question = haveYouSay.GoToQuestionPage();           
        }

        [When(@"User fills in question form without (.*)")]
        public void WhenUserFillsInQuestionFormWithout(string p0)
        {
            question.form.FillForm(fields);
        }

        [When(@"User clicks on Submit button")]
        public void WhenUserClicksOnSubmitButton()
        {
            question.form.SubmitClick();
        }

        [Then(@"Validation errors under empty fields display")]
        public void ThenValidationErrorUnderFieldDisplays()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.IsTrue(question.form.CheckEmptyFieldsErrorsCorrectness(),"Errors display incorrect" );
        }

        [Given(@"User generates text for textarea with length of (.*) symbols")]
        public string GivenUserGeneratesWithLengthOfSymbols(int NumberOfSymbols)
        {
            text = QuestionForm.TextGenerator(NumberOfSymbols);
            return text;
        }

        [When(@"User fills textarea with generated text")]
        public void WhenUserFillsTextareaWithGeneratedText()
        {
            question.form.GetTextArea().SendKeys(text);
        }

        [Then(@"An indicator of number of letters under the textarea displays '(.*)'")]
        public void ThenAnIndicatorUnderTheTextareaDisplays(string indicator)
        {
            string actualResult = question.form.TextAreaNumberOfSymbolsText();
            Assert.AreEqual(indicator, actualResult);
        }


        [When(@"User navigates to BBC News Page")]
        public void WhenUserNavigatesToBBCNewsPage()
        {
            home = new BbcHomePage(driver);
            home.GoToPage();
            news = home.GoToNewsPage();
        }

        [Then(@"The main News title is ""(.*)""")]
        public void ThenTheMainNewsTitleIs(string title)
        {
            Assert.AreEqual(title, news.GetMainNewsTitleText());
        }

        //table specflow
        [Given(@"The list of correct titles for (.*), (.*), (.*), (.*)")]
        public void GivenTheListOfCorrectTitlesFor(string news1, string news2, string news3, string news4)
        {
            SecondaryNewsCorrectTitles = new List<string>();
            SecondaryNewsCorrectTitles.Add(news1);
            SecondaryNewsCorrectTitles.Add(news2);
            SecondaryNewsCorrectTitles.Add(news3);
            SecondaryNewsCorrectTitles.Add(news4);
        }

        [Then(@"Secondary News titles display correct")]
        public void ThenSecondaryNewsTitlesDisplayCorrect()
        {
            for(int i=0; i< SecondaryNewsCorrectTitles.Count; i++)
            {
                //Assert.Multiple
                Assert.AreEqual(SecondaryNewsCorrectTitles[i], news.GetSeconaryTitleText()[i]);
            }

        }



        [When(@"User considers main News category as input for search box")]
        public void WhenUserConsidersMainNewsCategoryAsInputForSearchBox()
        {
            TextSearched = news.GetMainNewsCategory();
        }

        [When(@"User searches for input through search box")]
        public void WhenUserSearchesForInputThroughSearchBox()
        {
            news.SearchValue(TextSearched);
        }

        [Then(@"the first article name equals main News category name")]
        public void ThenTheFirstArticleNameShouldEqualMainNewsCategoryName()
        {
            string actual = driver.FindElement(By.CssSelector("ol:first-child li:first-child article div h1[itemprop='headline'] a")).Text;
            Assert.AreEqual(TextSearched, actual);
        }


        [When(@"User navigates to Sport Category")]
        public void WhenUserNavigatesToSportCategory()
        {
            home = new BbcHomePage(driver);
            home.GoToPage();
            sport = home.GoToSportPage();
        }

        [When(@"User navigates to Scottish Premier League matches links")]
        public void WhenUserNavigatesToScottishPremierLeagueMatchesLinks()
        {
            allScoresPage = sport.GoToAllScoresPage();
        }

        [When(@"User clicks on the matches link in series")]
        public void WhenUserClicksOnTheMatchesLinkInSeries()
        {
            expectedMatchesResults = allScoresPage.GetMatchesResults();
            actualMatchesResults = new List<string[]>();
            IList<IWebElement> links = allScoresPage.GetMatchesLinks();
            for (int i=0; i< allScoresPage.MatchResultsLinks.Count; i++)
            {             
                links[i].Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                actualMatchesResults[i] = allScoresPage.GetSelectedMatchResult();
                driver.Navigate().Back();
            }
        }

        [Then(@"Score on the opened page equals score on the page with matches links")]
        public void ThenScoreOnTheOpenedPageEqualsScoreOnThePageWithMatchesLinks()
        {
            for(int i=0; i < allScoresPage.MatchResultsLinks.Count; i++)
            {
                Assert.AreEqual(expectedMatchesResults[i][0], actualMatchesResults[i][0]);
                Assert.AreEqual(expectedMatchesResults[i][1], actualMatchesResults[i][1]);
            }
        }


        [AfterScenario]
        public void CloseDrivers()
        {
            driver.Close();
        }

    }
}