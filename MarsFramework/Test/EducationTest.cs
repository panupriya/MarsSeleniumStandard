using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class EducationTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
        
        class User : Global.Base
        {
            [Test, Order(1), Description("Check if the user is able to add Education successfully")]
            public void AddEducation()
            {
                //Create Extent Report
                test = extent.StartTest("AddEducation");
                //Add profile
                Education eduobj = new Education();
                eduobj.EnterEducation();
                eduobj.VerifyEducation();

            }

            [Test, Order(2), Description("Check if the user is able to Edit Education successfully")]
            public void EditEducation()
            {
                //Create Extent Report
                test = extent.StartTest("EditEducation");
                //Edit profile
                Education eduobj = new Education();
                eduobj.EditEducation();
                eduobj.VerifyEditedEducation();


            }

            [Test, Order(3), Description("Check if the user is able to Delete Education successfully")]
            public void DeleteEducation()
            {
                //Create Extent Report
                test = extent.StartTest("DeleteEducation");
                //Delete profile
                Education eduobj = new Education();
                eduobj.DeleteEducation();


            }

        }
    }
}
