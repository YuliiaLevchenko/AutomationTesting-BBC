using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BbcTestProject.Utils
{
    public static class Utils
    {
        public static void WaitForJqueryAjax(IWebDriver driver)
        {
            int delay = 10;
            while (delay > 0)
            {
                Thread.Sleep(1000);
                var jquery = (bool)(driver as IJavaScriptExecutor)
                    .ExecuteScript("return window.jQuery == undefined");
                if (jquery)
                {
                    break;
                }
                var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor)
                    .ExecuteScript("return window.jQuery.active == 0");
                if (ajaxIsComplete)
                {
                    break;
                }
                delay--;
            }
        }
    }
}
