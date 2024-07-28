using OpenQA.Selenium;
using ProjectMarsSpecFlow.Utilities;
using ProjectMarsSpecFlow.Pages;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace ProjectMarsSpecFlow.StepDefinitions
{
    [Binding]
    public class SkillPageStepdefinitions : CommonDriver
    {
        //IWebDriver driver;
        LoginPage LoginpageObj = new LoginPage();
        SkillPage1 SkillpageObj = new SkillPage1();
        [BeforeScenario]
        public void SetUpTimeMaterial()
        {
            //Open Chrome Browser
            driver = new ChromeDriver();

        }
        [Given(@"user logs into Mars portal and navigates to homepage")]
        public void GivenUserLogsIntoMarsPortalAndNavigatesToHomepage()
        {
            LoginpageObj.Loginpage(driver);
        }
        [When(@"user creates new Skill record '([^']*)'")]
        public void WhenUserCreatesNewSkillRecord(string skill)
        {
            SkillpageObj.AddSkill(driver, "Writing");
        }


        [Then(@"skill should be saved '([^']*)'")]
        public void ThenSkillShouldBeSaved(string skill)
        {
            SkillpageObj.VerifyaddSkill(driver, "Writing");
        }


        [When(@"user edits an existing Skill record '([^']*)' '([^']*)'")]
        public void WhenUserEditsAnExistingSkillRecord(string oldSkill, string newSkill)
        {
            SkillpageObj.EditSkill(driver, oldSkill, newSkill);
        }

        [Then(@"skill should be updated '([^']*)'")]
        public void ThenSkillShouldBeUpdated(string newSkill)
        {
            SkillpageObj.VerifyeditSkill(driver, newSkill);
        }



        [When(@"user deletes an existing Skill record")]
        public void WhenUserDeletesAnExistingSkillRecord()
        {
            SkillpageObj.DeleteSkill(driver);
        }

        [Then(@"skill should be deleted")]
        public void ThenSkillShouldBeDeleted()
        {
            SkillpageObj.VerifydeleteSkill(driver);
            
        }

        [When(@"user deletes al existing Skill records")]
        public void WhenUserDeletesAlExistingSkillRecords()
        {
            SkillpageObj.DeleteAllSkills(driver);
        }

        [Then(@"skills should be deleted")]
        public void ThenSkillsShouldBeDeleted()
        {
            SkillpageObj.VerifyAllSkillsDeleted(driver);
        }

        [AfterScenario]
        public void CloseTestRun()
        {
            driver.Quit();
        }
        [When(@"user creates multiple Skill records")]
        public void WhenUserCreatesMultipleSkillRecords(Table table)
        {
            foreach (var row in table.Rows)
            {
                string skill = row["skill"]; 
                SkillpageObj.AddSkill(driver, skill);
            }
        }

        [Then(@"skill should be saved")]
        public void ThenSkillShouldBeSaved(Table table)
        {
            //SkillpageObj.VerifyaddSkill(driver);
            //foreach (var row in table.Rows)
            {
              //SkillpageObj.VerifymultipleAddSkills(driver, expectedSkills);
            }
        }



    }
}
