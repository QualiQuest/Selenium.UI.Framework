using MnS_UI_Test_Project.FrameworkLayer.TestBase;

namespace MnS_UI_Test_Project.ApplicationLayer.Pages
{
    public class ProductPage : BasePage
    {
        public void SelectProductColour(string color)
        {
            /*var colourItem = LocateElement($"//label[starts-with(@id,'{color}')]");
            ClickOnElement(colourItem);*/
            ClickOnElement(LocateElement($"//label[starts-with(@id,'{color}')]"));
        }

        public void SelectProductSize(string size)
        {
            ClickOnElement(LocateElement($"//input[@value='{size}']"));
        }

        public void SelectProductQuantity(string quantity)
        {
            var dropdown = LocateElement("//select[@id='quantitySelector']");
            SelectItemFromDropdown(dropdown, quantity);
        }

        public BagPage AddProductToBag()
        {
            ClickOnElement(LocateElement("//button[.='Add to bag']"));
            return new BagPage();
        }
    }
}
 