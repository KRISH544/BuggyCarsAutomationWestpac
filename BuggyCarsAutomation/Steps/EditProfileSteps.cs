using BuggyCarsAutomation.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow.Assist;
using BuggyCarsAutomation.Models;

namespace BuggyCarsAutomation.Steps
{
    [Binding]
    public class EditProfileSteps
    {
        private EditProfilePage editProfilePage;
        private  IWebDriver webDriver;
        public EditProfileSteps(IWebDriver driver, EditProfilePage editProfilePage)
        {
            this.webDriver = driver;
            this.editProfilePage = editProfilePage;
        }

        [Then(@"the profile page is displayed")]
        public void ThenTheProfilePageIsDisplayed()
        {
            string URL = webDriver.Url;
            Assert.AreEqual(URL, "https://buggy.justtestit.org/profile");
        }

        [Then(@"input the info to change password")]
        public void ThenInputTheInfoToChangePassword(Table table)
        {
            var userDetails = table.CreateInstance<User>();
            editProfilePage.inputCreditials(userDetails);
        }

        [When(@"user clicks on ""(.*)""")]
        public void WhenUserClicksOn(string button)
        {
            editProfilePage.ClickButton(button);
        }

        [Then(@"success message is displayed")]
        public void ThenSuccessMessageIsDisplayed()
        {
            Assert.IsTrue(editProfilePage.GetSuccessMsg());
        }

        [Then(@"user updates basic info")]
        public void ThenUserUpdatesBasicInfo(Table table)
        {
            var userDetails = table.CreateInstance<User>();
            editProfilePage.inputName(userDetails);
        }
    }
}
