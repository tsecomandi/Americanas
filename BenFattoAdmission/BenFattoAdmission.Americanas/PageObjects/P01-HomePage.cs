using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System;

namespace BenFattoAdmission.Americanas.PageObjects
{
    [Binding]
    public class HomePage
    {
        public IWebDriver driver { get; set; }
        public WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(15));
        }

        #region Elements
        By imgLogoAmericanas = By.Id("brd-link");
        By txtBusqueSeuProduto = By.Id("h_search-input");
        #endregion

        #region Given
        [Given(@"that I am in Americanas home page")]
        public void GivenThatIAmInAmericanasHomePage()
        {
            driver.Navigate().GoToUrl("https://www.americanas.com");
            wait.Until(c => c.FindElement(imgLogoAmericanas));
        }
        #endregion

        #region When
        [When(@"I search for a product using the word ""(.*)""")]
        public void WhenISearchForAProductUsingTheWord(string textToSearch)
        {
            wait.Until(c => c.FindElement(txtBusqueSeuProduto));
            driver.FindElement(txtBusqueSeuProduto).SendKeys(textToSearch + Keys.Enter);
        }
        #endregion
    }
}
