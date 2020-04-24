using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IXMWEBv2.Constants;
using IXMWEBv2.Utils;

namespace IXMWEBv2.Devices.Configurations.Communication.WEBCloud_Settings
{
    public class WEBCloudSettings_AL
    {
        private WEBCloudSettings_PO webcloudpo;
        private Communication_PO commpo;
        private IXMWebUtils ixmwebutils;
        private WEBCloudConfigModel webcloudsettings;

        public WEBCloudSettings_AL()
        {
            commpo = new Communication_PO();
            webcloudpo = new WEBCloudSettings_PO();
            ixmwebutils = new IXMWebUtils();
            webcloudsettings = new WEBCloudConfigModel();
        }

        /// <summary>
        /// Expands WEBCloud Setting
        /// </summary>
        public void ExpandWEBCloudSetting()
        {
            try
            {
                //Expand WEBCloud Settings
                commpo.ShowWEBCloudSettings();
                Logger.Info("Able to expand WEBCloud Setting: PASSED in WEBCloudSettings_AL", Module.WEBCloudModule);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to expand WEBCloud Setting: FAILED in WEBCloudSettings_AL");
                throw;
            }
        }

        /// <summary>
        /// Validates UI
        /// </summary>
        /// <returns>returns true if all the elements are visible else returns false</returns>
        public bool ValidateWEBCloudSettingUI()
        {
            try
            {
                //Expand WEBCloud Settings
                commpo.ShowWEBCloudSettings();
                Logger.Info("Able to expand WEBCloud Setting: PASSED in WEBCloudSettings_AL", Module.WEBCloudModule);

                return webcloudpo.PageElementsAreVisible();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to verify UI elements: FAILED in WEBCloudSettings_AL");
                throw;
            }
        }

        /// <summary>
        /// Set web cloud settings from UI
        /// </summary>
        /// <param name="status">WEB cloud status</param>
        /// <param name="cloudurl">WEB cloud URL</param>
        /// <param name="cloudport">WEB cloud port</param>
        /// <returns></returns>
        public WEBCloudConfigModel SetWEBCloudSettings(bool status = false, string cloudurl = null, string cloudport = null)
        {
            WEBCloudConfigModel webcloudSettings = new WEBCloudConfigModel();
            try
            {
                //Expand WEBCloud Settings
                commpo.ShowWEBCloudSettings();

                //set status
                webcloudSettings.WEBCloudStatus = webcloudpo.ToggleWEBCloudStatusSwitch(status);

                //Set DtmfCode
                webcloudSettings.WEBCloudSettingsUrlTxtValue = webcloudpo.EnterWEBCloudURL(cloudurl);

                //set Wiegandstatus
                webcloudSettings.WEBCloudPortValue = webcloudpo.SetWEBCloudPort(cloudport) ;

                //click on apply button
                webcloudSettings.WEBCloudSettingsStatusTxtValue = webcloudpo.ClickApply();

                Logger.Info("Set WEBCloud settings successfully");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Set WEBCloud settings");
                throw;
            }
            return webcloudSettings;
        }


        /// <summary>
        /// Reset web cloud settings from UI
        /// </summary>
        /// <returns>Webcloud settings</returns>
        public WEBCloudConfigModel ResetWEBCloudSettings()
        {
            WEBCloudConfigModel webcloudSettings = new WEBCloudConfigModel();
            try
            {
                //Expand WEBCloud Settings
                commpo.ShowWEBCloudSettings();

                //Click Reset
                webcloudSettings.WEBCloudSettingsStatusTxtValue = webcloudpo.ClickReset();
                Logger.Info("Reset WEBCloud setting" + webcloudSettings.WEBCloudStatus + webcloudSettings.WEBCloudSettingsUrlTxtValue + webcloudSettings.WEBCloudPortValue);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Reset WEBCloud settings");
                throw;
            }
            return webcloudSettings;
        }

        /// <summary>
        /// Gets WEBCloud settings from UI
        /// </summary>
        /// <returns>WEB cloud settings obj</returns>
        public WEBCloudConfigModel GetWEBCloudSettingUI()
        {
            WEBCloudConfigModel webcloudSettings = new WEBCloudConfigModel();
            try
            {
                webcloudSettings = webcloudpo.GetWEBCloudSettingsUI();
                Logger.Info("WEBCloud settings retrieved from UI");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "failed to retrive status");
            }
            return webcloudSettings;
        }
    }
}
