using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class NotificationTest
    {
        [TestFixture, Description("this fixture contains Mars Framework")]

        class User : Global.Base
        {
            [Test, Description("Test for Notification")]
            public void Notification()
            {
                //Create Extent Report
                test = extent.StartTest("Notification");

                Notification notifiObj = new Notification();
                notifiObj.Notifications();

            }

        }
    }
}
