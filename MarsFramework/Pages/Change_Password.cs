using MarsFramework.Global;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class Change_Password
    {
        public Change_Password()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements

        //Click on Name dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement NameBtn { get; set; }

        //Select change password option from dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]")]
        private IWebElement ChgPwdBtn { get; set; }

        //Enter current password
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[2]/form/div[1]/input")]
        private IWebElement CurrentPwd { get; set; }

        //Enter change password
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[2]/form/div[2]/input")]
        private IWebElement NewPwd { get; set; }

        //Enter confirm password
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[2]/form/div[3]/input")]
        private IWebElement ConfirmNewPwd { get; set; }

        //Click on save button
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[2]/form/div[4]/button")]
        private IWebElement SaveBtn { get; set; }
        #endregion

        #region change Password
        internal void ChangePassword()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            //Click on Name
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 10000);
            NameBtn.Click();

            //Click on change password
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]", 10000);
            ChgPwdBtn.Click();

            //Enter old password
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "/html/body/div[4]/div/div[2]/form/div[1]/input", 10000);
            CurrentPwd.Click();
            CurrentPwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));


            //Enter new password
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "/html/body/div[4]/div/div[2]/form/div[2]/input", 10000);
            NewPwd.Click();
            NewPwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "NewPassword"));

            //Confirm new password
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "/html/body/div[4]/div/div[2]/form/div[3]/input", 10000);
            ConfirmNewPwd.Click();
            ConfirmNewPwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "NewPassword"));
            try
            {
                //Click on save button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "/html/body/div[4]/div/div[2]/form/div[4]/button", 10000);
                SaveBtn.Click();
                Base.test.Log(LogStatus.Pass, "Password changed successfully");
            }
            catch
            {
                Base.test.Log(LogStatus.Fail, "Password is not reset successfully");
            }
        }
        #endregion

        #region Set as old Password
        internal void SetPassword()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            //Click on Name
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 10000);
            NameBtn.Click();

            //Click on change password
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]", 10000);
            ChgPwdBtn.Click();

            //Enter old password
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "/html/body/div[4]/div/div[2]/form/div[1]/input", 10000);
            CurrentPwd.Click();
            CurrentPwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "NewPassword"));


            //Enter new password
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "/html/body/div[4]/div/div[2]/form/div[2]/input", 10000);
            NewPwd.Click();
            NewPwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Confirm new password
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "/html/body/div[4]/div/div[2]/form/div[3]/input", 10000);
            ConfirmNewPwd.Click();
            ConfirmNewPwd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            //Click on save button
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "/html/body/div[4]/div/div[2]/form/div[4]/button", 10000);
            SaveBtn.Click();
        }
        #endregion

    }
}
