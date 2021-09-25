using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BA_Automation.Pages
{
    public class AdressConfirmationPage : BasePage
    {
        public AdressConfirmationPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement _proceedToCheckoutButton => Driver.FindElement(By.CssSelector("button.button:nth-child(4)"));

        public void CklickProceedToCheckout()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.button:nth-child(4)")));
            _proceedToCheckoutButton.Click();
        }
    }
}
