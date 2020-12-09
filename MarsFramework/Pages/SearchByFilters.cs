using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class SearchByFilters
    {
        public SearchByFilters()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region Initialize web elements

        //Click on search skill
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[1]/input")]
        private IWebElement ClickSkill { get; set; }

        //Click search 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[1]/i")]
        private IWebElement SearchSkill { get; set; }


        //Search by Filter online
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]")]
        private IWebElement FilterOnline { get; set; }

        //Search by filter onsite
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[2]")]
        private IWebElement FilterOnsite { get; set; }

        //Search by filter ShowAll
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[3]")]
        private IWebElement FilterShowAll { get; set; }
        #endregion

        #region SearchByFilter
        internal void SearchByFilter()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");

            //Click on search skill
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[1]/input", 10000);
            ClickSkill.Click();
            ClickSkill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchFilter"));
            //ClickSkill.SendKeys("All");

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[1]/i", 10000);
            SearchSkill.Click();

            //Search by Filter online
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]", 10000);
            FilterOnline.Click();
            Thread.Sleep(2000);

            //Search by filter onsite
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[2]", 10000);
            FilterOnsite.Click();
            Thread.Sleep(2000);

            //Search by filter ShowAll
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[3]", 10000);
            FilterShowAll.Click();
            Thread.Sleep(2000);

        }
        #endregion
    }
}
