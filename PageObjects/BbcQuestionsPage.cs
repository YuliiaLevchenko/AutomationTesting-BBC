using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace BbcTestProject.PageObjects
{
    class BbcQuestionsPage : BasePage
    {
        public BbcQuestionsPage(IWebDriver driver)
            : base(driver) {
            form = new QuestionForm(driver);
        }

        public QuestionForm form;
    }
}
