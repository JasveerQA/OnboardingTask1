using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectMarsSpecFlow.Pages
{
    internal class LoginPage
    {
        public void Loginpage(IWebDriver driver)
            {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.Navigate().GoToUrl("http://localhost:5000/Home");

            IWebElement signInbutton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signInbutton.Click();
            Thread.Sleep(1000);
            try
            {
            IWebElement emailAddress = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            emailAddress.SendKeys("industryconnect@gmail.com");
            }
            catch (Exception ex)
            {
            Assert.Fail("Confirm your email  ", ex.Message);
            }

            IWebElement password = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            password.SendKeys("IndustryConnect");
            ///driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[3]/div/input")).Click();
            IWebElement login = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            login.Click();
            Thread.Sleep(1000);          
        }
    }
}

