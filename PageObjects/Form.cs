using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;

namespace BbcTestProject.PageObjects
{
    abstract class Form: BasePage
    {
        public Form(IWebDriver driver) : base(driver) { }
        public abstract IList<IWebElement> Fields { get; set; }
        public abstract IWebElement TextArea { get; set; }
        public abstract IWebElement SubmitButton { get; set; }

        public static string text;
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
            string attribute = Fields.Any(f => string.IsNullOrEmpty(f.GetAttribute("placeholder"))) ? "name" : "placeholder";
            foreach (var pair in values)
            {
                if (pair.Key == "Text")
                {
                        TextArea.Clear();
                        TextArea.SendKeys(pair.Value);
                }

                foreach (IWebElement input in Fields)
                {
                        if (pair.Key == input.GetAttribute(attribute))
                        {
                            input.Clear();
                            input.SendKeys(pair.Value);
                        }
                }
            }           
        }

        public void SubmitClick()
        {
            SubmitButton.Click();
        }

        private bool AreEmptyFieldsInForm()
        {
            return Fields.Any(f => string.IsNullOrEmpty(f.GetAttribute("value")));
        }

        public List<IWebElement> GetFieldWithRequiredAttribute()
        {
            List<IWebElement> required = new List<IWebElement>();
            for (int i = 0; i < Fields.Count; i++)
            {
                if (Fields[i].GetAttribute("required") == "required")
                {
                    required.Add(Fields[i]);
                }
            }
            return required;
        }
    }
}
