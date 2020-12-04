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
    class Education
    {
        public Education()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements
        //Click on Education button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")]
        private IWebElement EducationBtn { get; set; }

        //Click on add new education
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")]
        private IWebElement AddNewEducationBtn { get; set; }

        //Choose country
        [FindsBy(How = How.Name, Using = "country")]
        private IWebElement SelectCountry { get; set; }
     
        //Choose title
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement SelectTitle { get; set; }

        //Choose year
        [FindsBy(How = How.Name, Using = "yearOfGraduation")]
        private IWebElement YearOfGraduation { get; set; }

        //Choose institute name
        [FindsBy(How = How.Name, Using = "instituteName")]
        private IWebElement InstitName { get; set; }

        //Choose degree
        [FindsBy(How = How.Name, Using = "degree")]
        private IWebElement Degree { get; set; }

        //Click on add education
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement AddEdu { get; set; }

        //Edit education
        //Education to edit
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]")]
        private IWebElement EduToSel { get; set; }

        //Click on edit education button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[1]/i")]
        private IWebElement EditEduBtn { get; set; }

        //Click on update education
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]")]
        private IWebElement UpdateEduBtn { get; set; }

        //DeleteAction
        //Delete Education
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i")]
        private IWebElement DeleteEduBtn { get; set; }
        #endregion

        #region add education
        internal void EnterEducation()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            //Click on Education button
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 10000);
            EducationBtn.Click();

            //Click on add new education
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div", 10000);
            AddNewEducationBtn.Click();

            //Choose country
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "country", 10000);
            SelectCountry.Click();
            new SelectElement(SelectCountry).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Country"));

            //Choose title
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "title", 10000);
            SelectTitle.Click();
            new SelectElement(SelectTitle).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Choose year
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "yearOfGraduation", 10000);
            YearOfGraduation.Click();
            new SelectElement(YearOfGraduation).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "YearOfGraduation"));

            //Choose institute name
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "instituteName", 10000);
            InstitName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "University"));

            //Choose degree
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "degree", 10000);
            Degree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Degree"));

            //Click on add education
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//input[@value='Add']", 10000);
            AddEdu.Click();
            Base.test.Log(LogStatus.Info, "Education Added successfully");

        }
        #endregion

        #region verify education

        internal void VerifyEducation()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            //verify education
            try
            {
                //Jump to Education tab
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 10000);
                EducationBtn.Click();

                //Verify Education Country
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                var lastRowEducationCountry = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
                Assert.That(lastRowEducationCountry, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Country")));

                //Verify Education Name
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]", 10000);
                var lastRowEducationName = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowEducationName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "University")));

                //Verify Education Title
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]", 10000);
                var lastRowEducationTitle = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]")).Text;
                Assert.That(lastRowEducationTitle, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Title")));

                //Verify Education Degree
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]", 10000);
                var lastRowEducationDegree = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[4]")).Text;
                Assert.That(lastRowEducationDegree, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Degree")));

                //Verify Education Graduation Year
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]", 10000);
                var lastRowEducationGraduationYear = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[5]")).Text;
                Assert.That(lastRowEducationGraduationYear, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "YearOfGraduation")));
                Base.test.Log(LogStatus.Pass, "Education added verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Education", ex.Message);
                Base.test.Log(LogStatus.Fail, "Education added is not verified successfully");
            }

        }
        #endregion

        #region Edit Education
        internal void EditEducation()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Click on education
            //Click on Education button
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 10000);
            EducationBtn.Click();

            //Click on education to be edit
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
            EduToSel.Click();

            //Click on edit education button
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[1]/i", 10000);
            EditEduBtn.Click();

            //Update education
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "title", 10000);
            SelectTitle.Click();
            new SelectElement(SelectTitle).SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "Title"));

            //Click on update education button 
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]", 10000);

            UpdateEduBtn.Click();
            Base.test.Log(LogStatus.Info, "Education edited successfully");

        }
        #endregion

        #region Edited Education verification

        internal void VerifyEditedEducation()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();


            //verify updated education
            try
            {
                //Jump to Education tab
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 10000);
                EducationBtn.Click();

                //Verify Education Title
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]", 10000);
                var lastRowEducationTitle = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[3]")).Text;
                Assert.That(lastRowEducationTitle, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "Title")));
                Base.test.Log(LogStatus.Pass, "Education edited verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Updating Education", ex.Message);
                Base.test.Log(LogStatus.Fail, "Education edited is not verified successfully");
            }

        }
        #endregion

        #region Delete Education

        internal void DeleteEducation()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            //Delete Education
            try
            {
                //Click on education
                //Click on Education button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]", 10000);
                EducationBtn.Click();

                //Click on education to be deleted
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                EduToSel.Click();

                //Click on  delete education button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i", 20000);
                DeleteEduBtn.Click();
                Base.test.Log(LogStatus.Pass, "Education deleted successfully");


            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to delete Education", ex.Message);
                Base.test.Log(LogStatus.Fail, "Education is not deleted successfully");
            }

        }

        #endregion

    }
}
