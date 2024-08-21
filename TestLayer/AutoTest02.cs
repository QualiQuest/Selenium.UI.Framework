using MnS_UI_Test_Project.ApplicationLayer.Pages;
using MnS_UI_Test_Project.FrameworkLayer.TestBase;
using MnS_UI_Test_Project.FrameworkLayer.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MnS_UI_Test_Project.TestLayer
{
    public class AutoTest02
    {
        public class Test : BasePage  
        {
            // private IWebDriver Driver;
            private Actions _actions;
            private SelectElement select;
            private Func<By, IWebElement> signoutItem;

           string username = VariableValueReader.ReadVariableValue(BasePage.PathToFileEnvironmentVariableFile, TestContext.Parameters["loginUsername"]);
           string password = VariableValueReader.ReadVariableValue(BasePage.PathToFileEnvironmentVariableFile, TestContext.Parameters["loginPassword"]);

            [SetUp]
            public void Setup()
            {
                LaunchBrowser();
                LaunchSite();   
                /*driver = new ChromeDriver();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5.0);
                Driver.Manage().Window.Maximize();*/

                //LaunchBrowser();
                /*Driver.Navigate().GoToUrl("https://www.marksandspencer.com/");
                //Thread.Sleep(2000);
                IWebElement acceptCookieBtn = Driver.FindElement(By.XPath("//button[@id='onetrust-accept-btn-handler']"));
                acceptCookieBtn.Click();
                Thread.Sleep(1000);*/



            }

            [Test]
            public void VerifyThatUsersAreAbleToSelectTheirIntendedProduct()
            {
                var loginPage = new LandingPage().GotoLoginPage();
                IWebElement babyTab = LocateElement("//p[text()='Baby']");
                MoveToAnElement (babyTab);
                Thread.Sleep(1000);

                IWebElement babyDresesCat = LocateElement("//a[text()='Baby Dresses']");
                MoveToElementAndClick (babyDresesCat);
                Thread.Sleep(1000);

                var isBabyDressesPageNavigatedTo = LocateElement("//h1[.='Baby Dresses']").Displayed;
                ClickOnElement(LocateElement("//div[@id='60675052']//a/child::div//h2[contains(.,'Floral Dress')]"));
                //river.FindElement(By.XPath("//div[@id='60675052']//a/child::div//h2[contains(.,'Floral Dress')]")).Click();
                //LocateElement("//div[@id='60675052']//a/child::div//h2[contains(.,'Floral Dress')]").Click();
                //var product = LocateElement("//p[contains(text(),'Product code: ')]").Text;
                var product = GetElementsText(LocateElement("//p[contains(text(),'Product code: ')]"));
                Assert.That(product.Contains("T782363A"), Is.True);

                //_actions = new Actions(Driver);
                //IWebElement babyTab = Driver.FindElement(By.XPath("//p[text()='Baby']"));
                //_actions.MoveToElement(babyTab).Perform();

                //IWebElement babyDresesCat = Driver.FindElement(By.XPath("//a[text()='Baby Dresses']"));

                //_actions.MoveToElement(babyDresesCat).Click().Perform();

                //var isBabyDressesPageNavigatedTo = Driver.FindElement(By.XPath("//h1[.='Baby Dresses']")).Displayed;

                //var product = Driver.FindElement(By.XPath("//p[contains(text(),'Product code: ')]")).Text;
                //Assert.That(product.Contains("T782363A"), Is.True);

            }

            [Test]
            public void VerifyThatUsersAreAbleToSortProducts()
            {
                var loginPage = new LandingPage().GotoLoginPage();
                var username = VariableValueReader.ReadVariableValue(BasePage.PathToFileEnvironmentVariableFile, TestContext.Parameters["loginUsername"]);
                var password = VariableValueReader.ReadVariableValue(BasePage.PathToFileEnvironmentVariableFile, TestContext.Parameters["loginPassword"]);
                var userHomepage = loginPage.LoginToApplication(username,password);
                var welcomeMessage = "Hello again, Jennifer";
                Assert.That(userHomepage.GetAccountGreetingMessage().Contains(welcomeMessage), Is.True);
                
                userHomepage.SelectProductCategory("Men", "Shoes");
                /*IWebElement menTab = LocateElement("//p[text()='Men']");
                MoveToAnElement (menTab);
                Thread.Sleep(2000);

                IWebElement shoesCat = LocateElement("//p[.='Men']/../following-sibling::div//a[.='Shoes']");
                MoveToElementAndClick (shoesCat);
                Thread.Sleep(1000);*/

                var isShoePageNavigatedTo = LocateElement("//h1[.='Men’s New-In Shoes']").Displayed;
                Assert.That(isShoePageNavigatedTo, Is.True);

                IWebElement sortByDropdown = LocateElement("//select[@id='sortBy']");
                select = new SelectElement(sortByDropdown);
                select.SelectByText("New Arrivals");
                Thread.Sleep(1000); //no assertion here?
                //_actions = new Actions(Driver);
                //IWebElement menTab = Driver.FindElement(By.XPath("//p[text()='Men']"));

                //_actions.MoveToElement(menTab).Perform();
                //Thread.Sleep(2000);


                //IWebElement shoesCat = Driver.FindElement(By.XPath("//p[.='Men']/../following-sibling::div//a[.='Shoes']"));

                //_actions.MoveToElement(shoesCat).Click().Perform();
                //Thread.Sleep(1000);


                //var isShoePageNavigatedTo = Driver.FindElement(By.XPath("//h1[.='Men’s New-In Shoes']")).Displayed;//To verify/assert that the shoe page is displayed.

                //IWebElement sortByDropdown = Driver.FindElement(By.XPath("//select[@id='sortBy']"));
                //select = new SelectElement(sortByDropdown);
                //select.SelectByText("New Arrivals");
                //Thread.Sleep(1000);

                /* Driver.FindElement(By.XPath("//div[@id='60675052']//a/child::div//h2[contains(.,'Floral Dress')]")).Click();
                 var product = Driver.FindElement(By.XPath("//p[contains(text(),'Product code: ')]")).Text;
                 Assert.That(product.Contains("T782363A"), Is.True);*/

            }

            [Test]

            public void VerifyThatUserCanSuccesfullyAddProductToBag()
            {
                var loginPage = new LandingPage().GotoLoginPage();
                var username = VariableValueReader.ReadVariableValue(BasePage.PathToFileEnvironmentVariableFile, TestContext.Parameters["loginUsername"]);
                var password = VariableValueReader.ReadVariableValue(BasePage.PathToFileEnvironmentVariableFile, TestContext.Parameters["loginPassword"]);
                var userHomepage = loginPage.LoginToApplication(username, password);
               /* var welcomeMessage = "Hello again, Jennifer";
                Assert.That(userHomepage.GetAccountGreetingMessage().Contains(welcomeMessage), Is.True);*/

                var productsPage = userHomepage.SelectProductCategory("Women", "Footwear");
                //var productSelected = LocateElement("//h2[.='Kitten Heel Pointed Court Shoes']");
                var productName =  "Kitten Heel Pointed Court Shoes";
                //productsPage.SelectProduct("productName");
                var productpage = productsPage.SelectProduct(productName);

                //var productColour = LocateElement("//label[starts-with(@id,'Silver')]");
                productpage.SelectProductColour("Silver");

                //click on goto wishlist
                // var isAddedItemInTheWishList = LocateElement($"//h2[.='{productName}']).Display;
                //Asert.That(isAddedItemInTheWishList, Is.True);
                //WishListPage
                // public bool IsProductOnWishList(string productName){ return LocateElement($"//h2[.='{productName}']).Display;}

            }

            [Test]
            public void VerifyThatUsersCanSuccessfullyFilterProducts()
            {
                var loginPage = new LandingPage().GotoLoginPage();

                var userHomepage = loginPage.LoginToApplication(username,password);
                var productsPage = userHomepage.SelectProductCategory("Kids", "Girls");
                productsPage.FilterProduct("Colour", "Blue");
                productsPage.FilterProduct("Colour", "Yellow");
                productsPage.FilterProduct("Colour", "Green");
                productsPage.FilterProduct("Colour", "Brown");
                /*IWebElement kidsTab = LocateElement("//p[text()='Kids']");
                MoveToAnElement(kidsTab);
                Thread.Sleep(2000);

                IWebElement girlsCat = LocateElement("//p[.='Kids']/../following-sibling::div//a[.='Girls']");
                MoveToElementAndClick(girlsCat);
                Thread.Sleep(1000);*/

               /* IWebElement filterDropdown = LocateElement("//span[.='Colour']");
                ClickOnElement(filterDropdown);
                ChooseFilterColour("Blue");
                ChooseFilterColour("Yellow");
                ChooseFilterColour("Green");
                ChooseFilterColour("Brown");

                IWebElement viewItemBtn = LocateElement("//span[.='Colour']/../following-sibling::div//button[.='View Items']");
                ClickOnElement(viewItemBtn);*/

                var selectedColourFilers = Driver.FindElements(By.XPath("//button[.='Clear all']/following-sibling::div//ul//li//span//button/preceding-sibling::span"));
                Assert.That(selectedColourFilers.ToArray().Length.Equals(4), Is.True);

                //_actions = new Actions(Driver);
                //IWebElement kidsTab = Driver.FindElement(By.XPath("//p[text()='Kids']"));
                //_actions.MoveToElement(kidsTab).Perform();
                //Thread.Sleep(2000);

                //IWebElement girlsCat = Driver.FindElement(By.XPath("//p[.='Kids']/../following-sibling::div//a[.='Girls']"));


                //_actions.MoveToElement(girlsCat).Click().Perform();
                //Thread.Sleep(1000);

                //IWebElement filterDropdown = Driver.FindElement(By.XPath("//span[.='Colour']"));
                //filterDropdown.Click();

                /*ChooseFilterColour("Blue");
                ChooseFilterColour("Yellow");
                ChooseFilterColour("Green");
                ChooseFilterColour("Brown");*/

                //IWebElement viewItemBtn = Driver.FindElement(By.XPath("//span[.='Colour']/../following-sibling::div//button[.='View Items']"));
                //viewItemBtn.Click();

                //var isAllIntendedFilterColourSelected = false;
                //var selectedColourFilers = Driver.FindElements(By.XPath("//button[.='Clear all']/following-sibling::div//ul//li//span//button/preceding-sibling::span"));

                /*foreach(var color in selectedColourFilers)
                {
                    if(color.Equals("Blue") || color.Equals("Yellow") || color.Equals("Green") || color.Equals("Brown"))
                    {
                        isAllIntendedFilterColourSelected = true;                              
                    }
                }*/
                //Assert.That(selectedColourFilers.ToArray().Length.Equals(4), Is.True);
               

            }

            [Test]
            public void VerifyThatUsersAreAbleToSuccessfullySelectIntetendedProductQuantity()
            {
                var landingpage = new LandingPage().GotoLoginPage();
                IWebElement productTab = LocateElement("//p[.='Gifts']"); //Text()=.
                MoveToAnElement(productTab);
                Thread.Sleep(1000);

                IWebElement productCat = LocateElement("//a[.='Gifts for Mums']");
                MoveToElementAndClick(productCat);
                Thread.Sleep(1000);

                IWebElement sortByDropdown = LocateElement("//select[@id='sortBy']");
                select = new SelectElement(sortByDropdown);
                select.SelectByText("Ratings");//ask Vicero how to select by value, index selection makes the code flaky, best to select by text.
                Thread.Sleep(1000);

                //SelectProduct("Polka Dot Mug");
                Thread.Sleep(1000);

                IWebElement quantityDropdown = LocateElement("//select[@id='quantitySelector']");
                var quantitytoSelect = "3";
                select = new SelectElement(quantityDropdown);
                select.SelectByText(quantitytoSelect);

                IWebElement addToBagBtn = LocateElement("//button[text()='Add to bag' and @id='add-to-bag-button']");
                MoveToElementAndClick (addToBagBtn);

                var successfullProductAdditionMessage = LocateElement("//p[.='Great taste!']/../child::div//div//p[span[contains(.,'your bag')]]").Text;

                Assert.That(successfullProductAdditionMessage.Contains(quantitytoSelect), Is.True);
                //_actions = new Actions(Driver);
                //IWebElement productTab = Driver.FindElement(By.XPath("//p[.='Gifts']")); //Text()=.
                //_actions.MoveToElement(productTab).Perform();
                //Thread.Sleep(1000);

                //IWebElement productCat = Driver.FindElement(By.XPath("//a[.='Gifts for Mums']"));


                //_actions.MoveToElement(productCat).Click().Perform();
                //Thread.Sleep(1000);


                //IWebElement sortByDropdown = Driver.FindElement(By.XPath("//select[@id='sortBy']"));
                //select = new SelectElement(sortByDropdown);
                //select.SelectByText("Ratings");//ask Vicero how to select by value, index selection makes the code flaky, best to select by text.
                //Thread.Sleep(1000);


                //SelectProduct("Polka Dot Mug");
                //Thread.Sleep(1000);

                //IWebElement quantityDropdown = Driver.FindElement(By.XPath("//select[@id='quantitySelector']"));
                //var quantitytoSelect = "3";
                //select = new SelectElement(quantityDropdown);
                //select.SelectByText(quantitytoSelect);

                //IWebElement addToBagBtn = Driver.FindElement(By.XPath("//button[text()='Add to bag' and @id='add-to-bag-button']"));
                //_actions.MoveToElement(addToBagBtn).Click().Perform();

                //var successfullProductAdditionMessage = Driver.FindElement(By.XPath("//p[.='Great taste!']/../child::div//div//p[span[contains(.,'your bag')]]")).Text;

                //Assert.That(successfullProductAdditionMessage.Contains(quantitytoSelect), Is.True);
                //IWebElement addToBag = Driver.FindElement() /come back here

                /*var isShoePageNavigatedTo = Driver.FindElement(By.XPath("//h1[.='Men’s New-In Shoes']")).Displayed;
                Assert.That(isShoePageNavigatedTo, Is.True);

                IWebElement sortByDropdown = Driver.FindElement(By.XPath("//select[@id='sortBy']"));
                select = new SelectElement(sortByDropdown);
                select.SelectByText("New Arrivals");
                Thread.Sleep(1000);*/


                /* Driver.FindElement(By.XPath("//div[@id='60675052']//a/child::div//h2[contains(.,'Floral Dress')]")).Click();
                 var product = Driver.FindElement(By.XPath("//p[contains(text(),'Product code: ')]")).Text;
                 Assert.That(product.Contains("T782363A"), Is.True);*/

            }

            [Test]

            public void VerifyThatUsersAreAbleToSuccessfullySelectProductSize()
            {
                //_actions = new Actions(Driver);
                var loginPage = new LandingPage().GotoLoginPage();
                IWebElement productTab = LocateElement("//p[text()='Baby']"); //Text()=.
                MoveToAnElement(productTab);
                Thread.Sleep(1000);

                IWebElement productCat = LocateElement("//a[.='Premature']");
                MoveToElementAndClick(productCat);
                Thread.Sleep(1000);

                IWebElement sizeDropdown = LocateElement("//span[.='Baby Sizes']");
                ClickOnElement(sizeDropdown);
                /*SelectedProductSize("0-3 Months");
                SelectedProductSize("3-6 Months");
                SelectedProductSize("6-9 Months");*/

                IWebElement viewItemButton = LocateElement("//span[.='Baby Sizes']/../following-sibling::div//button[.='View Items']");
                ClickOnElement(viewItemButton);

                var selectedBabySizes = Driver.FindElements(By.XPath("//button[.='Clear all']/following-sibling::div//ul//li//span//button/preceding-sibling::span"));
                var NumOfSelectedFilters = selectedBabySizes.ToList().Count;
                Assert.That(NumOfSelectedFilters.Equals(4), Is.True);
                //IWebElement productTab = Driver.FindElement(By.XPath("//p[text()='Baby']")); //Text()=.
                //_actions.MoveToElement(productTab).Perform();
                //IWebElement productCat = Driver.FindElement(By.XPath("//a[.='Premature']"));
                //_actions.MoveToElement(productCat).Click().Perform();


                //IWebElement sizeDropdown = Driver.FindElement(By.XPath("//span[.='Baby Sizes']"));
                //sizeDropdown.Click();
                //SelectedProductSize("0-3 Months");
                //SelectedProductSize("3-6 Months");
                //SelectedProductSize("6-9 Months");


                //IWebElement viewItemButton = Driver.FindElement(By.XPath("//span[.='Baby Sizes']/../following-sibling::div//button[.='View Items']"));
                //viewItemButton.Click();


                /*//var areAllIntendedFilterBabySizesSelected = false;
                //var selectedBabySizes = Driver.FindElements(By.XPath("//button[.='Clear all']/following-sibling::div//ul//li//span//button/preceding-sibling::span"));
                var NumOfSelectedFilters = selectedBabySizes.ToList().Count;
                Assert.That(NumOfSelectedFilters.Equals(4), Is.True);
*/
            }

            [Test]
            public void VerifyThatUsersAreAbleToSuccessfullyLoginToTheirAccount()
            {
                var loginPage = new LandingPage().GotoLoginPage();
                Thread.Sleep(1000);     //tst-loginUsername
                var userHomepage = loginPage.LoginToApplication(username, password);
                var welcomeMessage = "Hello again, Jennifer";
                Assert.That(userHomepage.GetAccountGreetingMessage().Contains(welcomeMessage), Is.True);

                /* _actions = new Actions(Driver);
                 IWebElement signinElement = Driver.FindElement(By.XPath("//p[.='Sign in']")); //Text()=.
                 _actions.MoveToElement(signinElement).Perform();*/


                /*IWebElement signinItem = Driver.FindElement(By.XPath("//span[.='Sign in']"));

                _actions.MoveToElement(signinItem).Click().Perform();
                Thread.Sleep(3000);*/
                /*var userHomepage = loginPage.LoginToApplication("jennifer_chukwudum@yahoo.com", "Jenny@m&s24");
                var welcomeMessage = "Hello again, Jennifer";
                Assert.That(userHomepage.GetAccountGreetingMessage().Contains(welcomeMessage), Is.True);*/
                /*IWebElement usernameEmailAddressField = Driver.FindElement(By.XPath("//input[@id='usernameInput']"));//the driver does not ineteract with email rather the input field.
                usernameEmailAddressField.SendKeys("jennifer_chukwudum@yahoo.com"); // no wait time because its on the same page and click/perform because user have to input password before any action.

                IWebElement userPasswordField = Driver.FindElement(By.XPath("//input[@id='passwordInput']"));
                userPasswordField.SendKeys("Jenny@m&s24");

                IWebElement signinBtn = Driver.FindElement(By.XPath("//button[@id='submitButton']//span[text()='Sign in']"));
                signinBtn.Click();*/

                /* IWebElement myAccountBtn = Driver.FindElement(By.XPath("//button[@aria-label='My account']")); //Text()=.
                 _actions.MoveToElement(myAccountBtn).Perform();
                 var successfulUserAccountLoginMessage = Driver.FindElement(By.XPath("//span[.='Orders & returns']/ancestor::ul/preceding-sibling::p")).Text;*/

                //var welcomeMessage = "Hello again, Jennifer";


                /* IWebElement sortByDropdown = Driver.FindElement(By.XPath("//select[@id='sortBy']"));
                 select = new SelectElement(sortByDropdown);
                 select.SelectByText("Ratings");//ask Vicero how to select by value, index selection makes the code flaky, best to select by text.
                 Thread.Sleep(1000);


                 SelectProduct("Polka Dot Mug");
                 Thread.Sleep(1000);

                 IWebElement quantityDropdown = Driver.FindElement(By.XPath("//select[@id='quantitySelector']"));
                 var quantitytoSelect = "3";
                 select = new SelectElement(quantityDropdown);
                 select.SelectByText(quantitytoSelect);

                 IWebElement addToBagBtn = Driver.FindElement(By.XPath("//button[text()='Add to bag' and @id='add-to-bag-button']"));
                 _actions.MoveToElement(addToBagBtn).Click().Perform();

                 var successfullProductAdditionMessage = Driver.FindElement(By.XPath("//p[.='Great taste!']/../child::div//div//p[span[contains(.,'your bag')]]\")).Text;

                     Assert.That(successfullProductAdditionMessage.Contains(quantitytoSelect), Is.True);*/

            }

            [Test]

            public void VerifyThatUsersAreAbleToSuccessfullyLogoutFromTheirAccount()
            {
                var loginPage = new LandingPage().GotoLoginPage();
                Thread.Sleep(1000);
                var username = VariableValueReader.ReadVariableValue(BasePage.PathToFileEnvironmentVariableFile, TestContext.Parameters["loginUsername"]);
                var password = VariableValueReader.ReadVariableValue(BasePage.PathToFileEnvironmentVariableFile, TestContext.Parameters["loginPassword"]);
                var userHomepage = loginPage.LoginToApplication(username, password);
                var signBtn = LocateElement("//button[@aria-label='My account']");
                MoveToAnElement(signBtn);
                IWebElement signoutBtn = LocateElement("//li//a//span[.='Sign out']");
                MoveToElementAndClick(signoutBtn);
                Thread.Sleep(3000);


                var isSigninBtnDisplay = Driver.FindElement(By.XPath("//p[.='Sign in']")).Displayed;
                Assert.That(isSigninBtnDisplay, Is.True);

            }

           /* private void SelectProduct(string productName)
            {
                //ScrollDown(0.2);
                IWebElement productToSelect = Driver.FindElement(By.XPath($"//h2[.='{productName}']")); //h2[.='Full Sun Routine']
                BringElementToPageCenter(productToSelect);
                _actions.MoveToElement(productToSelect).Click().Perform();
            }

            public void BringElementToPageCenter(IWebElement element)
            {
                Thread.Sleep(1000);
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(({behavior: 'auto',block: 'center',inline: 'center'}))", element);
                Thread.Sleep(1000);
            }

            public void ScrollDown()
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            }

            public void ScrollDown(double desiredHeight)
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight*" + desiredHeight + ")");
            }

            private void ChooseFilterColour(string filterColour)
            {
                Driver.FindElement(By.XPath($"//span[.='Colour']/../following-sibling::div//ul//li//input[@id='{filterColour}-Colour']")).Click();
            }

            private void SelectedProductSize(string filterBabySizes)
            {
                var filterItemElement = Driver.FindElement(By.XPath($"//span[.='Baby Sizes']/../following-sibling::div//ul//li//input[@id='{filterBabySizes}-Baby Sizes']"));
                filterItemElement.Click();
            }*/



            [TearDown]
            public void CloseResource()
            {
                Driver.Close();
                Driver.Quit();
            }
        }
    }
}
