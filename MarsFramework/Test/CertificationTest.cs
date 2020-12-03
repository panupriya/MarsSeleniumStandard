using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class CertificationTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
        [Category("Sprint1")]
        class User : Global.Base
        {
            [Test, Order(1), Description("Check if the user is able to add Certification successfully")]
            public void AddCertification()
            {
                //Create Extent Report
                test = extent.StartTest("AddCertification");
                //Add profile
                Certification certiobj = new Certification();
                certiobj.EnterCertification();
                certiobj.VerifyCertification();

            }

            [Test, Order(2), Description("Check if the user is able to Edit Certification successfully")]
            public void EditCertification()
            {
                //Create Extent Report
                test = extent.StartTest("EditCertification");
                //Edit profile
                Certification certiobj = new Certification();
                certiobj.EditCertification();
                certiobj.VerifyEditedCertification();

            }

            [Test, Order(3), Description("Check if the user is able to Delete Certificationsuccessfully")]
            public void DeleteCertification()
            {
                //Create Extent Report
                test = extent.StartTest("DeleteCertification");
                //Delete profile
                Certification certiobj = new Certification();
                certiobj.DeleteCertification();



            }

        }
    }
}
