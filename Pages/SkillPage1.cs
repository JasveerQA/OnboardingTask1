using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjectMarsSpecFlow.Utilities;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMarsSpecFlow.Pages
{
    internal class SkillPage1 : CommonDriver
    {
        public void AddSkill(IWebDriver driver, string skill)
        {

            //Click on the Skill Menu
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement skilltab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skilltab.Click();

            //Add new Skill
            IWebElement addnewSkilltab = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div"));
            addnewSkilltab.Click();
            IWebElement addSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input"));
            addSkill.SendKeys(skill);
            IWebElement skillLevel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select"));
            skillLevel.Click();
            //skill level selection
            driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[4]")).Click();
            IWebElement addSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]"));
            addSkillButton.Click();
            Thread.Sleep(1500);
        }

        public void VerifyaddSkill(IWebDriver driver, string skill)
        {
            //Check new skill has been created successfully
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement newSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));
            Thread.Sleep(1500);
            Assert.That(newSkill.Text == skill, "New Skill has not been created. Test failed!");
            Thread.Sleep(1500);
        }
        

        //Edit Skill
        public void EditSkill(IWebDriver driver, string oldSkill, string newSkill)
        {
            IWebElement skill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skill.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")));
            IWebElement updateSkillbtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i"));
            updateSkillbtn.Click();

            IWebElement oldSkill1 = driver.FindElement(By.Name("name"));
            oldSkill1.Clear();


            //IWebElement addSkill = driver.FindElement(By.Name("name"));
            oldSkill1.SendKeys(newSkill);
            IWebElement skillLevel = driver.FindElement(By.Name("level"));
            skillLevel.Click();
            driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[3]")).Click();
            IWebElement updateSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));
            updateSkillButton.Click();
            Thread.Sleep(1500);
        }
        public void VerifyeditSkill(IWebDriver driver, string newSkill)
        {

            //Check skill has been edited successfully
            Thread.Sleep(1500);
            IWebElement editSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]"));
            editSkill.Click();
            Assert.That(editSkill.Text == newSkill, "Skill has not been Edited. Test failed!");
            Thread.Sleep(1500);
        }
        //Delete Skill
        public void DeleteSkill(IWebDriver driver)
        {
            IWebElement skill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skill.Click();
            IWebElement deleteSkillButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i"));
            deleteSkillButton.Click();
            //Click OK to delete 
            //driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
            driver.Navigate().Refresh();
            Thread.Sleep(1500);
        }
        public void VerifydeleteSkill(IWebDriver driver)
        {
            //Check skill has been deleted successfully
            Thread.Sleep(1500);
            IWebElement skill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement deletedSkill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]"));

            Thread.Sleep(1500);
            Assert.That(deletedSkill.Text != "Reading", "Skill has not been deleted. Test failed!");
            Thread.Sleep(1500);
        }
        public void DeleteAllSkills(IWebDriver driver)
        {
            IWebElement skill = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skill.Click();
            IList<IWebElement> skillEntries = driver.FindElements(By.XPath("//table[@id='skills-table']/tbody/tr"));

            foreach (var skillEntry in skillEntries)
            {
                IWebElement deleteButton = skillEntry.FindElement(By.XPath(".//button[contains(@class, 'delete-button')]"));
                deleteButton.Click();

                IWebElement confirmButton = driver.FindElement(By.XPath("//div[@class='modal']/button[@id='confirm-delete']"));
                confirmButton.Click();

                // Alternatively, if the delete action doesn't require confirmation,
                // you may just wait or proceed immediately after clicking deleteButton
            }
        }
        public void VerifyAllSkillsDeleted(IWebDriver driver)
        {
            // Find all skill entries on the page
            IList<IWebElement> skillEntries = driver.FindElements(By.XPath("//table[@id='skills-table']/tbody/tr"));

            // Assert that no skill entries are found
            Assert.AreEqual(0, skillEntries.Count, "Not all skills were deleted.");
        }
    }
}

