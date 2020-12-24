using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.IO;
using System;
using BoDi;

namespace BenFattoAdmission.Americanas.PageObjects
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer container;
        string screenshotFolder;
        int screenshotCounter = 1;

        public Hooks(IObjectContainer container)
        {
            this.container = container;
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            Console.WriteLine(projectPath);
            screenshotFolder = projectPath + @"\Screenshots\";
        }

        [BeforeScenario]
        public void ScenarioSetup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterStep]
        public void TakeScreenshot()
        {
            Directory.CreateDirectory(screenshotFolder);
            var driver = container.Resolve<IWebDriver>();
            ITakesScreenshot snapper = driver as ITakesScreenshot;
            Screenshot screenshot = snapper.GetScreenshot();
            screenshot.SaveAsFile(screenshotFolder + "Screenshot_" + screenshotCounter + ".png");
            screenshotCounter++;
        }

        [AfterScenario]
        public void ScenarioTeardown()
        {
            var driver = container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
