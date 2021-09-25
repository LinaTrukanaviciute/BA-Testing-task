using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace BA_Automation.Pages
{
    public class PaymentMethodPage : BasePage
    {
        public PaymentMethodPage(IWebDriver webDriver) : base(webDriver) { }
        private IWebElement _payByBankWire => Driver.FindElement(By.CssSelector("#HOOK_PAYMENT > div:nth-child(1) > div > p > a"));
        private IWebElement _payByCheck => Driver.FindElement(By.CssSelector("#HOOK_PAYMENT > div:nth-child(2) > div > p > a"));
        private IWebElement _confirmButton => Driver.FindElement(By.CssSelector("#cart_navigation > button"));

        //# HOOK_PAYMENT > div:nth-child(1) > div > p > a

        public List<string> ReturnValidPaymentOptions()
        {
            List<string> PaymentOptions = new List<string>();

            string PaymentOption1 = Driver.FindElement(By.CssSelector("#HOOK_PAYMENT > div:nth-child(1) > div > p > a")).Text;
            string PaymentOption2 = Driver.FindElement(By.CssSelector("#HOOK_PAYMENT > div:nth-child(2) > div > p > a")).Text;

            PaymentOptions.Add(PaymentOption1); //0
            PaymentOptions.Add(PaymentOption2); //1

            return PaymentOptions;
        }

        public void ClickPaymentOption1()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#HOOK_PAYMENT > div:nth-child(2) > div > p > a")));
            _payByBankWire.Click();
        }

        public void ClickConfirmOrder()
        {
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#cart_navigation > button")));
            _confirmButton.Click();
        }
    }
}
