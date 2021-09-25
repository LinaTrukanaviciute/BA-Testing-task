using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA_Automation.Pages

{
    public class ShoppingCartPage : BasePage
    {
        public ShoppingCartPage(IWebDriver webDriver) : base(webDriver) { }
        private IWebElement _displaydProduct => Driver.FindElement(By.CssSelector("td.cart_description > p:nth-child(1) > a:nth-child(1)"));
        private IWebElement _proceedToCheckout => Driver.FindElement(By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium"));

        public string AddedProductIsVisibleInShoppingCart()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("td.cart_description > p:nth-child(1) > a:nth-child(1)")));
            return _displaydProduct.Text;
        }

        public void CklickProceedToCheckOut()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium")));
            _proceedToCheckout.Click();
        }


    }
}
