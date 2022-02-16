using BoDi;
using BuggyCarsAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace BuggyCarsAutomation.Steps
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer objectContainer;
        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }


      [BeforeScenario]
      public void setUp()
        {
            var webDriver = new ChromeDriver();
            this.objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
        }


      [AfterScenario]
      public void cleanUp()
        {
            var webDriver = this.objectContainer.Resolve<IWebDriver>();
            if(webDriver != null)
            {
                webDriver.Quit();
            }
        }
    }
}
