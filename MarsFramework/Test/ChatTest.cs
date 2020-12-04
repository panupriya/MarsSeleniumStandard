using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class ChatTest
    {
        [TestFixture, Description("this fixture contains Mars Framework")]
       
        class User : Global.Base
        {
            [Test, Description("Test for Chat")]
            public void Chat()
            {
                //Create Extent Report
                test = extent.StartTest("Chat");

                Chat ChatObj = new Chat();
                ChatObj.Chats();

            }

        }
    }
}
