using IXMWEBv2.PageObjects.EmployeePageObject;
using IXMWEBv2.Utils;

namespace IXMWEBv2.AccessLayer.EmployeeAccessLayer
{
    public class EmployeeAllAccessLayer
    {
        private EmployeeAllPage_PO employeeAllPage;
        public string userID1 = null;
        public IXMWebUtils ixmUtils;

        public EmployeeAllAccessLayer(bool navigateToUserAll)
        {
            employeeAllPage = new EmployeeAllPage_PO();
            if (navigateToUserAll == true)
            {
                employeeAllPage.GoToUserAllTile();
            }
            ixmUtils = new IXMWebUtils();
        }

        public bool isUserCreated(string userID1)
        {
            return employeeAllPage.doesUserWithIDPresent(userID1);
        }

        public AddEmployeeAccessLayer ClickAddButton()
        {
            return employeeAllPage.ClickAddButton();
        }

        /// <summary>
        /// Method to transfer all users to selected device from tree view
        /// </summary>
        /// <param name="deviceNameList">List of device tree view</param>
        /// <param name="timeToWaitForTransferInSecs">Approx time to transfer in seconds</param>
        //public void TransferAllUser(List<DeviceInfoFromDB> deviceNameList, int timeToWaitForTransferInSecs)
        //{
        //    try
        //    {
        //        userAllPage.ClickTransferAllBtn();
        //        ixmUtils.DeviceSelectionChkBox(deviceNameList);
        //        userAllPage.ClickOverwriteBtn();
        //        IXMWebUtils.IsProgressBarShown(true, timeToWaitForTransferInSecs);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Failed to TransferallUsers");
        //        throw;
        //    }
        //}
    }
}