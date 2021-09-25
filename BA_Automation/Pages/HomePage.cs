using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BA_Automation.Pages
{
    public class HomePage : BasePage
    {
        private const string _pageAddress = "http://automationpractice.com/index.php";
        private IWebElement _searchField => Driver.FindElement(By.Id("search_query_top"));
        private IWebElement _searchButton => Driver.FindElement(By.CssSelector("button.btn:nth-child(5)"));

        public HomePage(IWebDriver webDriver) : base(webDriver) { }

        public void NavigateToPage()
        {
            if (Driver.Url != _pageAddress)
                Driver.Url = _pageAddress;
        }

        public void SearchByText(string textToSearch)
        {

            _searchField.Clear();
            _searchField.SendKeys(textToSearch);
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.btn:nth-child(5)")));
            _searchButton.Click();
        }
    }
}
