using MnS_UI_Test_Project.FrameworkLayer.TestBase;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnS_UI_Test_Project.FrameworkLayer.Utility
{
    public class ScrollActions:BasePage
    {
        public static void  BringElementToPageCenter(IWebElement element)
        {
            Thread.Sleep(1000);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(({behavior: 'auto',block: 'center',inline: 'center'}))", element);
            Thread.Sleep(1000);
        }

        public static void ScrollDown()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }

        public static void ScrollDown(double desiredHeight)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight*" + desiredHeight + ")");
        }
    }
}
