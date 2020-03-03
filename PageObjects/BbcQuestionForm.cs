using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BbcTestProject.PageObjects
{
    class QuestionForm : BasePage
    {

        public QuestionForm(IWebDriver driver)
            : base(driver) { }

        [FindsBy(How = How.TagName, Using = "textarea")]
        public IWebElement TextArea { get; private set; }

        [FindsBy(How = How.CssSelector, Using = ".embed-content-container input")]
        private IList<IWebElement> ContactInfoFields { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".embed-content-container button")]
        private IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.character-counter")]
        private IWebElement TextAreaNumberOfSymbols { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.input-threeup-leading div.input-error-message")]
        private IList<IWebElement> InputErrors { get; set; }



        public string TextAreaNumberOfSymbolsText()
        {
            return TextAreaNumberOfSymbols.Text;
        }

        static string text;
        public static string TextGenerator(int num)
        {
            for (int i = 0; i < num; i++)
            {
                text += "t";
            }
            return text;
        }

        public void FillForm(Dictionary<string, string> values)
        {
            foreach (var pair in values)
            {

                if (pair.Key == "Text")
                {
                    TextArea.Clear();
                    TextArea.SendKeys(pair.Value);
                }

                foreach (IWebElement input in ContactInfoFields)
                {
                    if (pair.Key == input.GetAttribute("placeholder"))
                    {
                        input.Clear();
                        input.SendKeys(pair.Value);
                    }
                }
            }
        }


        public IWebElement GetTextArea()
        {
            return TextArea;
        }
        public void SubmitClick()
        {
            SubmitButton.Click();
        }

        private bool AreEmptyFieldsInForm()
        {
            return ContactInfoFields.Any(f => string.IsNullOrEmpty(f.GetAttribute("value")));
        }

        public bool CheckEmptyFieldsErrorsCorrectness()
        {
            if (AreEmptyFieldsInForm())
            {
                List<IWebElement> expectedErrors = new List<IWebElement>();
                IWebElement expectedErrorsElement;
                //check correctness of error text under each empty field
                for (int i = 0; i < ContactInfoFields.Count; i++)
                {
                    if (ContactInfoFields[i].GetAttribute("value") == "")
                    {                        
                        expectedErrorsElement = driver.FindElement(By.CssSelector(string.Format("input[placeholder=\"{0}\"]+div.input-error-message",
                            ContactInfoFields[i].GetAttribute("placeholder"))));
                        expectedErrors.Add(expectedErrorsElement);
                        if (expectedErrorsElement.Text != ContactInfoFields[i].GetAttribute("placeholder") + " can't be blank")
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
            
        }
    }
}
