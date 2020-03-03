using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BbcTestProject.PageObjects
{
    class FormQuestion: Form
    {
        [FindsBy(How = How.CssSelector, Using = "div.embed-content-container")]
        private IWebElement FormElement { get; set; }
        
        public override IList<IWebElement> Fields { get; set; }
        public override IWebElement TextArea { get; set; }
        public override IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.character-counter")]
        private IWebElement TextAreaNumberOfSymbols { get; set; }

        public FormQuestion(IWebDriver driver) : base(driver)
        {
            Fields = FormElement.FindElements(By.XPath(".//input"));
            TextArea = FormElement.FindElement(By.XPath(".//textarea"));
            SubmitButton = FormElement.FindElement(By.XPath(".//button"));
        }

        public string TextAreaNumberOfSymbolsText()
        {
            return TextAreaNumberOfSymbols.Text;
        }

        private bool AreEmptyFieldsInForm()
        {
            return Fields.Any(f => string.IsNullOrEmpty(f.GetAttribute("value")));
        }

        public bool CheckEmptyFieldsErrorsCorrectness()
        {
            if (AreEmptyFieldsInForm())
            {
                List<IWebElement> expectedErrors = new List<IWebElement>();
                IWebElement expectedErrorsElement;
                //check correctness of error text under each empty field
                for (int i = 0; i < Fields.Count; i++)
                {
                    if (Fields[i].GetAttribute("value") == "")
                    {
                        expectedErrorsElement = driver.FindElement(By.CssSelector(string.Format("input[placeholder=\"{0}\"]+div.input-error-message",
                            Fields[i].GetAttribute("placeholder"))));
                        expectedErrors.Add(expectedErrorsElement);
                        if (expectedErrorsElement.Text != Fields[i].GetAttribute("placeholder") + " can't be blank")
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
