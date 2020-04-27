namespace IXMWEBv2.QuickNavigationPane.Sync
{
    public class SyncLocators
    {
        public const string SyncTab = "btnSync";

        public const string AddSyncGrpBtn = "btnAddSync";

        public const string EmpGrpSearchBox = "searchUG";
        public const string AddVisibleEmpGrpToSyncGrp = ".//*[@id='UserGroupsList']//li/div[contains(.,normalize-space('#EMPGRPNAME'))]/preceding-sibling::div/div";
        public const string AddEmpGrpToSyncGrp = ".//*[@id = 'UserGroupsList']//a";

        public const string DeviceGrpSearchBox = "searchDG";
        public const string AddVisibleDeviceGrpToSyncGrp = ".//*[@id='DeviceGroupsList']//li/div[contains(.,normalize-space('#DEVICEGRPNAME'))]/preceding-sibling::div/div";
        public const string AddDeviceGrpToSyncGrp = ".//*[@id = 'DeviceGroupsList']//a";

        public const string SyncGrpNameTxtBox = "Name";
        public const string CreateSyncBtn = ".//*[@id = 'btnCreateSync'][contains(.,'Sync')]";
        public const string CancelSyncBtn = "btnCancelSync";

        public const string SyncListGrid = "ExistingSyncList";

        public const string SyncGroupEdit = ".//*[@id='" + SyncListGrid + "']//tbody//tr//td[text()='#SYNCNAME']/ancestor::tr//i[@title='Edit']";
        public const string SyncGroupSync = ".//*[@id='" + SyncListGrid + "']//tbody//tr//td[text()='#SYNCNAME']/ancestor::tr//i[@title='Sync']";
        public const string SyncGroupDelete = ".//*[@id='" + SyncListGrid + "']//tbody//tr//td[text()='#SYNCNAME']/ancestor::tr//i[@title='Delete']";
        public const string SyncGroupLog = ".//*[@id='" + SyncListGrid + "']//tbody//tr//td[text()='#SYNCNAME']/ancestor::tr//i[@title='Log']";
    }
}