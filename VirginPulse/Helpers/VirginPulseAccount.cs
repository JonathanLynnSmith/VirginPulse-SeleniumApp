using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace VirginPulse.Helpers
{
        class VirginPulseAccount : AccountInformation
    {
        private IWebDriver driver = new FirefoxDriver();
        public void Login(string myUsername, string myPassword)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://iam.virginpulse.com");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("username")));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("password")));

            IWebElement usernameField = driver.FindElement(By.Id("username"));
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            IWebElement loginButton = driver.FindElement(By.Id("kc-login"));

            System.Threading.Thread.Sleep(3000);
            usernameField.Click();
            usernameField.SendKeys(myUsername);
            passwordField.Click();
            passwordField.SendKeys(myPassword);
            loginButton.Click();
        }
        public void CompleteTwoCards()
        {
            ClickCardIcon();
            ClickCards();
            CloseModal();
        }
        public void CompleteThreeHabits()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement healthyHabitsIcon = driver.FindElement(By.CssSelector(".hh-icon-wrapper"));
            healthyHabitsIcon.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".yes-btn")));
            var yesButtons = driver.FindElements(By.CssSelector(".yes-btn"));
            yesButtons[0].Click();
            CloseModal();
            yesButtons[1].Click();
            CloseModal();
            yesButtons[2].Click();
            CloseModal();
        }
        private void ClickCardIcon()
        {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("core-menuitem-benefits")));
                IWebElement cardsIcon = driver.FindElement(By.CssSelector(".dialy-tips-circle"));
                try { IWebElement firstCard = driver.FindElement(By.Id("triggerCloseCurtain")); } catch { cardsIcon.Click(); }
        }
        private void ClickCards()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("triggerCloseCurtain")));
                IWebElement dailyTipCards = driver.FindElement(By.Id("triggerCloseCurtain"));
                dailyTipCards.Click();
                IWebElement nextCardButton = driver.FindElement(By.ClassName("next-card-btn"));
                nextCardButton.Click();
                System.Threading.Thread.Sleep(2000);
                dailyTipCards = driver.FindElement(By.Id("triggerCloseCurtain"));
                dailyTipCards.Click();
            }
            catch
            {
                Console.WriteLine("Unable to complete Cards");
            }
        }
        private void CloseAwardCard()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("trophy-modal-close-btn")));
                IWebElement closeAwardCard = driver.FindElement(By.Id("trophy-modal-close-btn"));
                closeAwardCard.Click();
            }
            catch
            {
                Console.WriteLine("No award card detected");
            }
        }
        private void CloseModal()
        {
            try {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".close-modal-btn")));
                var modals = driver.FindElements(By.CssSelector(".close-modal-btn"));
                foreach(var m in modals)
                {
                    m.Click();
                }
            }
            catch{}
        }
    }
}
