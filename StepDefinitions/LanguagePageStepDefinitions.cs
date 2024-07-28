using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjectMarsSpecFlow.Pages;
using ProjectMarsSpecFlow.Tests;
using ProjectMarsSpecFlow.Utilities;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace ProjectMarsSpecFlow.StepDefinitions
{
    [Binding]
    public class LanguagePageStepDefinitions : CommonDriver
    {
        //IWebDriver driver;
        //IWebDriver driver = new ChromeDriver();
        LoginPage loginPageObj = new LoginPage();
        LanguagePage languageObj = new LanguagePage();

        [BeforeScenario]
        public void SetUpTimeMaterial()
        {
            //Open Chrome Browser
            driver = new ChromeDriver();

        }

        [Given(@"I log into Mars portal and navigates to Homepage")]
        public void GivenILogIntoMarsPortalAndNavigatesToHomepage()
        {
            loginPageObj.Loginpage(driver);
        }



        [When(@"I create a new Language record '([^']*)'")]
        public void WhenICreateANewLanguageRecord(string Language)
        {
            languageObj.AddLanguage(driver, "English");
        }

        [Then(@"the language should be saved successfully '([^']*)'")]
        public void ThenTheLanguageShouldBeSavedSuccessfully(string Language)
        {
            languageObj.VerifyaddLanguage(driver, "English");
        }

        [When(@"I edit an existing Language record '([^']*)'")]
        public void WhenIEditAnExistingLanguageRecord(string newlanguage)
        {
            languageObj.EditLanguage(driver, newlanguage);
        }


        [Then(@"the language should be updated '([^']*)'")]
        public void ThenTheLanguageShouldBeUpdated(string newlanguage)
        {
            languageObj.Verifyeditlanguage(driver, newlanguage);
        }


        [When(@"I delete an existing Language record")]
        public void WhenIDeleteAnExistingLanguageRecord()
        {
            languageObj.DeleteLanguage(driver);
        }


        [Then(@"the language should be deleted")]
        public void ThenTheLanguageShouldBeDeleted()
        {
            languageObj.VerifydeleteLanguage(driver);

        }
        [AfterScenario]
        public void CloseTestRun()
        {
            driver.Quit();
        }

        [When(@"user creates multiple Language records")]
        public void WhenUserCreatesMultipleLanguageRecords(Table table)
        {
            foreach (var row in table.Rows)
            {
                string Language = row["language"];
                languageObj.AddLanguage(driver, Language);
            }
        }

        [Then(@"Language should be saved")]
        public void ThenLanguageShouldBeSaved(Table table)
        {
            //foreach (var row in table.Rows)
            {
                //string Language = row["language"];
                // Perform assertions or verifications based on expectedSkill
                //languageObj.VerifyaddLanguage(driver, Language);
            }
        }


    }
}