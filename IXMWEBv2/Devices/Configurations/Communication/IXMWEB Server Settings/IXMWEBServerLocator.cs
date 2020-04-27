namespace IXMWEBv2.Devices.Configurations.Communication.IXMWEB_Server_Settings
{
    public class IXMWEBServerLocator
    {
        #region IXMWEB Server Locators

        public const string IXMWEBServerDiv = "IXM WEB Server";
        public const string IXMWEBServerBodySection = "webServerBody";

        public const string IXMWEBServerURLTxt = ".//*[@id='" + IXMWEBServerBodySection + "']//*[@id='txtwebserverurl']";
        public const string IXMWEBServerApplyBtn = ".//*[@id='" + IXMWEBServerBodySection + "']//a[normalize-space(text())='Apply']";

        #endregion IXMWEB Server Locators
    }
}