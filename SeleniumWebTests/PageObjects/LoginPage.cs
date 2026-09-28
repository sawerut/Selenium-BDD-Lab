using OpenQA.Selenium;

namespace SeleniumWebTests.PageObjects
{
    public class LoginPage
    {
        private IWebDriver _driver;
        public LoginPage(IWebDriver driver) { _driver = driver; }

        private IWebElement UsernameField => _driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));

        public void GoToPage()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        public void Login(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }
    }
}