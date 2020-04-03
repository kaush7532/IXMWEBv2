namespace IXMWEBv2.Devices.Configurations.Communication.USBAuxSettings
{
    public class USBAuxPortLocator
    {
        #region USB Aux Port Settings Locators

        public const string USBAuxPortDiv = "USB Auxiliary Port";

        public const string USBAuxPortBodySection = "usbauxCommBody";

        public const string USBAuxPortStatus = ".//*[@id='" + USBAuxPortBodySection + "']//*[@id='chkLockUnlockUSBAux']/following-sibling::label";

        public const string USBAuxPortStatusId = "chkLockUnlockUSBAux";

        public const string USBAuxPortApplyBtn = ".//*[@id='" + USBAuxPortBodySection + "']//a[contains(.,'Apply')]";

        public const string USBAuxPortResetBtn = ".//*[@id='" + USBAuxPortBodySection + "']//a[contains(.,'Reset')]";

        #endregion USB Aux Port Settings Locators

        #region USB Aux Port Messages Locators

        public const string USBAuxPortMsgBoxResetBtn = ".//*[@id='USBAuxResetConfirmationWindow']//a[normalize-space(text())='Reset']";

        public const string USBAuxPortMsgBoxResetCloseBtn = "";

        public const string USBAuxPortMsgBoxResetBtnBodyTxt = "";

        #endregion USB Aux Port Messages Locators
    }
}