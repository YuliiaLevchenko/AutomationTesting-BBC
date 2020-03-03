using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace BbcTestProject.PageObjects
{
    class BbcShareNewsForm : BasePage
    {
        public BbcShareNewsForm(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.ClassName, Using = "contact-form__input")]
        private IList<IWebElement> ContactInfoFields { get; set; }

        [FindsBy(How = How.ClassName, Using = "contact-form__label")]
        private IList<IWebElement> AllFieldsLabels { get; set; }

        [FindsBy(How = How.TagName, Using = "textarea")]
        private IWebElement Textarea { get; set; }

        [FindsBy(How=How.Id, Using ="submit")]
        private IWebElement SubmitButton { get; set; }

        public void SubmitClick()
        {
            SubmitButton.Click();
        }

        public List<IWebElement> GetFieldWithRequiredAttribute()
        {
            List <IWebElement> required = new List<IWebElement>();
            for(int i=0; i < ContactInfoFields.Count; i++)
            {
                if (ContactInfoFields[i].GetAttribute("required") == "required")
                {
                    required.Add(ContactInfoFields[i]);
                }
            }
            return required;
        }

        public void FillForm(Dictionary<string, string> values)
        {
            foreach (var pair in values)
            {

                if (pair.Key == "Text")
                {
                    Textarea.Clear();
                    Textarea.SendKeys(pair.Value);
                }

                foreach (IWebElement input in ContactInfoFields)
                {
                    if (pair.Key == input.GetAttribute("name"))
                    {
                        input.Clear();
                        input.SendKeys(pair.Value);
                    }
                }
            }
        }



    }
}
