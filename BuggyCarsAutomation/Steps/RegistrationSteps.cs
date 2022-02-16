using BuggyCarsAutomation.Models;
using BuggyCarsAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace BuggyCarsAutomation.Steps
{
    [Binding]
    public class RegistrationSteps
    {

        private RegistrationPage registrationPage;
        private IWebDriver webDriver;
        public RegistrationSteps(IWebDriver driver, RegistrationPage registrationPage)
        {
            this.webDriver = driver;
            this.registrationPage = registrationPage;
        }

        [Given(@"BuggyCars registration page is loaded")]
        public void GivenBuggyCarsRegistrationPageIsLoaded()
        {
            webDriver.Navigate().GoToUrl("https://buggy.justtestit.org/register");
        }

        [When(@"the information is inputted in")]
        public void WhenTheInformationIsInputtedIn(Table table)
        {
            var userDetails = table.CreateInstance<User>();
            registrationPage.inputValues(userDetails);
        }


        [Then(@"click on the Register button")]
        public void ThenClickOnTheRegisterButton()
        {
            registrationPage.clickRegister();
            
        }

        [Then(@"registration is successful message is displayed")]
        public void ThenRegistrationIsSuccessfulMessageIsDisplayed()
        {
            Assert.AreEqual("Registration is successful", registrationPage.GetSuccessText(), "Copytexts do not match");
        }

        [Then(@"registration is unsuccessful message is displayed")]
        public void ThenRegistrationIsUnsuccessfulMessageIsDisplayed()
        {
            Thread.Sleep(1000);
            Assert.IsTrue(registrationPage.GetErrorMsg()); 
        }


    }
}
