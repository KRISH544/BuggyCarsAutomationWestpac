using BuggyCarsAutomation.Models;
using OpenQA.Selenium;
using System.Threading;

namespace BuggyCarsAutomation.Pages
{
    public class EditProfilePage
    {
        IWebDriver driver;
        public EditProfilePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void inputCreditials(User userDetails)
        {
            IWebElement currentPassword = driver.FindElement(By.Id("currentPassword"));
            IWebElement newPassword = driver.FindElement(By.Id("newPassword"));
            IWebElement confirmPassword = driver.FindElement(By.Id("newPasswordConfirmation"));

            currentPassword.SendKeys(userDetails.Password);
            newPassword.SendKeys(userDetails.NewPassword);
            confirmPassword.SendKeys(userDetails.PasswordComfirmation);
        }

        public void ClickButton(string button)
        {
            driver.FindElement(By.CssSelector("button[type='" + button + "']")).Click();
            Thread.Sleep(2000); 
        }

        public bool GetSuccessMsg()
        {
            return driver.FindElement(By.CssSelector("div[class='result alert alert-success hidden-md-down']")).Displayed;
        }

        public void inputName(User userDetails)
        {
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            IWebElement lastName = driver.FindElement(By.Id("lastName"));

            firstName.SendKeys(Keys.Control + "a");
            firstName.SendKeys(userDetails.Firstname);
            lastName.SendKeys(Keys.Control + "a");  
            lastName.SendKeys(userDetails.Lastname);
        }
    }
}
