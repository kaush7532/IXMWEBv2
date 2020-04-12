namespace IXMWEBv2.Resources.Locators.DeviceTile
{
    public class RegisterDeviceLocators
    {
        public const string AddNewDeviceWindowTxt = "";
        public const string AddDeviceNavigationItems = "";
        public const string AddDeviceDiscoverySection = "DiscoverySection";
        public const string AddDeviceRegisterSection = "registerContent";
        public const string AddDeviceSummarySection = "SummarySection";
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

        #region Discovered Devices
        public const string DiscoveredDevices = ".//*[@id='Devices']//div[@class[contains(.,'device-list-box')]]";
        public const string AlreadyRegisteredDevices = "//img[@title='Registered']/preceding-sibling::ul//p";
        public const string RegisterBtnDevList = ".//*[@id='divDiscoverDeviceListDisplay']//div[@class='device-detail']";
        #endregion

        #endregion

        #region Register

        #region Icon
        public const string DeviceToRegisterIcon = "";
        #endregion
        #region Text Boxes
        public const string DeviceNameTxt = "Name";
        public const string DeviceIdTxt = "DeviceId";
        public const string DeviceGroupTxt = ".//*[@id='uglist_taglist']/following-sibling::input";
        public const string DeviceIpAddrTxt = "ip";
        public const string DevicePortTxt = "Port";
        public const string DeviceSubnetMaskTxt = "subnetMask";
        public const string DeviceGatewayTxt = "Gateway";
        public const string DeviceGroupSelectValue = ".//*[@id='uglist_listbox']/li[text()='#VALUE (Add New)']";
        #endregion
        #region CheckBoxes
        public const string TnAChkbox = ".//*[@id='" + AddDeviceRegisterSection + "']//*[@id='" + TnAChkboxId + "']" +
            "//following-sibling::label[normalize-space(text())='T&A Device']";
        public const string TnAChkboxId = "TnADevice";
        public const string DHCPChkbox = ".//*[@id='" + AddDeviceRegisterSection + "']//*[@id='" + DHCPChkboxId + "']" +
            "//following-sibling::label[normalize-space(text())='DHCP']";
        public const string DHCPChkboxId = "ObtainThroughDHCP";

        #endregion
        #region Buttons
        public const string RegisterBtn = ".//*[@id='" + AddDeviceRegisterSection + "']//a[contains(.,'Register')]";
        #endregion
        #region Dropdown
        public const string DeviceModeDrpDownName = "DeviceMode";
        public const string DeviceModeDrpDown = ".//*[@id='DeviceMode']//preceding-sibling::span";
        #endregion

        #endregion

        #region Summary
        public const string NetworkInfoItems = ".//*[@id='" + AddDeviceSummarySection + "']//*[@class='card custom-card']" +
            "//div[normalize-space(text())='Network Information']//following-sibling::div//li";
        public const string DeviceInfoItems = ".//*[@id='" + AddDeviceSummarySection + "']//*[@class='card custom-card']" +
            "//div[normalize-space(text())='Device Information']//following-sibling::div//li";

        #region Buttons        
        public const string AddNewBtnToContinueReg = ".//*[@id='" + AddDeviceSummarySection + "']//a[contains(.,'Add New')]";
        public const string DoneBtn = ".//*[@id='" + AddDeviceSummarySection + "']//a[contains(.,'Done')]";
        #endregion
        #endregion

        #region Resource Strings
        public const string NoDeviceFoundResource = "No Device found. Try again.";
        #endregion
    }
}