using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class Change_PasswordTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
       
        class User : Global.Base
        {
            [Test, Description("Check if the user is able to change password successfully")]
            public void ChangePassword()
            {
                //Create Extent Report
                test = extent.StartTest("ChangePassword");
                //Change Password
                Change_Password ChgpwdObj = new Change_Password();
                ChgpwdObj.ChangePassword();

            }

            [Test, Description("To set to old password")]
            public void SetCurrentPassword()
            {
                
                //Set Password back
                Change_Password ChgpwdObj = new Change_Password();
                ChgpwdObj.SetPassword();

            }

        }
    }
}
