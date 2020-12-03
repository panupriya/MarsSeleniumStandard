using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class Skill
    {
        public Skill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements
        //Click on skill
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")]
        private IWebElement SkillBtn { get; set; }

        //Click on add new skill
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNewSkillBtn { get; set; }


        //Click on skill test box
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement AddSkillBox { get; set; }

        //Enter skill on the box
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement AddSkill { get; set; }

        //Click skill level dropdown
        [FindsBy(How = How.Name, Using = "level")]
        private IWebElement AddSkillLevel { get; set; }

        //Click on add skill
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement AddSkillBtn { get; set; }


        //Edit Skill
        //Skill to be edited
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]")]
        private IWebElement SkillToSel { get; set; }
        //Click on edit skill button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i")]
        private IWebElement EditSkill { get; set; }

        //Click on updatete skill
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]")]
        private IWebElement UpdateSkillBtn { get; set; }

        //Delete Action
        //Delete skill
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")]
        private IWebElement DeleteSkillBtn { get; set; }

        #endregion

        #region Add skill
        internal void EnterSkill()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            //Click on skill
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 10000);
            SkillBtn.Click();

            //Click on add new skill
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div", 10000);
            AddNewSkillBtn.Click();

            //Add new skill

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "name", 10000);
            AddSkillBox.Click();
            AddSkill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill"));

            //Add skill level
            AddSkillLevel.Click();
            new SelectElement(AddSkillLevel).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "SkillLevel"));

            //Click on add skill
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//input[@value='Add']", 10000);
            AddSkillBtn.Click();
            Base.test.Log(LogStatus.Info, "Added skill successfully");

        }
        #endregion

        #region verify added skill

        internal void VerifySkill()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            try
            {

                //Jump to Skill tab

                //Click on skill
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 10000);
                SkillBtn.Click();

                //Verify Skill Name
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                var lastRowSkillName = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
                Assert.That(lastRowSkillName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Skill")));

                //Verify Skill Level
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 10000);
                var lastRowSkillLevel = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowSkillLevel, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "SkillLevel")));
                Base.test.Log(LogStatus.Info, "Added skill verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Skills", ex.Message);
            }
        }
        #endregion

        #region Edit skill
        internal void EditSkills()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Click on skill
            //Click on skill
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 10000);
            SkillBtn.Click();

            //Click on skill to be edited
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
            SkillToSel.Click();

            //Click on Edit skill
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i", 10000);
            EditSkill.Click();

            //Edit the skill
            //Add skill level
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "level", 10000);
            AddSkillLevel.Click();
            new SelectElement(AddSkillLevel).SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "SkillLevel"));

            //Click on update
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]", 10000);
            UpdateSkillBtn.Click();
            Base.test.Log(LogStatus.Info, "Skill edited successfully");

        }
        #endregion

        #region verify edited skill
        internal void VerifyEditedSkill()
        {

            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            //Verify updated skill
            try
            {

                //Jump to Skill tab

                //Click on skill
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 10000);
                SkillBtn.Click();

                //Verify Skill Level
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 10000);
                var lastRowSkillLevel = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowSkillLevel, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "SkillLevel")));
                Base.test.Log(LogStatus.Info, "Skill edited verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify updated Skills", ex.Message);
            }
        }

        #endregion

        #region DeleteSkill
        internal void DeleteSkill()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            //Delete Skill

            try
            {

                //Click on skill
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]", 10000);
                SkillBtn.Click();

                //Click on skill to be deleted
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                SkillToSel.Click();

                //Click on Delete skill
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i", 20000);
                DeleteSkillBtn.Click();
                Base.test.Log(LogStatus.Info, "Skill deleted successfully");

            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to Delete Skill", ex.Message);
            }
        }

        #endregion

    }
}
