using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMarsSpecFlow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ProjectMarsSpecFlow.Tests
{
    internal class LanguagePage : CommonDriver
    {

        public void AddLanguage(IWebDriver driver, string Language)
        {
            //Click on the Add new for langauge
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));                      
            IWebElement addNewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addNewLanguage.Click();
            IWebElement language = driver.FindElement(By.Name("name"));
            language.SendKeys(Language);
            IWebElement languageLevel = driver.FindElement(By.Name("level"));
            languageLevel.Click();

            //Level selection
            driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[4]")).Click();
            IWebElement addlanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
            addlanguage.Click();
            Thread.Sleep(1500);

        }
        public void VerifyaddLanguage(IWebDriver driver, string Language) 
        {

            //Check new language has been created successfully
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement newLanguage = driver.FindElement(By.XPath("//td[normalize-space()='English']"));
            newLanguage.Click();
            Thread.Sleep(1500);
            Assert.That(newLanguage.Text == Language, "New Language has not been created. Test failed!");
            Thread.Sleep(1500);
        }

        public void EditLanguage(IWebDriver driver, string newlanguage)
        {

            //Edit language
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            editButton.Click();
            IWebElement oldLanguage = driver.FindElement(By.Name("name"));
            oldLanguage.Clear();
            oldLanguage.SendKeys(newlanguage);
            IWebElement languageLevel = driver.FindElement(By.Name("level"));
            languageLevel.Click();
            driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[5]")).Click();
            IWebElement updateButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateButton.Click();
            Thread.Sleep(1500);
        }
        public void Verifyeditlanguage(IWebDriver driver, string newlanguage) 
        {
            //check language has been edited
            Thread.Sleep(1500);
            IWebElement editLanguage = driver.FindElement(By.XPath("//td[normalize-space()='Hindi']"));
            editLanguage.Click();
            Assert.That(editLanguage.Text == newlanguage, "language has not been edited. Test failed!");
            Thread.Sleep(1500);

        }
        public void DeleteLanguage(IWebDriver driver) 
        {

            //Delete Language
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            deleteButton.Click();
            Thread.Sleep(2000);
            driver.Navigate().Refresh();
            Thread.Sleep(1500);

        }
        public void VerifydeleteLanguage(IWebDriver driver)
        {
            //Check language has been deleted successfully
            Thread.Sleep(1500);
            IWebElement deleteLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            Thread.Sleep(1500);
            Assert.That(deleteLanguage.Text != "English", "Language has not been deleted. Test failed!");
            Thread.Sleep(1500);
        }
        
    }
}


