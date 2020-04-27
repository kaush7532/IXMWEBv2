namespace IXMWEBv2.Devices.Configurations.Communication.WEBCloud_Settings
{
    public class WEBCloudLocators
    {
        #region WebCloud locators

        //Verification text 1
        public const string WEBCloudDiv = "Web Cloud";

        // predefined value
        public const string WEBCloudBodySection = "cloudSSLCommunicationBody";

        //1
        public const string WEBCloudSettingsSwitchChkBox = "btnCloudHideShow";

        public const string WEBCloudSettingsSwitchChkBoxId = "chkEnableCloudSettings";

        #region IXMWebServer Locators

        public const string WEBCloudUrlTxt = ".//*[@id = '" + WEBCloudBodySection + "']//*[@id = 'cloudUrl']";

        public const string WEBCloudPortTxt = ".//*[@id = '" + WEBCloudBodySection + "']//*[@id = 'cloudPort']";

        #endregion IXMWebServer Locators

        #region SSL Mode Locators

        public const string SSLModeStatusChkBox = ".//*[@id='" + WEBCloudBodySection + "']//*[@id = 'cloudSslStatus']//following-sibling::label[text()='Status']";

        public const string DefaultCertificateChkBox = ".//*[@id='" + WEBCloudBodySection + "']//*[@id = 'isCloudDefaultCertificate']//following-sibling::label[text()=' Default Certificate']";

        public const string CertificateForDeviceDropdown = ".//*[@id = '" + WEBCloudBodySection + "']//*[@id = 'ddCloudCertificateList']";

        public const string CertificatePasswordTxt = ".//*[@id = '" + WEBCloudBodySection + "']//*[@id = 'txtCloudCertificatePassword']";

        #endregion SSL Mode Locators

        #region Buttons

        public const string WEBCloudApplyBtn = ".//*[@id='" + WEBCloudBodySection + "']//a[contains(.,'Apply')]";

        public const string WEBCloudResetBtn = ".//*[@id='" + WEBCloudBodySection + "']//a[contains(.,'Reset')]";

        #endregion Buttons

        public const string WEBCloudResetWindow = "RestoreCloudSettings";

        public const string WEBCloudMSGResetBtn = ".//*[@id='RestoreCloudSettings']//a[@title='Reset']";

        #endregion WebCloud locators
    }
}