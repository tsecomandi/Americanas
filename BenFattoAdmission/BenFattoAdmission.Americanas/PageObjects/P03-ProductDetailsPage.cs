using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System;
using NUnit.Framework;

namespace BenFattoAdmission.Americanas.PageObjects
{
    [Binding]
    public class ProductDetailsPage
    {
        public IWebDriver driver { get; set; }
        WebDriverWait wait { get; set; }
        private ScenarioContext scenarioContext { get; set; }

        public ProductDetailsPage(IWebDriver driver, ScenarioContext scenarioContext)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(15));
            this.scenarioContext = scenarioContext;
        }

        #region Elements
        By imgProductPicture = By.XPath("//div[contains(@class,'WrapperItem')]//div[contains(@class,'WrapperImages')]//picture/img");
        By lblProductFullName = By.XPath("//div[contains(@class,'ProductInfo')]//span[contains(@class,'Title')]");
        By lblProductDescription = By.XPath("//div[contains(@class,'ProductInfo')]//span[contains(@class,'description-text')]");
        By lblProductPrice = By.XPath("//div[contains(@class,'BestPrice')]");
        By btnAddToCart= By.Id("buy-button");
        #endregion

        #region When
        [When(@"I click on the button labeled comprar on product detail screen")]
        public void WhenIClickOnTheButtonLabeledComprarOnProductDetailScreen()
        {
            driver.FindElement(btnAddToCart).Click();
        }
        #endregion

        #region Then
        [Then(@"a screen containing the product details is displayed")]
        public void ThenAScreenContainingTheProductDetailsIsDisplayed()
        {
            wait.Until(c => c.FindElement(imgProductPicture));
            wait.Until(c => c.FindElement(lblProductFullName));
            scenarioContext["productFullName"] = driver.FindElement(lblProductFullName).Text;
            wait.Until(c => c.FindElement(lblProductDescription));
            scenarioContext["productDescription"] = driver.FindElement(lblProductDescription).Text;
            wait.Until(c => c.FindElement(lblProductPrice));
            scenarioContext["productPrice"] = driver.FindElement(lblProductPrice).Text;
            wait.Until(c => c.FindElement(btnAddToCart));
            Assert.AreEqual("comprar", driver.FindElement(btnAddToCart).Text);
        }
        #endregion
    }
}
