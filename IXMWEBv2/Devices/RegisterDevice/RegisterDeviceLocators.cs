namespace IXMWEBv2.Resources.Locators.DeviceTile
{
    public class RegisterDeviceLocators
    {
        public const string AddNewDeviceWindowTxt = "";
        public const string AddDeviceNavigationItems = "";
        public const string AddDeviceDiscoverySection = "DiscoverySection";
        public const string AddDeviceRegisterSection = "";
        public const string AddDeviceSummarySection = "";
        public const string AddNewWindowCloseBtn = "";

        #region Discover

        #region Buttons
        public const string AutoDiscoverRadioBtn = "//*[@id='customRadio1']//following-sibling::label[normalize-space(text()='Auto Discover')]";        
        public const string EthernetRadioBtn = "//*[@id='customRadio2']//following-sibling::label[normalize-space(text()='Ethernet')]";
        public const string SerialRadioBtn = "//*[@id='customRadio3']//following-sibling::label[normalize-space(text()='Serial')]";
        public const string SearchBtn = "SubmitButton";
        #endregion

        #region Text Boxes
        public const string PortNo = "PortNo";

        public const string StartIpOctet1 = "StartIP_octet_1";
        public const string StartIpOctet2 = "StartIP_octet_2";
        public const string StartIpOctet3 = "StartIP_octet_3";
        public const string StartIpOctet4 = "StartIP_octet_4";

        public const string EndIpOctet1 = "EndIP_octet_1";
        public const string EndIpOctet2 = "EndIP_octet_2";
        public const string EndIpOctet3 = "EndIP_octet_3";
        public const string EndIpOctet4 = "EndIP_octet_4";
        #endregion

        #region Checkbox
        public const string SearchSSLChkbox = "//*[@id='chkConnectionMode']//following-sibling::label[text()='Search on SSL']";
        #endregion

        public const string DiscoveredDevices = ".//*[@id='Devices']//div[@class[contains(.,'device-list-box')]]";

        #endregion

        #region Register
        
        #region Icon
        public const string DeviceToRegisterIcon = "";
        #endregion

        #region Text Boxes
        public const string DeviceNameTxt = "";
        public const string DeviceIdTxt = "";
        public const string DeviceGroupTxt = "";
        public const string DeviceIpAddrTxt = "";
        public const string DevicePortTxt = "";
        public const string DeviceSubnetMaskTxt = "";
        public const string DeviceGatewayTxt = "";
        #endregion

        #region CheckBoxes
        public const string TnAChkbox = "";
        public const string DHCPChkbox = "";

        #endregion

        #region Buttons
        public const string Register = "";
        #endregion

        #endregion

        #region Summary
        public const string NetworkInfoItems = "";
        public const string GeneralInfoItems = "";

        #region Buttons
        public const string AddNewBtn = "";
        public const string DoneBtn = "";
        #endregion
        #endregion

        #region Resource Strings
        
        #endregion






        public const string AutoDiscoverSwitchName = "chkEthernet";
        public const string SSLModeSwitchName = "chkConnectionMode";
        
        public const string EthernetSection = ".//*[@id='ethernet_text']/div[normalize-space(text())='Ethernet']";
        public const string SerialSection = ".//*[@id='ethernet_text']/div[normalize-space(text())='Serial']";

        /// <summary>
        /// Search Result locators
        /// </summary>
        public const string RegisterBtnDevList = ".//*[@id='divDiscoverDeviceListDisplay']//div[@class='device-detail']";


        public const string SearchResultGridDivID = "Devices";
        //public const string DeviceType = ".//*[@id='Devices']/div[2]//td[text()='#VALUE']/parent::tr/td[2]";

        /// <summary>
        /// Device Registration Form
        /// </summary>        
        // predefined value
        public const string RegistrationFormSection = "registerContent";
        public const string SummaryFormSection = "AddSummary";

        //public const string RegisterBtnDevForm = "Submit";
        public const string RegisterBtnDevForm = ".//*[@id='"+ RegistrationFormSection + "']//a[contains(.,'Register')]";

        public const string DeviceNameTxtBox = "Name";
        public const string DeviceGroupTxtBox = ".//*[@id='uglist_taglist']/following-sibling::input";
        public const string DeviceGroupSelectValue = ".//*[@id='uglist_listbox']/li[text()='#VALUE (Add New)']";
        public const string DeviceGroupDropdownClick = ".//*[@id='uglist_taglist']/li/span[1]";
        public const string IpOctet4 = "ipaddr_octet_4";

        public const string OkBtn = "btnOk";
        public const string AddNewBtnToContinueReg = ".//*[@id='"+ SummaryFormSection + "']//a[contains(.,'Add New')]";
        //".//*[@id='partialviewNetwork1']//span[normalize-space(text())='Information']"

        /// <summary>
        /// Device Discovery locators
        /// </summary>
        
    }
}