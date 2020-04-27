using IXMWEBv2.Constants;
using IXMWEBv2.Utils;
using System;
using System.Threading;

namespace IXMWEBv2.Devices.Configurations.Communication.USBAuxSettings
{
    public class USBAuxPortSettings_AL
    {
        private USBAuxPortSettings_PO usbportpo;
        private Communication_PO commpo;
        private IXMWebUtils ixmwebutils;
        private USBAuxPortConfigModel usbportsettings;

        public USBAuxPortSettings_AL()
        {
            commpo = new Communication_PO();
            usbportpo = new USBAuxPortSettings_PO();
            ixmwebutils = new IXMWebUtils();
            usbportsettings = new USBAuxPortConfigModel();
        }

        /// <summary>
        /// Expands USB Aux Port Setting
        /// </summary>
        public void ExpandUSBAuxPortSetting()
        {
            try
            {
                //Expand USB Aux Port Settings
                commpo.ShowUSBAuxPortSettings();
                Logger.Info("Able to expand USB Aux Setting: PASSED in USBAuxPortSetting_AL", Module.USBAuxPortModule);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to expand USB Aux Setting: FAILED in USBAuxPortSetting_AL");
                throw;
            }
        }

        /// <summary>
        /// Validates UI
        /// </summary>
        /// <returns>returns true if all the elements are visible else returns false</returns>
        public bool ValidateUSBAuxPortSettingUI()
        {
            try
            {
                //Expand USB Aux Port Settings
                commpo.ShowUSBAuxPortSettings();
                Logger.Info("Able to expand USB Aux Setting: PASSED in USBAuxPortSetting_AL", Module.USBAuxPortModule);

                return usbportpo.PageElementsAreVisible();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to verify UI elements: FAILED in USBAuxPortSetting_AL");
                throw;
            }
        }

        /// <summary>
        ///  Method to enable or disable USB Aux Port settings
        /// </summary>
        /// <param name="status">USB Aux Port setting status</param>
        /// <returns>USB Aux Port settings from UI</returns>
        public USBAuxPortConfigModel EnableDisbaleUSBAuxPort(bool status = false)
        {
            try
            {
                //Expand USB Aux Port Settings
                commpo.ShowUSBAuxPortSettings();
                Logger.Info("Able to expand USB Aux Setting", Module.USBAuxPortModule);

                Thread.Sleep(1000);

                //set status
                usbportsettings.USBAuxPortStatus = usbportpo.SetUSBAuxPortStatus(status);

                //click on apply button
                usbportpo.ClickUSBAuxPortApplyBtn();

                Thread.Sleep(1000);

                usbportsettings.USBAuxPortSettingsStatusTxtValue = ixmwebutils.ReturnKendoTextValue();

                Logger.Info("Able to Enable or Disable USB Aux Port settings: PASSED in USBAuxPortSetting_AL");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to Enable or Disable  USB Aux Port settings: FAILED in USBAuxPortSetting_AL");
                throw;
            }

            return usbportsettings;
        }

        /// <summary>
        /// Method to reset USB Aux Port settings
        /// </summary>
        /// <returns>USB Aux Port settings from UI</returns>
        public USBAuxPortConfigModel ResetUSBAuxPortSetting()
        {
            try
            {
                //Expand USB Aux Port Settings
                commpo.ShowUSBAuxPortSettings();
                Logger.Info("Able to expand USB Aux Setting", Module.USBAuxPortModule);

                //click on reset button
                usbportpo.ClickUSBAuxPortResetBtn();

                usbportsettings.USBAuxPortSettingsStatusTxtValue = ixmwebutils.ReturnKendoTextValue();

                //get USB Aux port setting status from UI
                usbportsettings.USBAuxPortStatus = usbportpo.GetStatusOFUSBAuxFromUI();

                Logger.Info("Able to Reset USB Aux Port settings: PASSED in USBAuxPortSetting_AL");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to Reset  USB Aux Port settings: FAILED in USBAuxPortSetting_AL");
                throw;
            }

            return usbportsettings;
        }
    }
}