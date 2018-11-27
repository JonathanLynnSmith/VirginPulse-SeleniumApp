using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Configuration;
using VirginPulse.Settings;

namespace VirginPulse
{
    class VirginPulseAutomation
    {
        private IWebDriver driver = CreateHeadlessFirefoxDriver();
        private static IWebDriver CreateHeadlessFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.AddArguments("-headless");
            var service = FirefoxDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            return new FirefoxDriver(service,options);
        }    
        public void Login(string myUsername, string myPassword)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("VirginPulseUrl"));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(VirginPulseAccountSettings.usernameId)));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(VirginPulseAccountSettings.passwordId)));

                IWebElement usernameField = driver.FindElement(By.Id(VirginPulseAccountSettings.usernameId));
                IWebElement passwordField = driver.FindElement(By.Id(VirginPulseAccountSettings.passwordId));
                IWebElement loginButton = driver.FindElement(By.Id(VirginPulseAccountSettings.loginButtonId));

                System.Threading.Thread.Sleep(3000);
                usernameField.Click();
                usernameField.SendKeys(myUsername);
                passwordField.Click();
                System.Threading.Thread.Sleep(1000);
                passwordField.SendKeys(myPassword);
                loginButton.Click();
            }
            catch (Exception ex)
            {
                Windows.Log(ex.ToString());
            }

        }
        public void CompleteTwoCards()
        {
            ClickCardIcon();
            ClickCards();
            CloseAllModals();
        }
        public void CompleteThreeHabits()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                IWebElement healthyHabitsIcon = driver.FindElement(By.CssSelector(".hh-icon-wrapper"));
                healthyHabitsIcon.Click();
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".yes-btn")));
                var yesButtons = driver.FindElements(By.CssSelector(".yes-btn"));
                int x = 0;
                for(var i = 0; x < 3; i++)
                {
                    try
                    {
                        yesButtons[i].Click();
                        CloseAllModals();
                        x++;
                    }
                    catch
                    {
                        if(i >= 10)
                        {
                            Windows.Log("Could not find 3 Habits to click yes on");
                            break;
                        }
                    }
                    
                }
            }
            catch(Exception ex)
            {
                Windows.Log(ex.ToString());
            }
            
        }
        public void ExitBrowser()
        {
            driver.Quit();
        }
        private void ClickCardIcon()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("core-menuitem-benefits")));
                System.Threading.Thread.Sleep(3000);
                wait.Until(ExpectedConditions.ElementExists(By.CssSelector(".dialy-tips-circle")));
                IWebElement cardsIcon = driver.FindElement(By.CssSelector(".dialy-tips-circle"));
                System.Threading.Thread.Sleep(3000);
                CloseAllModals();

                IWebElement fisrtCard = null;
                try
                {
                    fisrtCard = driver.FindElement(By.Id("triggerCloseCurtain"));
                }
                catch { }

                if (fisrtCard == null)
                {
                    try
                    {
                        cardsIcon.Click();
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Windows.Log(ex.ToString());
            }



        }
        private void ClickCards()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("triggerCloseCurtain")));
                IWebElement dailyTipCards = driver.FindElement(By.Id("triggerCloseCurtain"));
                dailyTipCards.Click();

                try
                {
                    IWebElement nextCardButton = driver.FindElement(By.ClassName("next-card-btn"));
                    nextCardButton.Click();
                }
                catch { }

                System.Threading.Thread.Sleep(2000);
                dailyTipCards = driver.FindElement(By.Id("triggerCloseCurtain"));
                dailyTipCards.Click();
            }
            catch (Exception ex)
            {
                Windows.Log(ex.ToString());
            }
        }
        private void CloseAllModals()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".close-modal-btn")));
                var modals = driver.FindElements(By.CssSelector(".close-modal-btn"));
                foreach (var m in modals)
                {
                    m.Click();
                }
            }
            catch { }

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("trophy-modal-close-btn")));
                IWebElement awardCardCloseButton = driver.FindElement(By.Id("trophy-modal-close-btn"));
                awardCardCloseButton.Click();
                System.Threading.Thread.Sleep(2000);
            }
            catch { }
        }
    }
}
