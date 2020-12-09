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
    class ManageRequest
    {
        public ManageRequest()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region Initialize web elements

        //Click on Manage Request tab
        [FindsBy(How = How.XPath, Using = "//div[text()='Manage Requests']")]
        private IWebElement ManageReqTab { get; set; }

        //Select Recieved Request
        [FindsBy(How = How.LinkText, Using = "Received Requests")]
        private IWebElement ReceivedReqSel { get; set; }

        //Accept Request
        [FindsBy(How = How.XPath, Using = "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]")]
        private IWebElement AcceptRequest { get; set; }

        //Decline Request
        [FindsBy(How = How.XPath, Using = "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]")]
        private IWebElement DeclineRequest { get; set; }

       
        //Complete Request
        [FindsBy(How = How.XPath, Using = "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button")]
        private IWebElement CompleteRequest { get; set; }



        //Sent Request
        //Select Sent Request
        [FindsBy(How = How.LinkText, Using = "Sent Requests")]
        private IWebElement SentReqstSel { get; set; }

        //click search icon
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[1]/div[1]/i")]
        private IWebElement Searchicon { get; set; }

        //Search by name
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input")]
        private IWebElement SearchNameicon { get; set; }

        //Select by name
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span")]
        private IWebElement SearchName { get; set; }

        //Select Name
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[last()]/a/img")]
        private IWebElement SelName { get; set; }

        //Enter text area
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea")]
        private IWebElement textArea { get; set; }

        //Click on Request
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[3]")]
        private IWebElement SelRequest { get; set; }

        //select yes

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[3]/button[1]")]
        private IWebElement Yes { get; set; }

        

        #endregion

        #region Received Request
        internal void ReceviedRequests()
        {


            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequest");

            //Click on ManageRequest Tab
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[text()='Manage Requests']", 10000);
            ManageReqTab.Click();

            //Select Recieved Request
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "Received Requests", 10000);
            ReceivedReqSel.Click();

            //Accept or Declane request

            if (GlobalDefinitions.ExcelLib.ReadData(2, "ReceviedRequest") == "Accept")
            {
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]", 10000);
                AcceptRequest.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "ReceviedRequest") == "Decline")
            {
                GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]", 10000);
                DeclineRequest.Click();
                
            }

            //Complete request
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[3]/td[8]/button", 10000);
            CompleteRequest.Click(); 
        }
        #endregion

        #region Sent Request
        internal void SentRequests()
        {
            //Populate the excel data

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageRequest");

            //Click on manage request tab
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[text()='Manage Requests']", 10000);
            ManageReqTab.Click();

            //Click on sent request
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "Sent Requests", 10000);
            SentReqstSel.Click();

            //Click on search icon
            Searchicon.Click();
            Thread.Sleep(1000);
            //Enter name
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input", 10000);
            SearchNameicon.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchName"));
            //SearchNameicon.SendKeys("kimi wang");
            Thread.Sleep(1000);

            //Select name
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span", 10000);
            SearchName.Click();

            //Click on image
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[last()]/a/img", 10000);
            SelName.Click();

            //Enter text data
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea", 10000);
            SearchNameicon.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Text"));
            //textArea.SendKeys("I am interested on your skills");

            //Click on request
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[3]", 10000);
            SelRequest.Click();
            Thread.Sleep(1000);

            //select ok
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "/html/body/div[4]/div/div[3]/button[1]", 10000);
            Yes.Click();

        }
        #endregion


    }
}
