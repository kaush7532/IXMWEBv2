﻿using IXMWEBv2.Devices.Configurations.Communication.Bluetooth_Settings;
using IXMWEBv2.Devices.Configurations.Communication.DTMFSettings;
using IXMWEBv2.Devices.Configurations.Communication.IXMWEB_Server_Settings;
using IXMWEBv2.Devices.Configurations.Communication.USBAuxSettings;
using IXMWEBv2.Devices.Configurations.Communication.WEBCloud_Settings;
using IXMWEBv2.Resources.Locators.Config.Communication;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace IXMWEBv2.Devices.Configurations.Communication
{
    public class Communication_PO : GenericBasePage
    {
        public Communication_PO()
        {
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = CommunicationTabLocators.CommunicationTab)]
        private IWebElement Communicationtab { get; set; }

        [FindsBy(How = How.XPath, Using = CommunicationTabLocators.DTMFSettingsConfig)]
        private IWebElement DTMFSettingExpand { get; set; }

        [FindsBy(How = How.XPath, Using = CommunicationTabLocators.USBAuxPortSettingsConfig)]
        private IWebElement USBAuxPortSettingsConfig { get; set; }

        [FindsBy(How = How.XPath, Using = CommunicationTabLocators.BluetoothSettingsConfig)]
        private IWebElement BluetoothSettingsConfigExpand { get; set; }

        [FindsBy(How = How.XPath, Using = CommunicationTabLocators.IXMWEBServerSettingsConfig)]
        private IWebElement IXMWEBServerSettingsConfigExpand { get; set; }

        [FindsBy(How = How.XPath, Using = CommunicationTabLocators.WEBCloudSetttingsConfig)]
        private IWebElement WEBCloudSetttingsConfig { get; set; }

        /// <summary>
        /// Method Expands Bluetooth settings section
        /// </summary>
        public void ShowBluetoothSettings(bool closeSettings = false)
        {
            try
            {
                Thread.Sleep(500);
                WaitForElementPresent(BluetoothSettingsConfigExpand);
                //wait for Bluetooth setting to expand
                if (IsConfigurationExpanded(BluetoothSettingsLocator.BluetoothBodySection))
                {
                    Logger.Info("Bluetooth settings is already expanded");
                    if (closeSettings)
                    {
                        ClickElement(BluetoothSettingsConfigExpand);
                        Logger.Info("Closing BluetoothSettings.");
                    }
                }
                else if (!closeSettings)
                {
                    ClickElement(BluetoothSettingsConfigExpand);
                    Logger.Info("Expanded BluetoothSettings.");
                }
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Expand Bluetooth settings FAILED");
                throw new Exception("Expand Blueooth settings FAILED");
            }
        }

        /// <summary>
        /// Method Expands IXMWEB Server settings section
        /// </summary>
        public void ShowIXMWEBServerSettings(bool closeSettings = false)
        {
            try
            {
                Thread.Sleep(500);
                WaitForElementPresent(IXMWEBServerSettingsConfigExpand);
                //wait for IXMWEB Server setting to expand
                if (IsConfigurationExpanded(IXMWEBServerLocator.IXMWEBServerBodySection))
                {
                    Logger.Info("IXMWEB Server settings is already expanded");
                    if (closeSettings)
                    {
                        ClickElement(IXMWEBServerSettingsConfigExpand);
                        Logger.Info("Closing IXMWEB Server Settings.");
                    }
                }
                else if (!closeSettings)
                {
                    ClickElement(IXMWEBServerSettingsConfigExpand);
                    Logger.Info("Expanded IXMWEB Server Settings.");
                }
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Expand IXMWEB Server settings FAILED");
                throw new Exception("Expand IXMWEB Server settings FAILED");
            }
        }

        /// <summary>
        /// Method Expands DTMF settings section
        /// </summary>
        public void ShowDTMFSettings()
        {
            try
            {
                WaitForElementPresent(DTMFSettingExpand);
                //wait for DTMF setting to expand
                if (IsConfigurationExpanded(DTMFLocators.DTMFBodySection))
                {
                    Logger.Info("DTMF settings is already expanded");
                }
                else
                {
                    ClickElement(DTMFSettingExpand);
                    Logger.Info("Expanded DTMFSettings.");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Expand DTMF settings FAILED");
                throw;
            }
        }

        /// <summary>
        /// Method Expands USB Auxiliary Port settings section
        /// </summary>
        public void ShowUSBAuxPortSettings()
        {
            try
            {
                WaitForElementPresent(USBAuxPortSettingsConfig);
                //wait for USB Aux Port Settings setting to expand
                if (IsConfigurationExpanded(USBAuxPortLocator.USBAuxPortBodySection))
                {
                    Logger.Info("USB Aux Port settings is already expanded");
                }
                else
                {
                    ClickElement(USBAuxPortSettingsConfig);
                    Logger.Info("Expanded USB Aux Port Settings");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Expand of USB Aux Port Settings settings FAILED");
                throw;
            }
        }

        /// <summary>
        /// Method Expands WEBCloud settings section
        /// </summary>
        public void ShowWEBCloudSettings()
        {
            try
            {
                WaitForElementPresent(WEBCloudSetttingsConfig);
                //wait for WEBCloud setting to expand
                if (IsConfigurationExpanded(WEBCloudLocators.WEBCloudBodySection))
                {
                    Logger.Info("WEBCloud settings is already expanded");
                }
                else
                {
                    ClickElement(WEBCloudSetttingsConfig);
                    Logger.Info("Expanded WEBCloud Settings");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Expand of WEBCloud settings FAILED");
                throw;
            }
        }

        /// <summary>
        /// Method to get if body under communication is expanded or not
        /// </summary>
        /// <param name="idOfConfigBody">div tag having id of config body</param>
        /// <returns>true if expanded else false</returns>
        public bool IsConfigurationExpanded(string idOfConfigBody)
        {
            bool result = false;
            var eles = _driver.FindElements(By.XPath(CommunicationTabLocators.ExpandedConfig));

            foreach (var item in eles)
            {
                if (item.GetAttribute("id").Equals(idOfConfigBody))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}