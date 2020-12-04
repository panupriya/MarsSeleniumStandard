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
    class Language
    {
        public Language()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements

        //Click on language
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]")]
        private IWebElement LangBtn { get; set; }

        //Click on Add new to add new Language
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNewLangBtn { get; set; }


        //Enter the Language on text box
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement AddLangText { get; set; }

      
        //Enter the Language on text box
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement ChooseLang { get; set; }


        //Select language level
        [FindsBy(How = How.Name, Using = "level")]
        private IWebElement ChooseLevel { get; set; }

        //Click on Add Language
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement AddLang { get; set; }

        //Edit language
        //Language to be edited
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")]
        private IWebElement LangToSel { get; set; }

        //Click on edit language button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i")]
        private IWebElement EditLangBtn { get; set; }

        //Click on update language
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")]
        private IWebElement UpdateLangBtn { get; set; }


        //Delete Action
        //Delete language
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i")]
        private IWebElement DeleteLangBtn { get; set; }

        #endregion

        #region Enter Language
        internal void EnterLanguage()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            //Click on language add new
            LangBtn.Click();
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div", 10000);
            AddNewLangBtn.Click();

            //Add new language
            AddLangText.Click();
            ChooseLang.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Language"));

            //Select language level
            ChooseLevel.Click();
            new SelectElement(ChooseLevel).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "LanguageLevel"));

            //Add Language
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//input[@value='Add']", 10000);
            AddLang.Click();
            Base.test.Log(LogStatus.Info, "Added Language successfully");
        }
        #endregion

        #region Verify Language
        internal void VerifyLanguage()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            //verify language
            try
            {
                //Verify Language Name
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 10000);
                LangBtn.Click();
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                var lastRowLanguageName = GlobalDefinitions.driver.FindElement(By.XPath("//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
                Assert.That(lastRowLanguageName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Language")));

                //Verify Language Level
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 10000);
                var lastRowLanguageLevel = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowLanguageLevel, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "LanguageLevel")));
                Base.test.Log(LogStatus.Pass, "Added Language verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Language", ex.Message);
                Base.test.Log(LogStatus.Fail, "Added Language is not verified successfully");
            }

        }
        #endregion

        #region Edit Language
        internal void EditLanguage()
        {
            // Populate data saved in Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            //Click on language
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 10000);
            LangBtn.Click();

            //Click on language to edit
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
            LangToSel.Click();

            //Click on edit language button
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[1]/i", 10000);
            EditLangBtn.Click();

            //Update the language
            //Update language level
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "level", 10000);
            ChooseLevel.Click();

            new SelectElement(ChooseLevel).SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "LanguageLevel"));

            //Click on update
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]", 10000);
            UpdateLangBtn.Click();
            Base.test.Log(LogStatus.Info, "Language edited successfully");

        }
        #endregion

        #region Verify edited language
        internal void VerifyEditedLanguage()
        {
            // Populate data saved in Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //verify updated language
            try
            {
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 10000);
                LangBtn.Click();
                //Verify Language Level
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 10000);
                var lastRowLanguageLevel = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowLanguageLevel, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "LanguageLevel")));
                Base.test.Log(LogStatus.Pass, "Language edited verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to update Language", ex.Message);
                Base.test.Log(LogStatus.Fail, "Language edited is not verified successfully");
            }

        }
        #endregion

        #region Delete language
        internal void DeleteLanguage()
        {

            // Populate data saved in Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            
            //Delete Language

            try
            {
                //Click on language
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]", 10000);
                LangBtn.Click();

                //Click on language to delete
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                LangToSel.Click();

                //Click on delete language
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]/i", 20000);
                DeleteLangBtn.Click();
                Base.test.Log(LogStatus.Pass, "Language deleted successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to delete Language", ex.Message);
                Base.test.Log(LogStatus.Fail, "Language is not deleted successfully");
            }

        }
        #endregion


    }
}
