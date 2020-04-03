namespace IXMWEBv2.Resources.Locators
{
    public class CommonLocators
    {
        //public const string deviceGroupsChk = ".//*[@class='k-icon k-minus']/following-sibling::span/*";
        //public const string deviceSelectionDropdown = ".//*[@id='DeviceList']/preceding-sibling::span";
        //public const string deviceName = ".//*[@id='DeviceList_listbox']//dd[text()='DEVICENAME']/parent::*";
        //public const string selectedDeviceName = ".//*[@id='deviceddltemplate1']//following-sibling::dl/dd";

        #region Application Events

        public const string applicationLogWindow = "//div[@id='appLogwindow']//preceding-sibling::h5[@class = 'modal-title' and text()= ' Application Logs']";
        public const string applicationLogWindowCloseBtn = "//div[@id='appLogwindow']//button[@class='close']//img";
        public const string applicationStatus = ".//*[@id='ApplicationEvent']/div[3]/table/tbody/tr[#num]/td[2]";
        public const string applicationLogWindowFilterBtn = ".//*[@id='ApplicationEvent']/div[2]//th[@data-title='#colName']//span";

        #endregion Application Events

        public const string mainProgressBar = ".//*[img[@src[contains(.,'progress-bar.gif')]]]/parent::div";

        public const string loadingIcon = "k-loading-image";
        public const string loadingIconSmall = "//img[contains(@src, 'loading-image.gif')]";
        public const string IXMLoader = "//img[contains(@src, 'IXMLoader.gif')]";
        public const string refreshLinkPager = ".//a[@class='k-pager-refresh k-link']";
        public const string CloseButtonOnModal = ".//*[@class='modal-header']//img[@src='/Content/NewUI/images/icons/icon_close.png']";

        #region Kendo Switch button Active/Inactive On/Off

        public const string switchActive = ".//*[input[@name='#SWITCHNAME#']/parent::*[@class='ui-switchbutton ui-switchbutton-default ui-switchbutton-AI ui-state-active']]";
        public const string switchInactive = ".//*[input[@name='#SWITCHNAME#']/parent::*[@class='ui-switchbutton ui-switchbutton-default ui-switchbutton-AI']]";

        public const string SwitchBtnThinActive = ".//*[@class='ui-switchbutton ui-switchbutton-default ui-switchbutton-thin ui-state-active']";
        public const string SwitchBtnThinInactive = ".//*[@class='ui-switchbutton ui-switchbutton-default ui-switchbutton-thin']";

        #endregion Kendo Switch button Active/Inactive On/Off

        public const string itemsCountOnPage = ".//*[@id='#GRIDID']//span[contains(@class, 'k-pager-info k-label')]";
        public const string nextPage = ".//*[@id='#GridId']//span[contains(@class,'k-icon k-i-arrow-e')]";
        public const string userGroup = "UserGroup";

        #region Kendo Window

        public const string KendoWindowActionClass = "k-window-actions";
        public const string KendoMsgWindow = "KendoMsgBox";
        public const string KendoMsgTxt = ".//*[@id='KendoMsgBox']//p";
        public const string KendoMsgOKBtn = "msgBoxOkButton";
        public const string KendoMsgWindowTitle = "KendoMsgBox_wnd_title";

        #endregion Kendo Window

        #region DeviceTreeView

        public const string searchDeviceBox = "deviceIdText";
        public const string searchDeviceBtn = ".//*[@id = '#GRIDID']//a[contains(.,'Search')]";
        public const string DeviceSelectionChkBox = ".//*[@id='#GRIDID']//div/span[text()='#DEVICENAME']/preceding-sibling::span[1]";

        #endregion
    }
}