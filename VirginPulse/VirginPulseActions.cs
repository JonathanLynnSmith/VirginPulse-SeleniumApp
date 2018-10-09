using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace VirginPulse
{
    class VirginPulseActions
    {
        public void login()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                //Login
                driver.Navigate().GoToUrl("https://iam.virginpulse.com");
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                wait.Until(d => d.FindElement(By.Id("kc-login")));
                IWebElement usernameField = driver.FindElement(By.Id("username"));
                IWebElement passwordField = driver.FindElement(By.Id("password"));
                IWebElement loginButton = driver.FindElement(By.Id("kc-login"));

                wait.Until(ExpectedConditions.ElementToBeClickable(usernameField));
                wait.Until(ExpectedConditions.ElementToBeClickable(passwordField));

                usernameField.Click();
                usernameField.SendKeys("Jonathanlynnsmith@gmail.com");
                passwordField.Click();
                passwordField.SendKeys("1Whumpop!");
                loginButton.Click();
            }
        }
    }
}
