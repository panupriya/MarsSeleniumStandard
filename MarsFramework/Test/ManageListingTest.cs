using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class ManageListingTest
    {
        [TestFixture, Description("this fixture contains Mars Framework")]

        class User : Global.Base
        {

            [Test, Order(1), Description("Check if the user is able to View ManageListing successfully")]
            public void ViewManageListing()
            {
                //Create Extent Report
                test = extent.StartTest("View Manage Listing");
                //View Manage Listing
                ManageListing manageobj = new ManageListing();
                manageobj.Listings();

            }

            [Test, Order(2), Description("Check if the user is able to Edit ManageListing successfully")]
            public void EditManageListing()
            {
                //Create Extent Report
                test = extent.StartTest("Edit Manage Listing");
                //Edit Manage Listing
                ManageListing manageobj = new ManageListing();
                manageobj.EditListings();
                manageobj.ValidateEditedDetails();
            }

            [Test, Order(3), Description("Check if the user is able to Delete ManageListing successfully")]
            public void DeleteManageListing()
            {
                //Create Extent Report
                test = extent.StartTest("Delete Manage Listing");
                //Delete Manage Listing
                ManageListing manageobj = new ManageListing();
                manageobj.DeleteListings();
                manageobj.ValidateDeletedDetails();
            }

        }
    }
}
