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
    class Certification
    {
        public Certification()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements

        //Click on Certifications
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")]
        private IWebElement CertificationBtn { get; set; }

        //Click on add new certifications
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")]
        private IWebElement AddNewCertiBtn { get; set; }

        //Input Certification
        [FindsBy(How = How.Name, Using = "certificationName")]
        private IWebElement CertifiBtn { get; set; }

        [FindsBy(How = How.Name, Using = "certificationName")]
        private IWebElement CertifiName { get; set; }

        //Input certification from
        [FindsBy(How = How.Name, Using = "certificationFrom")]
        private IWebElement CertiFromBtn { get; set; }

        [FindsBy(How = How.Name, Using = "certificationFrom")]
        private IWebElement CertifiFrom { get; set; }

        //Select year from drop down
        [FindsBy(How = How.Name, Using = "certificationYear")]
        private IWebElement CertiYear { get; set; }

        //Click on add certification

        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        private IWebElement AddCerBtn { get; set; }

        //Edit certification
        //Certification to edit
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]")]
        private IWebElement CertiToSel { get; set; }

        //Click on edit certification button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i")]
        private IWebElement EditCertiBtn { get; set; }

        //Click on update certification
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]")]
        private IWebElement UpdateCertiBtn { get; set; }

        //Delete Action
        //Delete Certification
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]")]
        private IWebElement DeleteCertiBtn { get; set; }

        #endregion

        #region AddCertification
        internal void EnterCertification()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Click on Certifications
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 10000);
            CertificationBtn.Click();

            //Click on add new certifications
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 10000);
            AddNewCertiBtn.Click();

            //Input Certification
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "certificationName", 10000);
            CertifiBtn.Click();
            CertifiName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate"));

            //Input certification from
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "certificationFrom", 10000);
            CertiFromBtn.Click();
            CertifiFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom"));

            //Select year from drop down
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "certificationYear", 10000);
            CertiYear.Click();
            new SelectElement(CertiYear).SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "YearOfCertification")); ;

            //Click on add certification
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//input[@value='Add']", 10000);
            AddCerBtn.Click();
            Base.test.Log(LogStatus.Info, "Added Certification successfully");

        }
        #endregion

        #region Verify added certification
        internal void VerifyCertification()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //verify certification
            try
            {

                //Jump to Certification tab

                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 10000);
                CertificationBtn.Click();

                //Verify Certificate Name
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                var lastRowCertificateName = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]")).Text;
                Assert.That(lastRowCertificateName, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "Certificate")));

                //Verify Certificate Issuing Place
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]", 10000);
                var lastRowCertificateFrom = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[2]")).Text;
                Assert.That(lastRowCertificateFrom, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "CertifiedFrom")));

                //Verify Certificate Year
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]", 10000);
                var lastRowCertificateYear = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]")).Text;
                Assert.That(lastRowCertificateYear, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(2, "YearOfCertification")));
                Base.test.Log(LogStatus.Pass, "Added Certification verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Certification", ex.Message);
                Base.test.Log(LogStatus.Fail, "Added Certification is not verified successfully");
            }

        }
        #endregion

        #region Edit certification
        internal void EditCertification()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Click on certification
            //Click on Certifications
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 10000);
            CertificationBtn.Click();

            //Click on certification to be edit
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
            CertiToSel.Click();

            //Click on edit certification button
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[1]/i", 10000);
            EditCertiBtn.Click();

            //Update certification
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "Name", "certificationYear", 10000);
            CertiYear.Click();
            new SelectElement(CertiYear).SelectByText(GlobalDefinitions.ExcelLib.ReadData(3, "YearOfCertification")); ;

            //Click on update certification button            
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]", 10000);
            UpdateCertiBtn.Click();
            Base.test.Log(LogStatus.Info, "Certification edited successfully");

        }
        #endregion

        #region Verify edited certification
        internal void VerifyEditedCertification()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();
            //verify updated certification
            //verify certification
            try
            {

                //Jump to Certification tab
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 10000);
                CertificationBtn.Click();

                //Verify Certificate Year
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]", 10000);
                var lastRowCertificateYear = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[3]")).Text;
                Assert.That(lastRowCertificateYear, Is.EqualTo(GlobalDefinitions.ExcelLib.ReadData(3, "YearOfCertification")));
                Base.test.Log(LogStatus.Pass, "Certification edited verified successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Certification", ex.Message);
                Base.test.Log(LogStatus.Fail, "Certification edited is not verified successfully");
            }


        }

        #endregion

        #region Delete Certification
        internal void DeleteCertification()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            // Refresh the page
            GlobalDefinitions.driver.Navigate().Refresh();

            //Delete Certification

            try
            {
                //Click on certification
                //Click on Certifications
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]", 10000);
                CertificationBtn.Click();

                //Click on certification to be deleted
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[1]", 10000);
                CertiToSel.Click();

                //Click on delete certification button
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[last()]/tr/td[4]/span[2]", 20000);
                DeleteCertiBtn.Click();
                Base.test.Log(LogStatus.Pass, "Certification deleted successfully");

            }

            catch (Exception ex)
            {
                Assert.Fail("Test failed to delete Certification", ex.Message);
                Base.test.Log(LogStatus.Fail, "Certification is not deleted successfully");
            }
        }
        #endregion



    }


}
