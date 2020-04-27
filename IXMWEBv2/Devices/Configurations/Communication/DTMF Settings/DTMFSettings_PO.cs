using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace IXMWEBv2.Devices.Configurations.Communication.DTMFSettings
{
    public class DTMFSettings_PO : GenericBasePage
    {
        public DTMFSettings_PO()
        {
            PageFactory.InitElements(_driver, this);
        }

        #region Declaration: DTMF Section

        //1
        [FindsBy(How = How.Id, Using = DTMFLocators.DTMFSettingsSwitchChkBox)]
        private IWebElement DTMFsettingsswitch { get; set; }

        //2
        [FindsBy(How = How.XPath, Using = DTMFLocators.DTMFSendWiegandChkBox)]
        private IWebElement DTMFWiegandSetting { get; set; }

        //3
        [FindsBy(How = How.XPath, Using = DTMFLocators.DTMFDoorCodeTxt)]
        private IWebElement DTMFDoorOpenTimeCode { get; set; }

        //4
        [FindsBy(How = How.XPath, Using = DTMFLocators.DTMFApplyBtn)]
        private IWebElement DTMFApplyButton { get; set; }

        //5
        [FindsBy(How = How.XPath, Using = DTMFLocators.DTMFResetBtn)]
        private IWebElement DTMFResetButton { get; set; }

        //6
        [FindsBy(How = How.XPath, Using = CommonLocators.KendoMsgTxt)]
        private IWebElement DTMFMsgWindowTxt { get; set; }

        //7
        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgOKBtn)]
        private IWebElement DTMFMsgOKBtn { get; set; }

        //8
        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgWindow)]
        private IWebElement DTMFMsgWindow { get; set; }

        [FindsBy(How = How.Id, Using = DTMFLocators.DTMFResetWindow)]
        private IWebElement DTMFResetMsgWindow { get; set; }

        //9
        [FindsBy(How = How.XPath, Using = DTMFLocators.DTMFMSGApplyBtn)]
        private IWebElement DTMFMsgApplyBtn { get; set; }

        //10
        [FindsBy(How = How.XPath, Using = DTMFLocators.DTMFMSGResetBtn)]
        private IWebElement DTMFMsgResetBtn { get; set; }

        //11
        [FindsBy(How = How.XPath, Using = DTMFLocators.DTMFMSGResetCloseBtn)]
        private IWebElement DTMFMsgResetCloseBtn { get; set; }

        //12
        [FindsBy(How = How.XPath, Using = DTMFLocators.DTMFMSGResetBtnBodyTxt)]
        private IWebElement DTMFMsgResetBtnBodyTxt { get; set; }

        #endregion Declaration: DTMF Section

        public DTMFConfigModel GetDTMFSettingsUI()
        {
            DTMFConfigModel settings = new DTMFConfigModel();
            try
            {
                WaitElementToBeClickable(DTMFsettingsswitch);

                var x = DTMFDoorOpenTimeCode.GetAttribute("value");
                settings.DTMFCode = Convert.ToInt32(DTMFDoorOpenTimeCode.GetAttribute("value"));

                settings.DTMFStatus = IsCheckboxActive(DTMFLocators.DTMFSettingsSwitchChkBoxId);
                settings.SendWiegandStatus = IsCheckboxActive(DTMFLocators.DTMFSendWiegandChkBoxId);
                //settings.DTMFSettingsStatusTxtValue =
                Logger.Info(string.Format("Retrived DTMF setting from info code {0}, status {1}, wiegand {2}",
                    settings.DTMFCode, settings.DTMFStatus, settings.SendWiegandStatus));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "failed to get DTMF setting from UI");
            }
            return settings;
        }

        public bool ShowDTMFSettings() //1
        {
            bool DTMFEnable = IsElementEnabled(By.XPath(DTMFLocators.DTMFSendWiegandChkBox));
            //verify DTMF setting enable or disabled

            if (DTMFEnable == true)
            {
                Logger.Info("true");
            }

            //return status as true or false
            return DTMFEnable;
        }

        /// <summary>
        /// Method to set SendWiegand status
        /// </summary>
        /// <param name="turnON">true to TURNON; false to TURNOFF</param>
        /// <returns>true if ON; false if OFF</returns>
        public bool SetSendWeigandStatus(bool turnON) //2
        {
            bool status = IsCheckboxActive(DTMFLocators.DTMFSendWiegandChkBoxId);
            try
            {
                if (turnON)
                {
                    if (status)
                    {
                        Logger.Info("DTMF: Send Wiegand switch status already TURNED ON");
                    }
                    else
                    {
                        WaitElementToBeClickable(DTMFWiegandSetting);
                        ClickElement(DTMFWiegandSetting);
                        Logger.Info("DTMF: Send Wiegand switch status TURNED ON");
                    }
                }
                else
                {
                    if (!status)
                    {
                        Logger.Info("DTMF: Send Wiegand switch status already TURNED OFF");
                    }
                    else
                    {
                        WaitElementToBeClickable(DTMFWiegandSetting);
                        ClickElement(DTMFWiegandSetting);
                        Logger.Info("DTMF: Send Wiegand switch status TURNED OFF");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Set Wiegand status for DTMF to: " + status);
                throw;
            }
            //bool test = DTMFWiegandSetting.Selected;
            return IsCheckboxActive(DTMFLocators.DTMFSendWiegandChkBoxId);
        }

        /// <summary>
        /// Method to click apply button on DTMFSettings
        /// </summary>
        /// <returns>message value from kendobox</returns>
        public string ClickApply()
        {
            string msg = null;
            try
            {
                WaitElementToBeClickable(DTMFApplyButton);
                ClickElement(DTMFApplyButton);
                if (IsElementPresent(DTMFMsgWindow))
                {
                    msg = DTMFMsgWindowTxt.Text;
                    ClickElement(DTMFMsgOKBtn);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to click apply on DTMFSettings");
                throw;
            }
            return msg;
            //click on DMTF Apply Button
        }

        /// <summary>
        /// Method to click reset button on DTMFSettings
        /// </summary>
        public string ClickReset()
        {
            string msg = null;
            try
            {
                WaitElementToBeClickable(DTMFResetButton);
                ClickElement(DTMFResetButton);
                //Click on DTMF settings
                if (IsElementPresent(DTMFResetMsgWindow))
                {
                    msg = DTMFResetMsgWindow.Text;
                    ClickElement(DTMFMsgResetBtn);
                }
                if (IsElementPresent(DTMFMsgWindow))
                {
                    msg = msg + " " + DTMFMsgWindow.Text;
                    ClickElement(DTMFMsgOKBtn);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to click apply on DTMFSettings");
                throw;
            }
            return msg;
        }

        /// <summary>
        /// Method to turnON/OFF status of DTMF settings
        /// </summary>
        /// <param name="turnON">true to TURNON; false to TURNOFF</param>
        /// <returns>true if ON; false if OFF</returns>
        public bool ToggleDTMFStatusSwitch(bool turnON)
        {
            bool status = IsCheckboxActive(DTMFLocators.DTMFSettingsSwitchChkBoxId);
            try
            {
                if (turnON)
                {
                    if (status)
                    {
                        Logger.Info("DTMF switch status already TURNED ON");
                    }
                    else
                    {
                        WaitElementToBeClickable(DTMFsettingsswitch);
                        ClickElement(DTMFsettingsswitch);
                        Logger.Info("DTMF switch status TURNED ON");
                    }
                }
                else
                {
                    if (!status)
                    {
                        Logger.Info("DTMF switch status already TURNED OFF");
                    }
                    else
                    {
                        WaitElementToBeClickable(DTMFsettingsswitch);
                        ClickElement(DTMFsettingsswitch);
                        Logger.Info("DTMF switch status TURNED OFF");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Toggle DTMF settings to: " + turnON);
                throw;
            }
            return IsCheckboxActive(DTMFLocators.DTMFSettingsSwitchChkBoxId);
        }

        /// <summary>
        /// Method to set DTMF Code.
        /// </summary>
        /// <param name="dtmfCode">If null then default will remain</param>
        /// <returns>default or set DTMF code</returns>
        public int SetDTMFCode(string dtmfCode = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(dtmfCode))
                {
                    EnterValueTextbox(DTMFDoorOpenTimeCode, dtmfCode);
                    Logger.Info("DTMFCode set to: " + dtmfCode);
                }
                else
                {
                    Logger.Info("DTMF code not to set. Keeping default");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to Set DTMFCode");
                throw;
            }
            return Convert.ToInt32(DTMFDoorOpenTimeCode.GetAttribute("value"));
        }
    }
}