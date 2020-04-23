using System;
using System.Threading;
using IXMWEBv2.Devices.Configurations.Communication.Bluetooth_Settings;
using IXMWEBv2.Devices.Configurations.Communication.DTMFSettings;
using IXMWEBv2.Devices.Configurations.Communication.USBAuxSettings;
using IXMWEBv2.Resources.Locators.Config.Communication;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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

        /// <summary>
        /// Method Expands Bluetooth settings section
        /// </summary>
        public void ShowBluetoothSettings(bool closeSettings=false)
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
                else if(!closeSettings)
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
        /// Method to get if body under communication is expanded or not
        /// </summary>
        /// <param name="idOfConfigBody">div tag having id of config body</param>
        /// <returns>true if expanded else false</returns>
        private bool IsConfigurationExpanded(string idOfConfigBody)
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