using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BbcTestProject.PageObjects
{
    class FormNewsShare:Form
    {
        [FindsBy(How = How.CssSelector, Using = ".contact-form form")]
        private IWebElement FormElement { get; set; }

        public override IList<IWebElement> Fields { get; set; }
        public override IWebElement TextArea { get; set; }
        public override IWebElement SubmitButton { get; set; }
        public FormNewsShare(IWebDriver driver) : base(driver)
        {
            Fields = FormElement.FindElements(By.XPath("./fieldset/input"));
            TextArea = FormElement.FindElement(By.XPath(".//textarea"));
            SubmitButton = FormElement.FindElement(By.XPath(".//input[@type='submit']"));
        }
    }
}
