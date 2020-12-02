using MarsFramework.Pages;
using NUnit.Framework;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture, Description("this fixture contains Mars Framework")]
        [Category("Sprint1")]
        class User : Global.Base
        {

            #region Profile page

            [Test, Description("Check if the user is able to add profile details successfully")]
                public void AddProfile()
                {
                    //Create Extent Report
                    test = extent.StartTest("Add Profile");
                    //Add profile
                    Profile profileobj = new Profile();
                    profileobj.EnterProfile();
                    profileobj.VerifyProfile();

                }

                [Test, Description("Check if the user is able to Edit profile details successfully")]
                public void EditProfile()
                {
                    //Create Extent Report
                     test = extent.StartTest("Edit Profile");
                    //Edit profile
                    Profile profileobj = new Profile();
                    profileobj.EditProfile();
                    profileobj.VerifyEditedProfile();

                }

                [Test, Description("Check if the user is able to Delete profile details successfully")]
                public void DeleteProfile()
                {
                    //Create Extent Report
                    test = extent.StartTest("Delete Profile");
                    //Delete profile
                    Profile profileobj = new Profile();
                    profileobj.DeleteProfile();
                   

                }

            #endregion


            #region Skill Share page
            [Test, Description("Check if the user is able to add ShareSkill details successfully")]
                public void EnterShareSkill()
                {
                    //Create Extent Report
                    test = extent.StartTest("Add Share Skill");
                    //Add Share Skill
                    ShareSkill shareSkillObj = new ShareSkill();
                    shareSkillObj.EnterShareSkill();
                    shareSkillObj.VerifySkill();
                }

            #endregion

            #region Manage Listing page
            [Test, Description("Check if the user is able to View ManageListing successfully")]
                public void ManageListing()
                {
                    //Create Extent Report
                    test = extent.StartTest("View Manage Listing");
                    //View Manage Listing
                    ManageListing manageobj = new ManageListing();
                    manageobj.Listings();

                }

                [Test, Description("Check if the user is able to Edit ManageListing successfully")]
                public void EditManageListing()
                {
                    //Create Extent Report
                    test = extent.StartTest("Edit Manage Listing");
                    //Edit Manage Listing
                    ManageListing manageobj = new ManageListing();
                    manageobj.EditListings();
                    manageobj.ValidateEditedDetails();
                }

                [Test, Description("Check if the user is able to Delete ManageListing successfully")]
                public void DeleteManageListing()
                {
                    //Create Extent Report
                    test = extent.StartTest("Delete Manage Listing");
                    //Delete Manage Listing
                     ManageListing manageobj = new ManageListing();
                    manageobj.DeleteListings();
                    manageobj.ValidateDeletedDetails(); 
                }
            #endregion
        }
    }
}