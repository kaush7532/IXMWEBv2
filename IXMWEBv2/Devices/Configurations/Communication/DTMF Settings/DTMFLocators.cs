namespace IXMWEBv2.Devices.Configurations.Communication.DTMFSettings
{
    public class DTMFLocators
    {
        #region DTMF settings

        //Verification text 1
        public const string DTMFDiv = "DTMF Settings";

        // predefined value
        public const string DTMFBodySection = "dtmfBody";

        //1
        public const string DTMFSettingsSwitchChkBox = "btnDTMFHideShow";

        public const string DTMFSettingsSwitchChkBoxId = "chkDTMFStatus";
        //2
        //public const string DTMFSendWiegandChkBox = ".//*[@id='"+ DTMFBodySection + "']//*[@id='chkWiegandStatus']";

        public const string DTMFSendWiegandChkBox = ".//*[@id='" + DTMFBodySection + "']//*[@id='chkWiegandStatus']//following-sibling::label[text()='Send Wiegand']";

        public const string DTMFSendWiegandChkBoxId = "chkWiegandStatus";

        //3
        public const string DTMFDoorCodeTxt = ".//*[@id='" + DTMFBodySection + "']//*[@id='Code0']";

        //4
        public const string DTMFApplyBtn = ".//*[@id='" + DTMFBodySection + "']//a[contains(.,'Apply')]";

        //5
        public const string DTMFResetBtn = ".//*[@id='" + DTMFBodySection + "']//a[contains(.,'Reset')]";

        //*[@id='dtmfBody']//a[contains(.,'Apply')]
        //".//*[@id='dtmfBody']//*[normalize-space(text())='Apply']
        //*[@id='communication']//div[normalize-space(text())='DTMF Settings']

        #endregion DTMF settings

        #region Messages

        //6
        public const string DTMFMSGApplyBtnTitleTxt = "//div[@class='k-widget k-window Rounded-Rectangle-832']//*[normalize-space(text())='DTMF Settings']";

        //7
        public const string DTMFMSGCancelBtn = "//div[@class='k-widget k-window Rounded-Rectangle-832']//a";

        //8
        public const string DTMFMSGApplyBtnBodyTxt = "//div[@class='k-widget k-window Rounded-Rectangle-832']//p[normalize-space(text())='DTMF settings saved']";

        //verification text 1
        public const string DTMFMSGApplyVerifyBodyTxt = "DTMF settings saved";

        //9
        public const string DTMFMSGApplyBtn = "//div[@class='k-widget k-window Rounded-Rectangle-832']//*[@id='msgBoxOkButton']";

        //10
        public const string DTMFResetWindow = "RestoreDTMFSettings";

        public const string DTMFMSGResetBtn = ".//*[@id='RestoreDTMFSettings']//a[@title='Reset']";

        //11
        public const string DTMFMSGResetCloseBtn = "//div[@class='k-widget k-window Rounded-Rectangle-832']//a[normalize-space(text())='Close']";

        //12
        public const string DTMFMSGResetBtnBodyTxt = "//div[@class='k-widget k-window Rounded-Rectangle-832']//p[normalize-space(text())='This will permanently reset DTMF settings'";

        //Verification text 2
        public const string DTMFMSGResetVerifyBodyTxt = "This will permanently reset DTMF settings";

        #endregion Messages
    }
}