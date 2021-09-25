using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace BA_Automation.Pages
{
    public class SearchResultPage : BasePage
    {
        public SearchResultPage(IWebDriver webDriver) : base(webDriver) { }
        private IWebElement _productTitle => Driver.FindElement(By.CssSelector("li.ajax_block_product:nth-child(1) > div:nth-child(1) > div:nth-child(2) > h5:nth-child(1) > a:nth-child(1)"));
        private IWebElement _addItemToBasketButton => Driver.FindElement(By.CssSelector("li.ajax_block_product:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(4) > a:nth-child(1)"));

        public string DisplayedProductTitle()
        {
            GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("li.ajax_block_product:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > a:nth-child(1) > img:nth-child(1)")));
            IWebElement displaydProduct = Driver.FindElement(By.CssSelector("li.ajax_block_product:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > a:nth-child(1) > img:nth-child(1)"));
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li.ajax_block_product:nth-child(1) > div:nth-child(1) > div:nth-child(2) > h5:nth-child(1) > a:nth-child(1)")));
            return _productTitle.Text;
        }

        public void PressAddItemToBasket()
        {
            IWebElement displaydProduct = Driver.FindElement(By.CssSelector("li.ajax_block_product:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > a:nth-child(1) > img:nth-child(1)"));
            GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("li.ajax_block_product:nth-child(1) > div:nth-child(1) > div:nth-child(1) > div:nth-child(1) > a:nth-child(1) > img:nth-child(1)")));

            Actions action = new Actions(Driver);
            action.MoveToElement(displaydProduct).Perform();

            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("li.ajax_block_product:nth-child(1) > div:nth-child(1) > div:nth-child(2) > div:nth-child(4) > a:nth-child(1)")));
            _addItemToBasketButton.Click();
        }

        public void ClickProceedToCheckout()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a")));
            IWebElement proceedToCheckoutButton = Driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a"));
            proceedToCheckoutButton.Click();

        }
    }
}
