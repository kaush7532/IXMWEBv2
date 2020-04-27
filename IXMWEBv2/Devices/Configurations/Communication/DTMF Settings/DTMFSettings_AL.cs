using IXMWEBv2.Utils;
using System;

namespace IXMWEBv2.Devices.Configurations.Communication.DTMFSettings
{
    public class DTMFSettings_AL
    {
        private DTMFSettings_PO dtmfpo;
        private Communication_PO commpo;

        public DTMFSettings_AL()
        {
            commpo = new Communication_PO();
            dtmfpo = new DTMFSettings_PO();
        }

        public DTMFConfigModel GetDTMFSettingUI()
        {
            DTMFConfigModel dtmfSettings = new DTMFConfigModel();
            try
            {
                dtmfSettings = dtmfpo.GetDTMFSettingsUI();
                Logger.Info("DTMF setting");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "failed to retrive status");
            }
            return dtmfSettings;
        }

        /// <summary>
        /// Method to Set DTMF Settings
        /// </summary>
        /// <param name="dtmfCode">dtmCode if other than 15</param>
        /// <param name="status">dtmf setting status</param>
        /// <param name="sendWiegandStatus">dtmf send wiegand status</param>
        /// <returns>DTMFSettings from UI</returns>
        public DTMFConfigModel SetDTMFSettings(string dtmfCode = null, bool status = false, bool sendWiegandStatus = false)
        {
            DTMFConfigModel dtmfSettings = new DTMFConfigModel();
            try
            {
                //Expand DTMF Settings
                commpo.ShowDTMFSettings();

                //set status
                dtmfSettings.DTMFStatus = dtmfpo.ToggleDTMFStatusSwitch(status);

                //Set DtmfCode
                dtmfSettings.DTMFCode = dtmfpo.SetDTMFCode(dtmfCode);

                //set Wiegandstatus
                dtmfSettings.SendWiegandStatus = dtmfpo.SetSendWeigandStatus(sendWiegandStatus);

                //click on apply button
                dtmfSettings.DTMFSettingsStatusTxtValue = dtmfpo.ClickApply();

                Logger.Info("Set DTMF settings successfully");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Set DTMF settings");
                throw;
            }
            return dtmfSettings;
        }

        public DTMFConfigModel ResetDTMFSettings()
        {
            DTMFConfigModel dtmfSettings = new DTMFConfigModel();
            try
            {
                //Expand DTMF setting
                commpo.ShowDTMFSettings();
                //Click Reset
                dtmfSettings.DTMFSettingsStatusTxtValue = dtmfpo.ClickReset();
                Logger.Info("Reset DTMF setting" + dtmfSettings.DTMFStatus + dtmfSettings.DTMFCode + dtmfSettings.SendWiegandStatus);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Reset DTMF settings");
                throw;
            }
            return dtmfSettings;
        }
    }
}