using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BA_Automation.Pages
{
    public class ShippingPage : BasePage
    {
        public ShippingPage(IWebDriver webDriver) : base(webDriver) { }
        private IWebElement _agreeCheckBoxTic => Driver.FindElement(By.Id("uniform-cgv"));
        private IWebElement _proceedToCheckoutButton => Driver.FindElement(By.CssSelector("#form > p > button"));
        public void AgreeToTermsOfServiceCheckBox()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("uniform-cgv")));
            _agreeCheckBoxTic.Click();
        }

        public void CklickProceedToCheckout()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#form > p > button")));
            _proceedToCheckoutButton.Click();
        }





    }
}
