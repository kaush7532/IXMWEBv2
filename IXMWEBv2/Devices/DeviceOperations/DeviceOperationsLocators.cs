namespace IXMWEBv2.Resources.Locators.DeviceTile
{
    public class DeviceOperationsLocators
    {
        public const string DeviceExist = ".//*[@class='user-name']/div[@id = 'deviceName_['#DEVICEPARAM']']";

        public const string DeviceStatusOnListPage = "status_['#DEVICEPARAM']";
        public const string DeviceListGridID = "listView";

        #region Page Buttons

        // public const string CloneBtn = "btnClone";
        // public const string DiscoverBtn = "Create";
        public const string DeleteBtn = "//div[@class='right-icons']//a/img[@src='/Content/NewUI/images/icons/icon_delete.png' and @alt='Delete']";

        public const string RebootBtn = ".//*[@class='device-right-button-block']/div/a/span[normalize-space(text())='Reboot']";
        public const string SearchBtn = "all-search";
        public const string SearchTxtBox = "searchDevices";
        public const string AddDeviceBtn = ".//*[@id = 'deviceSidebtn']//span[text()[normalize-space()='Add Device']]";
        public const string BroadcastBtn = ".//*[@id = 'deviceSidebtn']//span[text()[normalize-space()='Broadcast']]";
        public const string FirmwareupdateBtn = ".//*[@id = 'deviceSidebtn']//span[text()[normalize-space()='Firmware Upgrade']]";
        public const string FactoryDefaultBtn = ".//*[@id = 'deviceSidebtn']//span[text()[normalize-space()='Factory Defaults']]";

        #endregion Page Buttons

        #region Device list locators

        public const string DeviceStatus = ".//*[@class='profile-detail-container']//div/span";
        public const string DeviceListLink = "device-tab";
        public const string DeviceListItems = ".//*[@id='listView']//ul//li";
        public const string DeviceListItemToSelect = "deviceName_#DEVICEPARAM";
        public const string SelectedDevice = ".//*[@id='listView']//ul[@class[contains(.,'selected')]]//div";

        public const string DeviceGroupsLink = "dg-group-tab";

        #endregion Device list locators

        #region Message box locators

        public const string DeleteWindow = "DeleteWindow_wnd_title";
        public const string DeleteBtnOnWindow = "btnYesDelete";
        public const string CancelBtnOnWindow = "btnNoDelete";
        public const string PasswordTxt = "devicedeletePassword";

        public const string RebootWindow = "RebootWindow_wnd_title";
        public const string RebootBtnOnWindow = "btnReboot";
        public const string CancelBtnOnRebootWindow = "btnCancelReboot";

        public const string KendoMsgWindow = "KendoMsgBox";
        public const string KendoMsgTxt = ".//*[@id='KendoMsgBox']//p";
        public const string KendoMsgOKBtn = "msgBoxOkButton";

        #endregion Message box locators

        #region EditDevice page locators

        //public const string DeviceName = "Name";
        //public const string BtnSaveEditDevice = "SubmitButton";

        #endregion EditDevice page locators

        public const string AutoDiscoverSwitchName = ".//*[@class ='custom-control-label'][contains(text(),'Auto Discover')]";
        public const string SSLModeSwitchName = "chkConnectionMode";
        public const string SearchOnRegisterbtn = "submitbutton";

        //public const string kendomsg = ".//*[@id='kendomsgbox']//p";
        //public const string kendomsgokbtn = "msgboxokbutton";
        public const string Ethernetsection = ".//*[@class ='custom-control-label'][contains(text(), 'Ethernet')]";

        public const string SerialSection = ".//*[@class = 'custom-control-label'][normalize-space(text()) ='Serial']";
    }
}