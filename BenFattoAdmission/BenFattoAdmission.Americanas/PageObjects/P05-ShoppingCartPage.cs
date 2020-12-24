using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace BenFattoAdmission.Americanas.PageObjects
{
    [Binding]
    public class ShoppingCartPage
    {
        public IWebDriver driver { get; set; }
        WebDriverWait wait { get; set; }
        private ScenarioContext scenarioContext { get; set; }

        public ShoppingCartPage(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(15));
            this.scenarioContext = scenarioContext;
        }

        #region Elements
        By lblHeaderShoppingCart = By.CssSelector(".page-title");
        By tblProductList = By.CssSelector(".basket-products");
        By lblProductName = By.CssSelector(".basket-productTitle");
        By lblProductPrice = By.CssSelector(".basket-productPrice");
        By btnContinue = By.Id("buy-button");
        By btnRemoveItem = By.CssSelector(".basket-productRemoveAct");
        By tblEmptyShoppingCart = By.CssSelector(".basket-empty");
        By lblEmptyShoppingCart = By.XPath("//section[contains(@class,'basket-empty')]//h2");
        #endregion

        #region When
        [When(@"I click on the button labeled remover on the desired item")]
        public void WhenIClickOnTheButtonLabeledRemoverOnTheDesiredItem()
        {
            driver.FindElement(btnRemoveItem).Click();
        }
        #endregion

        #region Then
        [Then(@"I should see my shopping cart with the item listed in it")]
        public void ThenIShouldSeeMyShoppingCartWithTheItemListedInIt()
        {
            wait.Until(c => c.FindElement(lblHeaderShoppingCart));
            Assert.AreEqual("minha cesta", driver.FindElement(lblHeaderShoppingCart).Text);
            wait.Until(c => c.FindElement(tblProductList));
            wait.Until(c => c.FindElement(lblProductName));
            Assert.AreEqual(scenarioContext["productFullName"], driver.FindElement(lblProductName).Text);
            wait.Until(c => c.FindElement(lblProductPrice));
            Assert.AreEqual(scenarioContext["productPrice"], driver.FindElement(lblProductPrice).Text);
            wait.Until(c => c.FindElement(btnRemoveItem));
            wait.Until(c => c.FindElement(btnContinue));
        }

        [Then(@"I should see an empty shopping cart")]
        public void ThenIShouldSeeAnEmptyShoppingCart()
        {
            wait.Until(c => c.FindElement(tblEmptyShoppingCart));
            wait.Until(c => c.FindElement(lblEmptyShoppingCart));
            Assert.AreEqual("sua cesta está vazia", driver.FindElement(lblEmptyShoppingCart).Text);
        }
        #endregion
    }
}
