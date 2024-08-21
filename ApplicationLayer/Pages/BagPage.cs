using MnS_UI_Test_Project.FrameworkLayer.TestBase;
using OpenQA.Selenium;
using System.Drawing;

namespace MnS_UI_Test_Project.ApplicationLayer.Pages
{
    public class BagPage:BasePage
    {
        IWebElement continueShoppingBTn => LocateElement("//button[.='Continue shopping']");
        IWebElement checkoutBTn => LocateElement("//a/span[.='Checkout']");
 

        public CheckoutPage GotoCheckout()
        {
            ClickOnElement(checkoutBTn);

            return new CheckoutPage();
        }

        public ProductPage ContinueShopping()
        { 
          ClickOnElement(continueShoppingBTn);
            return new ProductPage();
        }
    }
}