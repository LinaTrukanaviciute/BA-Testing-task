using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BA_Automation.Pages
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static HomePage homePage;
        public static SearchResultPage searchResultPage;
        public static ShoppingCartPage shoppingCartPage;
        public static SignInPage signInPage;
        public static AdressConfirmationPage adressConfirmationPage;
        public static ShippingPage shippingPage;
        public static PaymentMethodPage paymentMethodPage;
        public static OrderConfirmationPage orderConfirmationPage;

        [OneTimeSetUp]

        public static void OneTimeSetUp()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
            searchResultPage = new SearchResultPage(driver);
            shoppingCartPage = new ShoppingCartPage(driver);
            signInPage = new SignInPage(driver);
            adressConfirmationPage = new AdressConfirmationPage(driver);
            shippingPage = new ShippingPage(driver);
            paymentMethodPage = new PaymentMethodPage(driver);
            orderConfirmationPage = new OrderConfirmationPage(driver);
        }

        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }

        [TearDown]
        public static void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                FailureScreenshot.TakeScreenshot(driver);
            }
        }
    }
}
