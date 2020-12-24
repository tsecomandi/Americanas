using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System;

namespace BenFattoAdmission.Americanas.PageObjects
{
    [Binding]
    public class SearchResultsPage
    {
        public IWebDriver driver { get; set; }
        WebDriverWait wait { get; set; }
        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
        }

        #region Elements
        By tblSearchResults = By.XPath("//div[contains(@class,'StyledGrid')][not(contains(@class,'GridUI'))]");
        By divFirstElement = By.XPath("//div[contains(@class,'ColGridItem')][1]");
        By lblNameFirstElement = By.XPath("(//div[contains(@class,'ColGridItem')][1]//span)[1]");
        #endregion

        #region When
        [When(@"I click on the first product from the result list")]
        public void WhenIClickOnTheFirstProductFromTheResultList()
        {
            driver.FindElement(lblNameFirstElement).Click();
        }

        #endregion

        #region Then
        [Then(@"a screen containing the search results is displayed")]
        public void ThenAScreenContainingTheSearchResultsIsDisplayed()
        {
            wait.Until(c => c.FindElement(tblSearchResults));
            wait.Until(c => c.FindElement(divFirstElement));
            wait.Until(c => c.FindElement(lblNameFirstElement));
        }
        #endregion
    }
}
