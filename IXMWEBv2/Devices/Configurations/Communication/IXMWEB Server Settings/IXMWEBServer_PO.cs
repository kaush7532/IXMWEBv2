using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace IXMWEBv2.Devices.Configurations.Communication.IXMWEB_Server_Settings
{
    public class IXMWEBServer_PO : GenericBasePage
    {
        public IXMWEBServer_PO()
        {
            PageFactory.InitElements(_driver, this);
        }

        #region IXMWEB Server Locator Declaration

        [FindsBy(How = How.XPath, Using = IXMWEBServerLocator.IXMWEBServerURLTxt)]
        private IWebElement IXMWEBServerURLTxtBox { get; set; }

        [FindsBy(How = How.XPath, Using = IXMWEBServerLocator.IXMWEBServerApplyBtn)]
        private IWebElement IXMWEBServerURLApplyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = CommonLocators.KendoMsgTxt)]
        private IWebElement KendoMsgWindowTxt { get; set; }

        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgOKBtn)]
        private IWebElement KendoMsgOKBtn { get; set; }

        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgWindow)]
        private IWebElement KendoMsgWindow { get; set; }

        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgWindowTitle)]
        private IWebElement KendoMsgWindowTitle { get; set; }

        #endregion IXMWEB Server Locator Declaration

        #region Methods

        /// <summary>
        /// Method to validate IXMWEB Server Page UI elements
        /// </summary>
        /// <returns>true if valid else false</returns>
        public bool IsIXMWEBServerPageValid()
        {
            bool flag = false;
            int waitTime = 7;
            try
            {
                List<IWebElement> eleList = new List<IWebElement>
                {
                    IXMWEBServerURLTxtBox,
                    IXMWEBServerURLApplyBtn
                };

                flag = AreElementsPresent(eleList, waitTime);
                if (flag)
                {
                    Logger.Info("Validation success for UI elements for IXMWEB Server Settings.");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to validate IXMWEB Server page UI");
                throw new Exception("Failed to validate IXMWEB Server page UI");
            }
            return flag;
        }

        /// <summary>
        /// Method to enter ixmweb server url
        /// </summary>
        /// <param name="urlValue">value of url</param>
        /// <returns>text entered in urlvalue</returns>
        public string EnterIXMWEBServerURL(string urlValue)
        {
            try
            {
                if (IsIXMWEBServerPageValid())
                {
                    WaitForElementPresent(IXMWEBServerURLTxtBox);
                    EnterValueTextbox(IXMWEBServerURLTxtBox, urlValue);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to enter IXMWEB Server URL value in text box", ex.InnerException);
            }
            return IXMWEBServerURLTxtBox.Text;
        }

        public string GetIXMWEBServerURL()
        {
            string urlvalue = null;
            try
            {
                if (IsIXMWEBServerPageValid())
                {
                    urlvalue = IXMWEBServerURLTxtBox.Text;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Get IXMWEB Server URL value from text box");
                throw new Exception("Failed to Get IXMWEB Server URL value from text box");
            }
            return urlvalue;
        }

        /// <summary>
        /// Method to click apply
        /// </summary>
        /// <returns>Model having urlvalue, popup details</returns>
        public IXMWEBServerURLModel ClickApply()
        {
            string msg = null;
            string titlemsg = null;
            try
            {
                WaitElementToBeClickable(IXMWEBServerURLApplyBtn);
                ClickElement(IXMWEBServerURLApplyBtn);
                Logger.Info("Clicked Apply button on IXMWEBServer UI");
                //Click on IXMWEB Server settings
                if (IsElementPresent(KendoMsgWindow, 10))
                {
                    msg = KendoMsgWindowTxt.Text;
                    titlemsg = KendoMsgWindowTitle.Text;
                    ClickElement(KendoMsgOKBtn);
                    Logger.Info("Clicked OK button on KendoWindow.");
                }
                else
                {
                    throw new Exception("No confirmation message shown on Apply of IXMWEB server settings");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to click reset on Bluetooth Settings");
                throw;
            }
            return new IXMWEBServerURLModel
            {
                IXMWEBServerPopupTitleValue = titlemsg,
                IXMWEBServerStatusTxtValue = msg,
                IXMWEBServerURLTxtValue = IXMWEBServerURLTxtBox.GetAttribute("value")
            };
        }

        #endregion Methods
    }
}