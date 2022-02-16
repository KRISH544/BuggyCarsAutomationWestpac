using BuggyCarsAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace BuggyCarsAutomation.Pages
{
    public class RegistrationPage 
    {
        IWebDriver driver;
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void inputValues(User userDetails)
        {
            IWebElement login = driver.FindElement(By.Id("username"));
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            IWebElement userPassword = driver.FindElement(By.Id("password"));
            IWebElement confirmUserPassword = driver.FindElement(By.Id("confirmPassword"));
            int randomUsernameString = RandomString();

            login.SendKeys(randomUsernameString + userDetails.Username);
            firstName.SendKeys(userDetails.Firstname);
            lastName.SendKeys(userDetails.Lastname);
            userPassword.SendKeys(userDetails.Password);
            confirmUserPassword.SendKeys(userDetails.PasswordComfirmation);
        }

        public void clickRegister()
        {
            driver.FindElement(By.XPath("//*[@class = 'btn btn-default']")).Click();
        }

        public string GetSuccessText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div[class = 'result alert alert-success']")));
            return driver.FindElement(By.CssSelector("div[class = 'result alert alert-success']")).Text;
        }

        public bool GetErrorMsg()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement elem = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div[class = 'result alert alert-danger']")));
            return elem.Displayed;
        }

        public int RandomString()
        {
            Random r = new Random();
            int min = 1000;
            int max = 10000;
            return r.Next(min, max);
        }
    }
}

