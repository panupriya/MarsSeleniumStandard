using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class SkillTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
        [Category("Sprint1")]
        class User : Global.Base
        {
            [Test, Order(1), Description("Check if the user is able to add Skill successfully")]
            public void AddSkill()
            {
                //Create Extent Report
                test = extent.StartTest("AddSkill");
                //Add profile
                Skill skillobj = new Skill();
                skillobj.EnterSkill();
                skillobj.VerifySkill();

            }

            [Test, Order(2), Description("Check if the user is able to Edit Skill successfully")]
            public void EditSkill()
            {
                //Create Extent Report
                test = extent.StartTest("EditSkill");
                //Edit profile
                Skill skillobj = new Skill();
                skillobj.EditSkills();
                skillobj.VerifyEditedSkill();


            }

            [Test, Order(3), Description("Check if the user is able to Delete Skill successfully")]
            public void DeleteSkill()
            {
                //Create Extent Report
                test = extent.StartTest("DeleteSkill");
                //Delete profile
                Skill skillobj = new Skill();
                skillobj.DeleteSkill();
  
            }

        }
    }
}
