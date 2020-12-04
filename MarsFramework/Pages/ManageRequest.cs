using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        

        //Sent Request
        //Select Sent Request
        [FindsBy(How = How.LinkText, Using = "Sent Requests")]
        private IWebElement SentReqstSel { get; set; }




        #endregion

        #region Received Request
        internal void ReceviedRequests()
        {
            //Click on ManageRequest Tab
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[text()='Manage Requests']", 10000);
            ManageReqTab.Click();

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "Received Requests", 10000);
            ReceivedReqSel.Click();
        }
        #endregion

        #region Sent Request
        internal void SentRequests()
        {
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//div[text()='Manage Requests']", 10000);
            ManageReqTab.Click();

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "Sent Requests", 10000);
            SentReqstSel.Click();

        }
        #endregion
    }
}
