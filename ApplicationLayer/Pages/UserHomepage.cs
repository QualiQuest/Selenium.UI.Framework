using MnS_UI_Test_Project.FrameworkLayer.TestBase;
using OpenQA.Selenium;

namespace MnS_UI_Test_Project.ApplicationLayer.Pages
{
    public class UserHomepage:BasePage
    {
        IWebElement myAccountBtn => LocateElement("//button[@aria-label='My account']");
        public string GetAccountGreetingMessage()
        {
            MoveToAnElement(myAccountBtn);
            var userAccountGreetingMessageElement = LocateElement("//span[.='Orders & returns']/ancestor::ul/preceding-sibling::p");
            var userAccountGreetingMessage = GetElementsText(userAccountGreetingMessageElement);
            return userAccountGreetingMessage;
        }
    }
}