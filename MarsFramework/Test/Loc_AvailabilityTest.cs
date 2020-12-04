using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class Loc_AvailabilityTest
    {

        [TestFixture, Description("This fixture contains Mars Framework")]
       
        class User : Global.Base
        {
            [Test, Description("Check if the user is able to add details successfully")]
            public void AvailabilityDetails()
            {
                //Create Extent Report
                test = extent.StartTest("AddAvailaHourTarget");
                //Add profile
                Loc_Availability LocAvailobj = new Loc_Availability();
                LocAvailobj.EnterDetails();
               

            }

        }

    }
}
