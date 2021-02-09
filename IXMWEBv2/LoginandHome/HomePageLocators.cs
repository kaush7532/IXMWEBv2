namespace IXMWEBv2.Resources.Locators
{
    public class HomePageLocators
    {
        public const string HomeBtn = "btnHome";

        #region Top bar locators

        /// <summary>
        /// Top Bar locators like logout button, about ixm web window, reset password
        /// </summary>
        public const string UserDropdown = "AdminUserName";

        public const string TopBar = "brand-logo-main";

        public const string EmailConfigBtn = "warningImage";

        #endregion Top bar locators

        #region User dropdown locators button like logout, aboutixmweb, etc..

        /// <summary>
        /// User Dropdown items
        /// </summary>
        public const string AboutIXMWebWindowBtn = ".//li/a[text()='About IXM WEB']";

        public const string LogOutBtn = ".//li/a[text()='Sign Out']";

        #endregion User dropdown locators button like logout, aboutixmweb, etc..

        #region About IXM Web buttn and window locators

        /// <summary>
        /// About IXM Web Window
        /// </summary>
        public const string AboutIXMWebOKBtn = "btnAboutOk";

        public const string AboutIXMWebWindow = "AboutIXMWEBWindow_wnd_title";
        public const string IXMWebVersion = ".//*[@id='AboutIXMWEBWindow']//div[@class='aboutversion']/p[1]";

        #endregion About IXM Web buttn and window locators

        #region DeviceItems locators for deviceusers, device user groups and device smart card

        /// <summary>
        /// Dropdown for selection of device items like device users, device user groups, revoked smart cards
        /// </summary>
        public const string DeviceItemsDropdown = ".//*[@id='menuImages']//span[text()='Device']";

        public const string DeviceUsersBtn = ".//*[@id='menuImages']/li//span[text()='Users']";
        public const string DeviceUserGroupsBtn = ".//*[@id='menuImages']/li//span[text()='User Groups']";
        public const string DeviceRevokedSmartCard = ".//*[@id='menuImages']/li//span[text()='Revoked Smart Cards']";

        #endregion DeviceItems locators for deviceusers, device user groups and device smart card

        #region Module tiles locators on home page

        /// <summary>
        /// Module Tiles
        /// </summary>
        public const string NavigationButton1 = "navbuttton1";

        public const string NavigationButton2 = "navbuttton2";

        public const string UserTile = ".//*[@id='Tile_47d2eeaf-9548-4dfe-be1b-9b713c8e40e6']//div[@title='Users']";
        public const string DeviceTab = "btnLoadDevices";
        public const string SmartCardTile = ".//*[@id='Tile_c30ba477-24df-4f72-a129-c484eaed9ce4']//div[@title='Smart Card']";
        public const string ToolsTile = ".//*[@id='Tile_1eb58806-e264-4fa0-871f-a09f4a4f7b32']//div[@title='Tools']";
        public const string LogsTab = "btnLoadLogs";
        public const string SyncTile = "btnSync";
        public const string ConfigTile = ".//*[@id='Tile_0ca775cb-0cbf-45a0-9c94-8c2e68970708']//div[@title='Config']";
        public const string TranslateTile = ".//*[@id='Tile_2d11045a-9bba-44e9-9197-ca50881d050b']//div[@title='Translate']";
        public const string ReportTile = ".//*[@id='Tile_86085377-3d82-4a0f-8763-58f49e6815fe']//div[@title='Report']";
        public const string ConvertTile = ".//*[@id='Tile_46bfc501-2305-4551-b525-276c22287680']//div[@title='Convert']";
        public const string LinkTile = ".//*[@id='Tile_01fbbfeb-404b-4b18-9d68-b627ea3a70fb']//div[@title='Link']";
        public const string LicenseTile = ".//*[@id='Tile_42ffacc8-c652-4cff-ad74-65ea3af29b63']//div[@title='License']";
        public const string EmployeeTab = "btnLoadEmployees";

        #endregion Module tiles locators on home page

        #region Modules hyperlink locators

        public const string HomePageHyperLink = ".//*[@class='clickableNode3']/a[contains(text(),'Home')]";
        public const string AlreadyInUsersTile = ".//*[@class='currentNode3']/span[contains(text(),'Users')]";
        public const string AlreadyInDeviceTile = ".//*[@class='currentNode3']/span[contains(text(),'Devices')]";
        public const string AlreadyInLogsTile = ".//*[@class='currentNode3']/span[contains(text(),'Logs')]";
        public const string AlreadyInToolsTile = ".//*[@class='currentNode3']/span[contains(text(),'Tools')]";
        public const string AlreadyInTLogs = ".//*[@class='currentNode3']/span[contains(text(),'Transaction') and contains(text(),'Logs')]";
        public const string AlreadyInAppLogs = ".//*[@class='currentNode3']/span[contains(text(),'Application') and contains(text(),'Logs')]";
        public const string AlreadyInConfigTile = ".//*[@class='currentNode3']/span[contains(text(),'Config')]";

        #endregion Modules hyperlink locators
    }
}