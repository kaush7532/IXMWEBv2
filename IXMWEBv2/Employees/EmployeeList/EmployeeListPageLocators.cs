namespace IXMWEBv2.Employees.EmployeeList
{
    public class EmployeeListPageLocators
    {
        public const string UserAllTile = ".//*[@title='Users']";

        public const string UserID = ".//*[@id='Users']/div[3]//div[contains(text(), '#USERID')]";
        public const string TransferBtn = "TransferMenu";
        public const string TransferAllBtn = ".//*[@id='TransferMenu']/li/div//span[contains(text(),'All')]";
        public const string AddBtn = "Create";

        #region Tree View
        public const string OverwriteBtn = "deviceTransferToDeviceOverwrite";
        public const string SkipOverwriteBtn = "deviceTransferToDevice";
        #endregion
    }
}