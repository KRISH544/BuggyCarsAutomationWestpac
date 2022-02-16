using BuggyCarsAutomation.Models;
using BuggyCarsAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BuggyCarsAutomation.Steps
{
    [Binding]
    class LoginSteps
    {

        private HomePage homePage;
        private IWebDriver webDriver;
        public LoginSteps(IWebDriver driver, HomePage homePage)
        {
            this.webDriver = driver;
            this.homePage = homePage;
        }

        [Given(@"BuggyCars home page is loaded")]
        public void GivenBuggyCarsHomePageIsLoaded()
        {
            webDriver.Navigate().GoToUrl("https://buggy.justtestit.org");
        }

        [When(@"user inputs creditials")]
        public void WhenUserInputsCreditials(Table table)
        {
            var userDetails = table.CreateInstance<User>();
            homePage.LoginToAccount(userDetails);
        }

        [Then(@"click on Login button")]
        public void ThenClickOnLoginButton()
        {
            homePage.ClickLoginButton();
        }

        [Then(@"user ""(.*)"" is successfully logged in")]
        public void ThenUserIsSuccessfullyLoggedIn(string loggedInUserName)
        {
            Assert.AreEqual("Hi, " + loggedInUserName, homePage.GetUserLoggedInText(), "User is not logged in successfully");
        }

        [Then(@"""(.*)"" message is displayed")]
        public void ThenMessageIsDisplayed(string errorMsg)
        {
            Assert.AreEqual(errorMsg, homePage.GetLoginError(), "Error message is not displayed or inccorect");
        }

        [When(@"profile is clicked on")]
        public void WhenProfileIsClickedOn()
        {
            homePage.ClickProfile();
            Thread.Sleep(1500);
        }
    }
}
