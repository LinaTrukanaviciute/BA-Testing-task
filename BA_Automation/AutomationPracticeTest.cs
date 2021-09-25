using NUnit.Framework;
using System.Collections.Generic;

namespace BA_Automation.Pages
{
    public class AutomationPracticeTest : BaseTest
    {
        public static string expectedProductName = "Dress";

        [Test]
        public static void CheckIfFirstDisplayedProductMatchesTheSearch()
        {

            homePage.NavigateToPage();
            homePage.SearchByText(expectedProductName);
            string actualProductName = searchResultPage.DisplayedProductTitle();

            Assert.IsTrue(actualProductName.Contains(expectedProductName), $"First displayd product does not contain search phrase, expected'{expectedProductName}' actual '{actualProductName}'");
        }

        [Test]
        public static void CheckIfProductIsVisibleInShoppingCart()
        {
            homePage.NavigateToPage();
            homePage.SearchByText(expectedProductName);
            searchResultPage.PressAddItemToBasket();
            searchResultPage.ClickProceedToCheckout();
            string productIsVisableInCart = shoppingCartPage.AddedProductIsVisibleInShoppingCart();
            Assert.IsTrue(productIsVisableInCart.Contains(expectedProductName), "Picked product is not visible in shopping cart");
        }

        [Test]
        public static void VerifyCheckoutPaymentOptions()
        {
            string expectedByBankWire = "Pay by bank wire (order processing will be longer)";
            string expectedByCheck = "Pay by check (order processing will be longer)";
            List<string> expectedValidPaimentmethods = new List<string>() { expectedByBankWire, expectedByCheck };
            homePage.NavigateToPage();
            homePage.SearchByText(expectedProductName);
            searchResultPage.PressAddItemToBasket();
            searchResultPage.ClickProceedToCheckout();
            shoppingCartPage.CklickProceedToCheckOut();
            signInPage.PutSignInDetailsAndClickSignInButton();
            adressConfirmationPage.CklickProceedToCheckout();
            shippingPage.AgreeToTermsOfServiceCheckBox();
            shippingPage.CklickProceedToCheckout();
            List<string> actualValidPaimentmethods = paymentMethodPage.ReturnValidPaymentOptions();

            Assert.AreEqual(actualValidPaimentmethods, expectedValidPaimentmethods, "Payment page does not have expected valid payment methods");
        }

        [Test]
        public static void CheckIfOrderHasConfirmation()
        {
            string expectedOrderConfirmation = "Your order on My Store is complete.";
            homePage.NavigateToPage();
            homePage.SearchByText(expectedProductName);
            searchResultPage.PressAddItemToBasket();
            searchResultPage.ClickProceedToCheckout();
            shoppingCartPage.CklickProceedToCheckOut();
            signInPage.PutSignInDetailsAndClickSignInButton();
            adressConfirmationPage.CklickProceedToCheckout();
            shippingPage.AgreeToTermsOfServiceCheckBox();
            shippingPage.CklickProceedToCheckout();
            paymentMethodPage.ClickPaymentOption1();
            paymentMethodPage.ClickConfirmOrder();
            string actualOrderMessage = orderConfirmationPage.OrderConfirmText();
            Assert.IsTrue(actualOrderMessage.Contains(expectedOrderConfirmation), $"You order is not comfirmed expected '{expectedOrderConfirmation}' actual message '{actualOrderMessage}'");
        }
    }
}
