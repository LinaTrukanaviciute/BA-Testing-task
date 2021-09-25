using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BA_Automation.Pages
{
    public class OrderConfirmationPage : BasePage
    {
        public OrderConfirmationPage(IWebDriver webDriver) : base(webDriver) { }

        private IWebElement _orderConfirmationText => Driver.FindElement(By.CssSelector("#center_column > div > p > strong"));

        public string OrderConfirmText()
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#center_column > div > p > strong")));
            return _orderConfirmationText.Text;
        }
    }
}
