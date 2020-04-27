using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace IXMWEBv2.Devices.Configurations.Communication.WEBCloud_Settings
{
    public class WEBCloudSettings_PO : GenericBasePage
    {
        public WEBCloudSettings_PO()
        {
            PageFactory.InitElements(_driver, this);
        }

        #region Declaration: WEBCloudSettings Section

        [FindsBy(How = How.Id, Using = WEBCloudLocators.WEBCloudSettingsSwitchChkBox)]
        private IWebElement WEBcloudsettingsswitchchkbox { get; set; }

        #region Declaration: IXMWebServer Section

        [FindsBy(How = How.XPath, Using = WEBCloudLocators.WEBCloudUrlTxt)]
        private IWebElement WEBcloudurltxt { get; set; }

        [FindsBy(How = How.XPath, Using = WEBCloudLocators.WEBCloudPortTxt)]
        private IWebElement WEBcloudporttxt { get; set; }

        #endregion Declaration: IXMWebServer Section

        #region Declaration: SSL Mode Section

        [FindsBy(How = How.XPath, Using = WEBCloudLocators.SSLModeStatusChkBox)]
        private IWebElement SSLmodestatuschkbox { get; set; }

        [FindsBy(How = How.XPath, Using = WEBCloudLocators.DefaultCertificateChkBox)]
        private IWebElement Defaultcertificatechkbox { get; set; }

        [FindsBy(How = How.XPath, Using = WEBCloudLocators.CertificateForDeviceDropdown)]
        private IWebElement Certificatefordevicedropdown { get; set; }

        [FindsBy(How = How.XPath, Using = WEBCloudLocators.CertificatePasswordTxt)]
        private IWebElement Certificatepasswordtxt { get; set; }

        #endregion Declaration: SSL Mode Section

        #region Declaration: Buttons Section

        [FindsBy(How = How.XPath, Using = WEBCloudLocators.WEBCloudApplyBtn)]
        private IWebElement WEBcloudapplybtn { get; set; }

        [FindsBy(How = How.XPath, Using = WEBCloudLocators.WEBCloudResetBtn)]
        private IWebElement WEBcloudresetbtn { get; set; }

        #endregion Declaration: Buttons Section

        #region Declaration: KendoMsgBox Section

        [FindsBy(How = How.XPath, Using = CommonLocators.KendoMsgTxt)]
        private IWebElement WEBCloudMsgWindowTxt { get; set; }

        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgOKBtn)]
        private IWebElement WEBCloudMsgOKBtn { get; set; }

        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgWindow)]
        private IWebElement WEBCloudMsgWindow { get; set; }

        #endregion Declaration: KendoMsgBox Section

        #region Declaration: WEBCloudSettings Reset Window Section

        [FindsBy(How = How.Id, Using = WEBCloudLocators.WEBCloudResetWindow)]
        private IWebElement WEBcloudresetwindow { get; set; }

        [FindsBy(How = How.XPath, Using = WEBCloudLocators.WEBCloudMSGResetBtn)]
        private IWebElement WEBcloudmsgresetbtn { get; set; }

        #endregion Declaration: WEBCloudSettings Reset Window Section



        #endregion Declaration: WEBCloudSettings Section

        /// <summary>
        /// Method to verify whether all the page elements are present or not
        /// </summary>
        /// <returns>true if all the elements are present else false</returns>
        public bool PageElementsAreVisible()
        {
            try
            {
                WaitForElementPresent(WEBcloudapplybtn);

                if (IsElementPresent(WEBcloudsettingsswitchchkbox) &&
                    IsElementPresent(WEBcloudurltxt) &&
                    //IsElementPresent(WEBcloudporttxt) &&
                    IsElementPresent(SSLmodestatuschkbox) &&
                    IsElementPresent(Defaultcertificatechkbox) &&
                    //IsElementPresent(Certificatefordevicedropdown) &&
                    IsElementPresent(Certificatepasswordtxt) &&
                    IsElementPresent(WEBcloudapplybtn) &&
                    IsElementPresent(WEBcloudresetbtn))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to validate WEBCloud Settings UI");
                return false;
                throw;
            }
        }

        /// <summary>
        /// Method to turnON/OFF status of WEBCloud settings
        /// </summary>
        /// <param name="turnON">true to TURNON; false to TURNOFF</param>
        /// <returns>true if ON; false if OFF</returns>
        public bool ToggleWEBCloudStatusSwitch(bool turnON)
        {
            bool status = IsCheckboxActive(WEBCloudLocators.WEBCloudSettingsSwitchChkBoxId);
            try
            {
                if (turnON)
                {
                    if (status)
                    {
                        Logger.Info("WEBCloud switch status already TURNED ON");
                    }
                    else
                    {
                        WaitElementToBeClickable(WEBcloudsettingsswitchchkbox);
                        ClickElement(WEBcloudsettingsswitchchkbox);
                        Logger.Info("WEBCloud switch status TURNED ON");
                    }
                }
                else
                {
                    if (!status)
                    {
                        Logger.Info("WEBCloud switch status already TURNED OFF");
                    }
                    else
                    {
                        WaitElementToBeClickable(WEBcloudsettingsswitchchkbox);
                        ClickElement(WEBcloudsettingsswitchchkbox);
                        Logger.Info("WEBCloud switch status TURNED OFF");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Toggle WEBCloud settings to: " + turnON);
                throw;
            }
            return IsCheckboxActive(WEBCloudLocators.WEBCloudSettingsSwitchChkBoxId);
        }

        /// <summary>
        /// Method to enter WEBCloud URL.
        /// </summary>
        /// <param name="cloudurl">valur of cloudurl</param>
        /// <returns>cloudURL</returns>
        public string EnterWEBCloudURL(string cloudurl)
        {
            try
            {
                EnterValueTextbox(WEBcloudurltxt, cloudurl);
                Logger.Info("Cloud URL: " + cloudurl + "is entered in WEBCloud URL textbox");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to enter anything in WEBCloud URL textbox");
                throw;
            }
            return cloudurl;
        }

        /// <summary>
        /// Method to set WEBCloud Port.
        /// </summary>
        /// <param name="cloudport">If null then default will remain</param>
        /// <returns>default or value of WEBCloud port which is saved</returns>
        public int SetWEBCloudPort(string cloudport = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(cloudport))
                {
                    EnterValueTextbox(WEBcloudporttxt
, cloudport);
                    Logger.Info("WEBCloud Port set to: " + cloudport);
                }
                else
                {
                    Logger.Info("WEBCloud Port not to set. Keeping default");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to Set WEBCloud Port");
                throw;
            }
            return Convert.ToInt32(WEBcloudporttxt.GetAttribute("value"));
        }

        /// <summary>
        /// Method to click apply button on WEBCloudSettings
        /// </summary>
        /// <returns>message value from kendobox</returns>
        public string ClickApply()
        {
            string msg = null;
            try
            {
                WaitElementToBeClickable(WEBcloudapplybtn);
                ClickElement(WEBcloudapplybtn);
                if (IsElementPresent(WEBCloudMsgWindow))
                {
                    msg = WEBCloudMsgWindowTxt.Text;
                    ClickElement(WEBCloudMsgOKBtn);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to click on apply button for WEBCloudSettings");
                throw;
            }
            return msg;
            //click on WEBCloudSettings Apply Button
        }

        /// <summary>
        /// Method to click reset button on WEBCloudSettings
        /// </summary>
        public string ClickReset()
        {
            string msg = null;
            try
            {
                WaitElementToBeClickable(WEBcloudresetbtn);
                ClickElement(WEBcloudresetbtn);
                //Click on WEBCloud settings
                if (IsElementPresent(WEBcloudresetwindow))
                {
                    msg = WEBcloudresetwindow.Text;
                    ClickElement(WEBcloudmsgresetbtn);
                }
                if (IsElementPresent(WEBCloudMsgWindow))
                {
                    msg = msg + " " + WEBCloudMsgWindow.Text;
                    ClickElement(WEBCloudMsgOKBtn);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to click reset on WEBCloud Settings");
                throw;
            }
            return msg;
        }

        /// <summary>
        /// This method gets WEBCloud settings from UI
        /// </summary>
        /// <returns>webcloud settings</returns>
        public WEBCloudConfigModel GetWEBCloudSettingsUI()
        {
            WEBCloudConfigModel settings = new WEBCloudConfigModel();
            try
            {
                WaitElementToBeClickable(WEBcloudsettingsswitchchkbox);

                settings.WEBCloudStatus = IsCheckboxActive(WEBCloudLocators.WEBCloudSettingsSwitchChkBoxId);

                settings.WEBCloudSettingsUrlTxtValue = WEBcloudurltxt.Text;

                var x = WEBcloudporttxt.GetAttribute("value");
                settings.WEBCloudPortValue = Convert.ToInt32(WEBcloudporttxt.GetAttribute("value"));

                //settings.WEBCloudSettingsStatusTxtValue =
                Logger.Info(string.Format("Retrived WEBCloud setting from info status {0}, URL {1}, port {2}",
                    settings.WEBCloudStatus, settings.WEBCloudSettingsUrlTxtValue, settings.WEBCloudPortValue));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "failed to get WEBCloud setting from UI");
            }
            return settings;
        }
    }
}