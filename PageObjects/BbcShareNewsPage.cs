using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BbcTestProject.PageObjects
{
    class BbcShareNewsPage: BasePage
    {
        public FormNewsShare form;
        public BbcShareNewsPage(IWebDriver driver)
            : base(driver)
        {
            form = new FormNewsShare(driver);
        }
    }
}
