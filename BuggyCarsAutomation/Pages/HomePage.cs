using BuggyCarsAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace BuggyCarsAutomation.Pages
{
    public class HomePage
    {
        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LoginToAccount(User userDetails)
        {
            IWebElement login = driver.FindElement(By.CssSelector("input[name = 'login']"));
            IWebElement userPassword = driver.FindElement(By.CssSelector("input[name = 'password']"));

            login.SendKeys(userDetails.Username);
            userPassword.SendKeys(userDetails.Password);
        }

        public void ClickLoginButton()
        {
            driver.FindElement(By.CssSelector("button")).Click();
        }

        public string GetUserLoggedInText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement elem = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("span")));
            return elem.Text;
        }

        public string GetLoginError()
        {
            Thread.Sleep(5000);
            return driver.FindElement(By.CssSelector("span")).Text;
        }

        public void ClickProfile()
        {
            driver.FindElement(By.CssSelector("a[href='/profile']")).Click();
        }
    }
}
