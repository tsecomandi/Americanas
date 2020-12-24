using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace BenFattoAdmission.Americanas.PageObjects
{
    [Binding]
    public class ExtendedWarrantyPage
    {
        public IWebDriver driver { get; set; }
        WebDriverWait wait { get; set; }

        public ExtendedWarrantyPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(15));
        }

        #region Elements
        By lblHeaderExtendedWarranty = By.XPath("//h1");
        By lblSubHeaderExtendedWarranty = By.XPath("//div[@class='service-flow--title']//p");
        By btnContinue = By.Id("btn-continue");
        #endregion

        #region When
        [When(@"I click on continuar button on extended warranty screen")]
        public void WhenIClickOnContinuarButtonOnExtendedWarrantyScreen()
        {
            driver.FindElement(btnContinue).Click();
        }
        #endregion

        #region Then
        [Then(@"I should see a screen containing information about extended warranty is displayed")]
        public void ThenIShouldSeeAScreenContainingInformationAboutExtendedWarrantyIsDisplayed()
        {
            wait.Until(c => c.FindElement(lblHeaderExtendedWarranty));
            Assert.AreEqual("Agora que você já escolheu seu produto, saiba como protegê-lo por mais tempo.", driver.FindElement(lblHeaderExtendedWarranty).Text);
            wait.Until(c => c.FindElement(lblSubHeaderExtendedWarranty));
            Assert.AreEqual("A contratação de seguros é opcional", driver.FindElement(lblSubHeaderExtendedWarranty).Text);
            wait.Until(c => c.FindElement(btnContinue));
        }
        #endregion
    }
}
