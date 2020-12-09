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
    class SearchSkill
    {
        public SearchSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        #region Initialize web elements
        //Click on search button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[1]/input")]
        private IWebElement SearchButton { get; set; }

        //Click search 
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[1]/i")]
        private IWebElement ClickSkill { get; set; }

        // search skill catagory
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/input")]
        private IWebElement searchSkill { get; set; }

        //Click search skill
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/i")]
        private IWebElement ClickSearckSkill { get; set; }
        

        //Search user
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input")]
        private IWebElement SearchUser { get; set; }

        //click Search user
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span")]
        private IWebElement ClickSearchUser { get; set; }


        #endregion

        #region SearchSkill
        internal void Search_skill()
        {
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkill");

            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[1]/input", 10000);
            SearchButton.Click();
            SearchButton.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchSkill"));
            //SearchButton.SendKeys("selenium with java");

            //Enter search skill
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[1]/i", 10000);
            ClickSkill.Click();

            // search skill catagory
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/input", 10000);
            searchSkill.Click();
            searchSkill.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SearchSkillCategory"));
            //searchSkill.SendKeys("Programming $ Tech");

            //Click search skill
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/i", 10000);
            ClickSearckSkill.Click();
            
           
            //Search user
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[1]/input", 10000);
            SearchUser.Click();
            SearchUser.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "UserName"));
            //SearchUser.SendKeys("zorawar badhan");
            Thread.Sleep(2000);

            //click Search user
            GlobalDefinitions.WaitForElementVisibility(GlobalDefinitions.driver, "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[1]/div/span", 10000);
            ClickSearchUser.Click();
            Thread.Sleep(2000);
        }
        #endregion
    }
}
