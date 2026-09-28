using OpenQA.Selenium;

namespace SeleniumWebTests.PageObjects
{
    public class InventoryPage
    {
        private IWebDriver _driver;
        public InventoryPage(IWebDriver driver) { _driver = driver; }

        // Використовуємо точний ID першого товару замість CSS-класу
        private IWebElement FirstAddToCartButton => _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));

        private IWebElement ShoppingCartBadge => _driver.FindElement(By.ClassName("shopping_cart_badge"));

        public void AddFirstItemToCart()
        {
            FirstAddToCartButton.Click();
        }

        public string GetCartBadgeText()
        {
            return ShoppingCartBadge.Text;
        }
    }
}