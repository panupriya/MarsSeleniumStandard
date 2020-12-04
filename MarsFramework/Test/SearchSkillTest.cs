using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class SearchSkillTest
    {
        [TestFixture, Description("this fixture contains Mars Framework")]
       
        class User : Global.Base
        {
            [Test, Order(1), Description("Test for search skills")]
            public void SearchSkill()
            {
                //Create Extent Report
                test = extent.StartTest("SearchSkill");

                SearchSkill searchSkill = new SearchSkill();
                searchSkill.Search_skill();

            }
            [Test, Order(2), Description("Test for search skills by filters")]
            public void SearchByFilter()
            {
                //Create Extent Report
                test = extent.StartTest("SearchByFilters");

                SearchByFilters searchSkill = new SearchByFilters();
                searchSkill.SearchByFilter();


            }

        }
    }
}
