using System;
using IXMWEBv2.Constants;
using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace IXMWEBv2.PageObjects
{
    public class TopBar_PO : GenericBasePage
    {
        public TopBar_PO()
        {
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.ClassName, Using = HomePageLocators.TopBar)]
        private IWebElement TopBar { get; set; }

        [FindsBy(How = How.Id, Using = HomePageLocators.UserDropdown)]
        private IWebElement UserDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.AboutIXMWebWindowBtn)]
        private IWebElement AboutIXMWebBtn { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.LogOutBtn)]
        private IWebElement LogoutBtn { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.DeviceItemsDropdown)]
        private IWebElement DeviceItemsDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.DeviceUsersBtn)]
        private IWebElement DeviceUsersList { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.DeviceUserGroupsBtn)]
        private IWebElement DeviceUserGroupsList { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.DeviceRevokedSmartCard)]
        private IWebElement DeviceRevokedSmartCardList { get; set; }

        /// <summary>
        /// Method to click user dropdown
        /// </summary>
        public void ClickUserDropdown()
        {
            try
            {
                ClickElement(UserDropdown);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "\n ClickUserDropdown: \n\n");
            }
        }

        public void OpenAboutIXMWeb()
        {
            try
            {
                ClickUserDropdown();
                ClickElement(AboutIXMWebBtn, 15);
                Logger.Info("Opened About IXM Web window", "");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "\n About IXM Web: \n\n");
            }
        }

        public void LogOut()
        {
            try
            {
                ClickUserDropdown();
                ClickElement(LogoutBtn, 15);
                Logger.Info("Logged out from IXM Web", Module.LoginModule);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "\n Logout: \n\n");
            }
        }

        public bool IsTopBarVisible()
        {
            return IsElementPresent(TopBar, 10);
        }

        //public DeviceUsers_PO GoToDeviceUsersPage()
        //{
        //    WaitForVisibleElement(By.Id(HomePageLocators.TopBar));
        //    HoverWebElement(deviceItemsDropdown, 10);
        //    ClickElement(deviceUsersList);
        //    Logger.Info("Navigated to Device->Users from Topbar", Modules.Users.ToString());
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);

        //    return new DeviceUsers_PO();
        //}

        //public DeviceUserGroups_PO GoToDeviceUserGroupsPage()
        //{
        //    WaitForVisibleElement(By.Id(HomePageLocators.TopBar));
        //    HoverWebElement(deviceItemsDropdown, 10);
        //    ClickElement(deviceUserGroupsList);
        //    Logger.Info("Navigated to Device->User Groups from Topbar", Modules.Users.ToString());
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
        //    return new DeviceUserGroups_PO();
        //}

        //public DeviceRevokedSmartCards_PO GoToDeviceRevokedSmartCards()
        //{
        //    WaitForVisibleElement(By.Id(HomePageLocators.TopBar));
        //    HoverWebElement(deviceItemsDropdown, 10);

        //    ClickElement(deviceRevokedSmartCardList);
        //    Logger.Info("Navigated to Device->Revoked Smart Card from Topbar", Modules.Users.ToString());
        //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
        //    return new DeviceRevokedSmartCards_PO();
        //}
    }
}