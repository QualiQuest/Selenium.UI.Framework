using MnS_UI_Test_Project.FrameworkLayer.TestBase;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnS_UI_Test_Project.ApplicationLayer.Pages
{
    public class LandingPage:BasePage
    {
        IWebElement signinBtn => LocateElement("//p[.='Sign in']");

        public LoginPage GotoLoginPage()
        {
            ClickOnElement(signinBtn);
           return new LoginPage();
        }
    }
}
