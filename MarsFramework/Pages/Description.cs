using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class Description
    {
        public Description()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        #region  Initialize Web Elements

        //Click on discription edit button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i")]
        private IWebElement DescriptionEdit { get; set; }

        //Click on Description Text and enter the details
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea")]
        private IWebElement DescriptionBox { get; set; }

        //Click on Save button

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button")]
        private IWebElement SaveDescription { get; set; }

        #endregion

        #region Add Description
        internal void EnterDescription()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Click on edit Description
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i", 10000);
            DescriptionEdit.Click();

            //Click on Description Text and clear the details
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea", 10000);
            Thread.Sleep(1000);
            DescriptionBox.Clear();
            DescriptionBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Click on Save button
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button", 10000);
            SaveDescription.Click();
            Base.test.Log(LogStatus.Info, "Description Added successfully");
        }
        #endregion

        #region Verify Description
        internal void VerifyDescription()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Verify Description
            try
            {
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span", 10000);
                var description = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span")).Text;
                Assert.That(description, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Description")));
                Base.test.Log(LogStatus.Pass, "Adding Description Passed");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Description", ex.Message);
                Base.test.Log(LogStatus.Fail, "Adding Description failed");
            }

        }
        #endregion

        #region Edit Description
        internal void EditDescription()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Click on edit Description
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i", 10000);
            DescriptionEdit.Click();

            //Click on Description Text and clear the details
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea", 10000);
            Thread.Sleep(1000);
            DescriptionBox.Clear();
            DescriptionBox.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "Description"));

            //Click on Save button
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button", 10000);
            SaveDescription.Click();
            Base.test.Log(LogStatus.Info, "Description Edited Successfully");

        }
        #endregion

        #region Verify Edited Description
        internal void VerifyEditedDescription()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Verify edited description
            try
            {
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span", 10000);
                var description = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span")).Text;
                Assert.That(description, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "Description")));
                Base.test.Log(LogStatus.Pass, "Editing Description Passed");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Description", ex.Message);
                Base.test.Log(LogStatus.Fail, "Editing Description failed");
            }
        }
        #endregion


    }

}
