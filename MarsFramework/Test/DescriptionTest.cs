using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class DescriptionTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
       
        class User : Global.Base
        {
            [Test, Order(1), Description("Check if the user is able to add Description successfully")]
            public void AddDescription()
            {
                //Create Extent Report
                test = extent.StartTest("AddDescription");
                //Add profile
                Description descriobj = new Description();
                descriobj.EnterDescription();
                descriobj.VerifyDescription();

            }

            [Test, Order(2), Description("Check if the user is able to Edit Description successfully")]
            public void EditDescription()
            {
                //Create Extent Report
                test = extent.StartTest("EditDescription");
                //Edit profile
                Description descriobj = new Description();
                descriobj.EditDescription();
                descriobj.VerifyEditedDescription();

            }


        }
    }
}
