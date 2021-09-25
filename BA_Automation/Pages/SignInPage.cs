using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BA_Automation.Pages
{
    public class SignInPage : BasePage
    {
        private IWebElement _emailInput => Driver.FindElement(By.Id("email"));
        private IWebElement _passwordInput => Driver.FindElement(By.Id("passwd"));
        private IWebElement _signIn => Driver.FindElement(By.Id("SubmitLogin"));
        public SignInPage(IWebDriver webDriver) : base(webDriver) { }

        public void PutSignInDetailsAndClickSignInButton()
        {
            string email = "yayagob580@timevod.com";
            int numb = 12345;
            string password = Convert.ToString(numb);
            GetWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("email")));
            _emailInput.SendKeys(email);
            _passwordInput.SendKeys(password);
            _signIn.Click();
        }
    }
}
