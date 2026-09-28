using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebTests.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace SeleniumWebTests.StepDefinitions
{
    [Binding]
    public class AddToCartSteps
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private InventoryPage _inventoryPage;

        [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver();
            // Невелика затримка очікування елементів (важливо для performance_glitch_user)
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();

            _loginPage = new LoginPage(_driver);
            _inventoryPage = new InventoryPage(_driver);
        }

        [Given(@"Я знаходжусь на сторінці логіну SauceDemo")]
        public void GivenЯЗнаходжусьНаСторінціЛогінуSauceDemo()
        {
            _loginPage.GoToPage();
            System.Threading.Thread.Sleep(1000); // Секундна пауза після відкриття сайту
        }

        [When(@"Я вводжу логін ""(.*)"" та пароль ""(.*)""")]
        public void WhenЯВводжуЛогінТаПароль(string username, string password)
        {
            _loginPage.Login(username, password);
            System.Threading.Thread.Sleep(6000); // Збільшена пауза через performance_glitch_user
        }

        [When(@"Я натискаю кнопку Add to cart для першого товару")]
        public void WhenЯНатискаюКнопкуAddToCartДляПершогоТовару()
        {
            _inventoryPage.AddFirstItemToCart();
            System.Threading.Thread.Sleep(2000); // 2 секунди паузи після додавання товару
        }

        [Then(@"На іконці кошика має відображатися цифра ""(.*)""")]
        public void ThenНаІконціКошикаМаєВідображатисяЦифра(string expectedCount)
        {
            string actualCount = _inventoryPage.GetCartBadgeText();
            // Оновлений синтаксис Assert для 4-ї версії NUnit
            Assert.That(actualCount, Is.EqualTo(expectedCount), "Кількість товарів у кошику не збігається.");
            System.Threading.Thread.Sleep(1000); // Ще секунда паузи перед закриттям
        }

        [AfterScenario]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}