using IXMWEBv2.Constants;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace IXMWEBv2.Devices.Configurations.Communication.USBAuxSettings
{
    public class USBAuxPortSettings_PO : GenericBasePage
    {
        public USBAuxPortSettings_PO()
        {
            PageFactory.InitElements(_driver, this);
        }

        #region Declaration: USB Aux Port Section

        [FindsBy(How = How.XPath, Using = USBAuxPortLocator.USBAuxPortStatus)]
        private IWebElement uSBAuxPortStatus { get; set; }

        [FindsBy(How = How.Id, Using = USBAuxPortLocator.USBAuxPortStatusId)]
        private IWebElement uSBAuxPortStatusId { get; set; }

        [FindsBy(How = How.XPath, Using = USBAuxPortLocator.USBAuxPortApplyBtn)]
        private IWebElement uSBAuxPortApplyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = USBAuxPortLocator.USBAuxPortResetBtn)]
        private IWebElement uSBAuxPortResetBtn { get; set; }

        [FindsBy(How = How.XPath, Using = USBAuxPortLocator.USBAuxPortMsgBoxResetBtn)]
        private IWebElement uSBAuxPortMsgBoxResetBtn { get; set; }

        #endregion Declaration: USB Aux Port Section

        public bool PageElementsAreVisible()
        {
            if (IsElementPresent(uSBAuxPortStatus) &&
                IsElementPresent(uSBAuxPortApplyBtn) &&
                IsElementPresent(uSBAuxPortResetBtn)
                )
                return true;
            return false;
        }

        /// <summary>
        /// Method to set USB Aux Port status
        /// </summary>
        /// <param name="turnON">true to TURNON; false to TURNOFF</param>
        /// <returns>true if ON; false if OFF</returns>
        public bool SetUSBAuxPortStatus(bool turnON)
        {
            bool status = IsCheckboxActive(USBAuxPortLocator.USBAuxPortStatusId);
            try
            {
                if (turnON)
                {
                    if (status)
                    {
                        Logger.Info("USB Aux Port: status already TURNED ON");
                    }
                    else
                    {
                        WaitElementToBeClickable(uSBAuxPortStatus);
                        ClickElement(uSBAuxPortStatus);
                        Logger.Info("USB Aux Port: switch status TURNED ON");
                    }
                }
                else
                {
                    if (!status)
                    {
                        Logger.Info("USB Aux Port: switch status already TURNED OFF");
                    }
                    else
                    {
                        WaitElementToBeClickable(uSBAuxPortStatus);
                        ClickElement(uSBAuxPortStatus);
                        Logger.Info("USB Aux Port: switch status TURNED OFF");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Set status for USB Aux Port to: " + status);
                throw;
            }

            return IsCheckboxActive(USBAuxPortLocator.USBAuxPortStatusId);
        }

        /// <summary>
        /// Method to click apply button
        /// </summary>
        public void ClickUSBAuxPortApplyBtn()
        {
            try
            {
                WaitElementToBeClickable(uSBAuxPortApplyBtn);
                ClickElement(uSBAuxPortApplyBtn);
                Logger.Info("Able to click on Apply button", Module.USBAuxPortModule);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to click on Apply button");
                throw;
            }
        }

        /// <summary>
        /// Method to click reset button
        /// </summary>
        public void ClickUSBAuxPortResetBtn()
        {
            try
            {
                WaitElementToBeClickable(uSBAuxPortResetBtn);
                ClickElement(uSBAuxPortResetBtn);
                WaitElementToBeClickable(uSBAuxPortMsgBoxResetBtn);
                ClickElement(uSBAuxPortMsgBoxResetBtn);
                Logger.Info("Able to click on Reset button", Module.USBAuxPortModule);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to click on Reset button");
                throw;
            }
        }

        /// <summary>
        /// Method to get USB Aux Port status
        /// </summary>
        /// <returns>true if ON; false if OFF</returns>
        public bool GetStatusOFUSBAuxFromUI()
        {
            return IsCheckboxActive(USBAuxPortLocator.USBAuxPortStatusId);
        }
    }
}