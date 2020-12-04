using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class ManageRequestTest
    {
        [TestFixture, Description("this fixture contains Mars Framework")]

        class User : Global.Base
        {
            [Test, Description("Test for Received requests")]
            public void ReceivedRequest()
            {
                //Create Extent Report
                test = extent.StartTest("Received Requests");
                ManageRequest manageRequest = new ManageRequest();
                manageRequest.ReceviedRequests();

            }
            [Test, Description("Test for sent requests")]
            public void SentRequest()
            {
                //Create Extent Report
                test = extent.StartTest("Sent Requests");
                ManageRequest manageRequest = new ManageRequest();
                manageRequest.SentRequests();

            }
        }
    }
}
