using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace IXMWEBv2.Devices.Configurations.Communication.Bluetooth_Settings
{
    public class BluetoothSettings_PO : GenericBasePage
    {
        public BluetoothSettings_PO()
        {
            PageFactory.InitElements(_driver, this);
        }

        #region Declaration: Bluetooth Section

        [FindsBy(How = How.Id, Using = BluetoothSettingsLocator.BluetoothSettingsSwitchChkBox)]
        private IWebElement BluetoothSettingsSwitch { get; set; }

        [FindsBy(How = How.XPath, Using = BluetoothSettingsLocator.BluetoothSettingsRefreshBtn)]
        private IWebElement BluetoothRefreshButton { get; set; }

        [FindsBy(How = How.Id, Using = BluetoothSettingsLocator.BluetoothSearchProgressBar)]
        private IWebElement BluetoothSearchDevices { get; set; }

        [FindsBy(How = How.XPath, Using = BluetoothSettingsLocator.BluetoothSettingsResetBtn)]
        private IWebElement BluetoothResetButton { get; set; }

        [FindsBy(How = How.XPath, Using = CommonLocators.KendoMsgTxt)]
        private IWebElement KendoMsgWindowTxt { get; set; }

        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgOKBtn)]
        private IWebElement KendoMsgOKBtn { get; set; }

        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgWindow)]
        private IWebElement KendoMsgWindow { get; set; }

        [FindsBy(How = How.Id, Using = BluetoothSettingsLocator.BluetoothResetWindow)]
        private IWebElement BluetoothResetWindow { get; set; }

        [FindsBy(How = How.XPath, Using = BluetoothSettingsLocator.BluetoothResetWindowMsg)]
        private IWebElement BluetoothResetWindowMsgTxt { get; set; }

        [FindsBy(How = How.XPath, Using = BluetoothSettingsLocator.BluetoothResetWindowResetBtn)]
        private IWebElement BluetoothResetWindowResetBtn { get; set; }

        #endregion Declaration: Bluetooth Section

        #region Methods

        /// <summary>
        /// Method to validate Bluetooth Settings UI
        /// </summary>
        /// <returns>true if all elemtes are present</returns>
        public bool IsBluetoothSettingsUIValid()
        {
            bool flag = false;
            int waitTime = 7;
            try
            {
                List<IWebElement> eleList = new List<IWebElement>
                {
                    BluetoothSettingsSwitch,
                    BluetoothResetButton,
                    BluetoothRefreshButton,
                };

                flag = AreElementsPresent(eleList, waitTime);
                if (flag)
                {
                    Logger.Info("Validation success for UI elements for Bluetooth Settings.");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Bluetooth Settings page UI elements invalid");
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// Method to turnON/OFF status of Bluetooth settings
        /// </summary>
        /// <param name="turnON">true to TURNON; false to TURNOFF</param>
        /// <returns>true if ON; false if OFF</returns>
        public BluetoothSettingsModel ToggleBluetoothStatusSwitch(bool turnON)
        {
            bool status = IsCheckboxActive(BluetoothSettingsLocator.BluetoothSettingsSwitchChkBoxId);
            string searchingStatus = string.Empty;
            try
            {
                if (turnON)
                {
                    if (status)
                    {
                        if (IsElementPresent(BluetoothSearchDevices))
                        {
                            searchingStatus = BluetoothSearchDevices.Text;
                        };
                        Logger.Info("Bluetooth switch status already TURNED ON");
                    }
                    else
                    {
                        WaitElementToBeClickable(BluetoothSettingsSwitch);
                        ClickElement(BluetoothSettingsSwitch);
                        Logger.Info("Bluetooth switch status TURNED ON");
                        if (IsElementPresent(BluetoothSearchDevices))
                        {
                            searchingStatus = BluetoothSearchDevices.Text;
                        };
                    }
                }
                else
                {
                    if (!status)
                    {
                        Logger.Info("Bluetooth switch status already TURNED OFF");
                    }
                    else
                    {
                        WaitForElementDisappear(BluetoothSearchDevices, 20);
                        WaitElementToBeClickable(BluetoothSettingsSwitch);
                        ClickElement(BluetoothSettingsSwitch);
                        Logger.Info("Bluetooth switch status TURNED OFF");
                        if (IsElementPresent(KendoMsgWindow, 5))
                        {
                            searchingStatus = KendoMsgWindowTxt.Text;
                            ClickElement(KendoMsgOKBtn);
                        }
                        else
                        {
                            throw new Exception("Message for Bluetooth Disabled Not Visible");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Toggle Bluetooth settings to: " + turnON);
                throw;
            }

            return new BluetoothSettingsModel
            {
                BluetoothSettingsStatusTxtValue = searchingStatus,
                BluetoothStatus = IsCheckboxActive(BluetoothSettingsLocator.BluetoothSettingsSwitchChkBoxId)
            };
        }

        /// <summary>
        /// Method to click reset button on Bluetooth Settings
        /// </summary>
        /// <returns>Model with reset message and status of bluetooth after reset</returns>
        public BluetoothSettingsModel ClickReset()
        {
            string msg = null;
            string resetString = null;
            try
            {
                WaitForElementDisappear(BluetoothSearchDevices, 20);
                WaitElementToBeClickable(BluetoothResetButton);
                ClickElement(BluetoothResetButton);
                Logger.Info("Clicked Reset button on Bluetooth UI");
                //Click on Bluetooth settings
                if (IsElementPresent(BluetoothResetWindow))
                {
                    resetString = BluetoothResetWindowMsgTxt.Text;
                    ClickElement(BluetoothResetWindowResetBtn);
                    Logger.Info("Clicked Confirmation to Reset Bluetooth Settings");
                }
                if (IsElementPresent(KendoMsgWindow, 10))
                {
                    msg = KendoMsgWindow.Text;
                    ClickElement(KendoMsgOKBtn);
                    Logger.Info("Clicked OK button on KendoWindow.");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to click reset on Bluetooth Settings");
                throw;
            }
            return new BluetoothSettingsModel
            {
                BluetoothSettingsStatusTxtValue = msg,
                BluetoothSettingsResetTxtValue = resetString,
                BluetoothStatus = IsCheckboxActive(BluetoothSettingsLocator.BluetoothSettingsSwitchChkBoxId)
            };
        }

        #endregion Methods
    }
}