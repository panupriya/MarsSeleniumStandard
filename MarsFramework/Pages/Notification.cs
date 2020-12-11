using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsFramework.Global;
using System.Threading;

namespace MarsFramework.Pages
{
    class Notification
    {

        public Notification()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        #region Initialize web elements

        //Click on Notification tab
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div")]
        private IWebElement ClickNotification { get; set; }

        //Click on See all
        [FindsBy(How = How.LinkText, Using = "See All...")]
        private IWebElement ClickSeeAll { get; set; }

        //Click on select all(Not working Xpath n Css Selector??)
        
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[1]/i")]
        private IWebElement SelectAll { get; set; }


        //UnSelect All
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[2]")]
        private IWebElement UnSelectAll { get; set; }

        //Select one
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input")]
        private IWebElement SelectOne { get; set; }

        //Mark Selction as read
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[4]")]
        private IWebElement MarkSelection { get; set; }

        //Delete
        [FindsBy(How = How.XPath, Using = "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[3]/i")]
        private IWebElement Delete { get; set; }
        #endregion

        #region Notification
        internal void Notifications()
        {
            //Click on Notification tab
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/div", 10000);
            ClickNotification.Click();

            //Click on See all
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "LinkText", "See All...", 10000);
            ClickSeeAll.Click();

            //Click on select all
           
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[1]/i", 10000);
            SelectAll.Click();
            

            //UnSelect All
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[2]", 10000);
            UnSelectAll.Click();

            //Select one
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input", 10000);
            SelectOne.Click();

            //Mark Selction as read
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[4]", 10000);
            MarkSelection.Click();

            //Delete Notification
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='notification-section']/div[2]/div/div/div[3]/div[1]/div[3]/i", 10000);
            Delete.Click();
            Thread.Sleep(2000);
        }
        #endregion 
    }
}
