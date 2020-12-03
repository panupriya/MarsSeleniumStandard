using System;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using MarsFramework.Global;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    class Loc_Availability
    {
        public Loc_Availability()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Click on availability Edit button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i")]
        private IWebElement AvailabilityTimeEdit { get; set; }

        //Click on Availability Time dropdown
        [FindsBy(How = How.Name, Using = "availabiltyType")]
        private IWebElement AvailabilityTime { get; set; }


        //Click on hour Edit button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")]
        private IWebElement HourEdit { get; set; }

        

        //Click on Availability hour dropdown
        [FindsBy(How = How.Name, Using = "availabiltyHour")]
        private IWebElement AvailabilityHour { get; set; }


        //Click on salary Edit button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i")]
        private IWebElement SalaryEdit { get; set; }

        //Click on salary dropdown
        [FindsBy(How = How.Name, Using = "availabiltyTarget")]
        private IWebElement SalarySelect { get; set; }
        #endregion

        internal void EnterDetails()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");

            #region Availability

            //Click on availability edit
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i", 10000);
            AvailabilityTimeEdit.Click();

            //Click on availability dropdown
            AvailabilityTime.Click();

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "availabiltyType", 10000);
            //select availability time
            new SelectElement(AvailabilityTime).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime"));
            Base.test.Log(LogStatus.Info, "Select the available time");

            #endregion

            #region Hour

            //click on hour edit
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i", 10000);
            HourEdit.Click();

            //click on houredit dropdown
            AvailabilityHour.Click();

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "availabiltyHour", 10000);
            //select availability hour
            new SelectElement(AvailabilityHour).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Hours"));
            Base.test.Log(LogStatus.Info, "Added hour successfully");

            #endregion

            #region EarnTarget
            //click on Target edit
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i", 10000);
            SalaryEdit.Click();

            //click on Target salary dropdown
            SalarySelect.Click();

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "availabiltyTarget", 10000);
            //select salary
            new SelectElement(SalarySelect).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"));
            Base.test.Log(LogStatus.Info, "Added Target successfully");
            #endregion

        }
    }
}
