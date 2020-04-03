using System;
using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace IXMWEBv2.PageObjects
{
    public class HomePage_PO : GenericBasePage
    {
        public TopBar_PO TopBar { get; set; }

        public HomePage_PO()
        {
            TopBar = new TopBar_PO();
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = HomePageLocators.IXMWebVersion)]
        private IWebElement IxmWebVersionValue { get; set; }

        [FindsBy(How = How.Id, Using = HomePageLocators.AboutIXMWebOKBtn)]
        private IWebElement AboutIXMWebOKBtn { get; set; }

        [FindsBy(How = How.Id, Using = HomePageLocators.AboutIXMWebWindow)]
        private IWebElement AboutIXMWebWindow { get; set; }

        [FindsBy(How = How.ClassName, Using = HomePageLocators.EmailConfigBtn)]
        private IWebElement EmailConfigBtn { get; set; }

        public bool IsUserLoggedIn()
        {
            return TopBar.IsTopBarVisible();
        }

        public void ClickEmailConfigBtn()
        {
            WaitElementToBeClickable(EmailConfigBtn);
            ClickElement(EmailConfigBtn);
        }

        public void LogOut()
        {
            try
            {
                TopBar.LogOut();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "\n Logout: \n\n");
            }
        }

        public void CloseAboutIXMWeb()
        {
            try
            {
                WaitForElementPresent(AboutIXMWebWindow, 3);
                ClickElement(AboutIXMWebOKBtn);
                Logger.Info("Closed About IXM Web Window", "");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "\n CloseIXMWeb: \n\n");
            }
        }

        public string GetIXMWebVersion()
        {
            Logger.Info("Getting IXM Web Version from AboutIXMWeb Window", "");
            return IxmWebVersionValue.Text.Substring(IxmWebVersionValue.Text.LastIndexOf(" ")).Trim();
        }
    }
}