using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class LanguageTest
    {
        [TestFixture, Description("This fixture contains Mars Framework")]
       
        class User : Global.Base
        {
            [Test, Order(1), Description("Check if the user is able to add Language successfully")]
            public void AddLanguage()
            {
                //Create Extent Report
                test = extent.StartTest("AddLanguage");
                //Add profile
                Language Langobj = new Language();
                Langobj.EnterLanguage();
                Langobj.VerifyLanguage();

            }

            [Test, Order(2), Description("Check if the user is able to Edit Language successfully")]
            public void EditLanguage()
            {
                //Create Extent Report
                test = extent.StartTest("EditLanguage");
                //Edit profile
                Language Langobj = new Language();
                Langobj.EditLanguage();
                Langobj.VerifyEditedLanguage();

            }

            [Test, Order(3), Description("Check if the user is able to Delete Language successfully")]
            public void DeleteLanguage()
            {
                //Create Extent Report
                test = extent.StartTest("DeleteLanguage");
                //Delete profile
                Language Langobj = new Language();
                Langobj.DeleteLanguage();

            }

        }
    }
}
