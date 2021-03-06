﻿using IXMSoft.Business.SDK;
using IXMSoft.Business.SDK.Commands;
using IXMSoft.Business.SDK.IXMException;
using IXMWEBv2.Utils;
using System;

namespace IXMWEBv2.Helper_SDK
{
    public class CommunicationSDK : DeviceInfo_SDK
    {
        private VOIPConfigurationManager dtmfVoip;        
        private CloudSettingsManager webCloud;
        private BluetoothManager bluetooth;
        private WebURLManager wum;        

        public CommunicationSDK()
        {
            dtmfVoip = new VOIPConfigurationManager(nc);
            ncm = new NetworkConfigurationManager(nc);
            webCloud = new CloudSettingsManager(nc);
            bluetooth = new BluetoothManager(nc);
            wum = new WebURLManager(nc);
            //ncm = new NetworkConfigurationManager(nc);
        }

        #region IXMWEB ServerURL Methods

        public string GetIXMWEBServerURL()
        {
            return wum.RetrieveWEBUrl();
        }

        public void SetIXMWEBServerULR(string urlValue)
        {
            wum.SaveWebUrl(urlValue);
        }

        public void ResetIXMWEBServerURL()
        {
            wum.RestoreWebUrl();
        }

        #endregion IXMWEB ServerURL Methods

        #region DTMF Methods

        /// <summary>
        /// Get DTMF settings
        /// </summary>
        /// <returns>DTMF settings as IDTMF</returns>
        public IDTMF GetDTMFSettings()
        {
            IDTMF d;
            try
            {
                d = dtmfVoip.RetrieveDTMFSettings();
                Logger.Info("CommunicationSDK: DTMF settings get SUCCESS");
            }
            catch (IXMSDKException ex)
            {
                Logger.Error(ex, "IXMSDKException: Failed to get DTMF settings");
                throw;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SDK: Failed to get DTMF settings");
                throw;
            }
            return d;
        }

        /// <summary>
        /// Reset DTMF Settings
        /// </summary>
        /// <returns>true if reset success else false</returns>
        public bool ResetDTMFSettings()
        {
            bool result = false;
            try
            {
                result = dtmfVoip.RestoreDTMFSettings();
                if (result)
                {
                    Logger.Info("CommunicationSDK: DTMF settings reset SUCCESS");
                }
            }
            catch (IXMSDKException e)
            {
                Logger.Error(e, "IXMSDKException: Failed to restore DTMF Settings");
                throw;
            }
            catch (Exception e)
            {
                Logger.Error(e, "SDK: Failed to restore DTMF Settings");
                throw;
            }
            return result;
        }

        /// <summary>
        /// Set DTMF Settings
        /// </summary>
        /// <param name="dtmfSettings">IDTMF parameter</param>
        public void SetDTMFSettings(IDTMF dtmfSettings)
        {
            try
            {
                dtmfVoip.StoreDTMFSettings(dtmfSettings);
            }
            catch (IXMSDKException e)
            {
                Logger.Error(e, "IXMSDKException: Failed to Set DTMF Settings");
                throw;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SDK: Failed to Set DTMF Settings");
                throw;
            }
        }

        #endregion DTMF Methods

        #region Bluetooth Methods

        /// <summary>
        /// Retrieve BluetoothStatus
        /// </summary>
        /// <returns></returns>
        public bool GetBluetoothStatus()
        {
            var result = bluetooth.RetrieveBluetoothStatus();
            Logger.Info("SDK: Retrieved Bluetooth Status with result " + result, "SDK");
            return result;
        }

        /// <summary>
        /// Method to Reset Bluetooth Status
        /// </summary>
        /// <returns>True if success else false</returns>
        public bool ResetBluetoothStatus()
        {
            var result = bluetooth.RestoreBluetoothStatus();
            Logger.Info("SDK: Restored Bluetooth Status with result " + result, "SDK");
            return result;
        }

        /// <summary>
        /// Method to Enable/Disable bluetooth
        /// </summary>
        /// <param name="turnON">Pass true if want to enable bluetooth
        /// Pass FALSE if want to disable bluetooth</param>
        public void EnableDisableBluetoothStatus(bool turnON)
        {
            var currentstatus = GetBluetoothStatus();
            if (turnON)
            {
                if (!currentstatus)
                {
                    bluetooth.EnableDisableBluetoothStatus(turnON);
                    Logger.Info("SDK: Changed Bluetooth Status to " + turnON, "SDK");
                }
                else
                {
                    Logger.Info("SDK: Bluetooth Already ON", "SDK");
                }
            }
            else
            {
                if (!currentstatus)
                {
                    Logger.Info("SDK: Bluetooth Already OFF", "SDK");
                }
                else
                {
                    bluetooth.EnableDisableBluetoothStatus(turnON);
                    Logger.Info("SDK: Changed Bluetooth Status to " + turnON, "SDK");
                }
            }
            Logger.Info("After Changing Bluetooth Status: " + GetBluetoothStatus());
        }

        #endregion Bluetooth Methods

        #region USB Aux Port Methods

        /// <summary>
        /// Get USB Aux Port settings
        /// </summary>
        /// <returns>USB Aux Port settings as bool</returns>
        public bool GetUSBAuxPortSettings()
        {
            try
            {
                return ncm.RetrieveUsbAuxSetting();
            }
            catch (IXMSDKException ex)
            {
                Logger.Error(ex, "IXMSDKException: Failed to get USB Aux Port settings");
                throw;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SDK: Failed to get USB Aux Port settings");
                throw;
            }
        }

        /// <summary>
        /// Reset USB Aux Port Settings
        /// </summary>
        /// <returns>true if reset success else false</returns>
        public bool ResetUSBAuxPortSettings()
        {
            bool result = false;
            try
            {
                result = ncm.RestoreUsbAuxSettings();
                if (result)
                {
                    Logger.Info("CommunicationSDK: USB Aux Port settings reset SUCCESS");
                }
            }
            catch (IXMSDKException e)
            {
                Logger.Error(e, "IXMSDKException: Failed to restore USB Aux Port Settings");
                throw;
            }
            catch (Exception e)
            {
                Logger.Error(e, "SDK: Failed to restore USB Aux Port Settings");
                throw;
            }
            return result;
        }

        /// <summary>
        /// Set USB Aux Port Settings
        /// </summary>
        /// <param name="status">USB Aux Port parameter</param>
        public void SetUSBAuxPortSettings(bool status)
        {
            try
            {
                ncm.StoreUsbAuxSetting(status);
            }
            catch (IXMSDKException e)
            {
                Logger.Error(e, "IXMSDKException: Failed to Set USB Aux Port Settings");
                throw;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SDK: Failed to Set USB Aux Port Settings");
                throw;
            }
        }

        #endregion USB Aux Port Methods

        #region VOIP Methods

        /// <summary>
        /// Get VOIP settings
        /// </summary>
        /// <returns>VOIP settings as IVOIPSetting</returns>
        public IVOIPSetting GetVOIPSettings()
        {
            IVOIPSetting v;
            try
            {
                v = dtmfVoip.RetrieveVoipSettings();
                Logger.Info("CommunicationSDK: VOIP settings get SUCCESS");
            }
            catch (IXMSDKException ex)
            {
                Logger.Error(ex, "IXMSDKException: Failed to get VOIP settings");
                throw;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SDK: Failed to get VOIP settings");
                throw;
            }
            return v;
        }

        /// <summary>
        /// Reset VOIP Settings
        /// </summary>
        /// <returns>true if reset success else false</returns>
        public bool ResetVOIPSettings()
        {
            bool result = false;
            try
            {
                result = dtmfVoip.RestoreVoipSettings();
                if (result)
                {
                    Logger.Info("CommunicationSDK: VOIP settings reset SUCCESS");
                }
            }
            catch (IXMSDKException e)
            {
                Logger.Error(e, "IXMSDKException: Failed to restore VOIP Settings");
                throw;
            }
            catch (Exception e)
            {
                Logger.Error(e, "SDK: Failed to restore VOIP Settings");
                throw;
            }
            return result;
        }

        /// <summary>
        /// Set VOIP Settings
        /// </summary>
        /// <param name="status">VOIP parameter</param>
        public void SetVOIPSettings(IVOIPSetting voipSettings)
        {
            try
            {
                dtmfVoip.StoreVoipSettings(voipSettings);
            }
            catch (IXMSDKException e)
            {
                Logger.Error(e, "IXMSDKException: Failed to Set VOIP Settings");
                throw;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SDK: Failed to Set VOIP Settings");
                throw;
            }
        }

        #endregion VOIP Methods

        #region WEBCloud Methods

        /// <summary>
        /// Get WEBCloud settings
        /// </summary>
        /// <returns>WEBCloud settings as ICloudSetting</returns>
        public ICloudSettings GetWEBCloudSettings()
        {
            ICloudSettings c;
            try
            {
                c = webCloud.RetrieveCloudSettings();
                Logger.Info("CommunicationSDK: WEBCloud settings get SUCCESS");
            }
            catch (IXMSDKException ex)
            {
                Logger.Error(ex, "IXMSDKException: Failed to get WEBCloud settings");
                throw;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SDK: Failed to get WEBCloud settings");
                throw;
            }
            return c;
        }

        /// <summary>
        /// Reset WEBCloud Settings
        /// </summary>
        /// <returns>true if reset success else false</returns>
        public bool ResetWEBCloudSettings()
        {
            bool result = false;
            try
            {
                result = webCloud.RestoreCloudSettings();
                if (result)
                {
                    Logger.Info("CommunicationSDK: WEBCloud settings reset SUCCESS");
                }
            }
            catch (IXMSDKException e)
            {
                Logger.Error(e, "IXMSDKException: Failed to restore WEBCloud Settings");
                throw;
            }
            catch (Exception e)
            {
                Logger.Error(e, "SDK: Failed to restore WEBCloud Settings");
                throw;
            }
            return result;
        }

        /// <summary>
        /// Set WEBCloud Settings
        /// </summary>
        /// <param name="status">WEBCloud parameter</param>
        public void SetWEBCloudSettings(bool Status, string CUrl = null, int Port = 1255, bool SSlStatus = false, bool IsDefaultCert = false, string SelectedCert = null, string Password = null)
        {
            try
            {
                webCloud.StoredCloudSettings(Status, CUrl, Port, SSlStatus, IsDefaultCert, SelectedCert, Password);
            }
            catch (IXMSDKException e)
            {
                Logger.Error(e, "IXMSDKException: Failed to Set WEBCloud Settings");
                throw;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SDK: Failed to Set WEBCloud Settings");
                throw;
            }
        }

        #endregion WEBCloud Methods
    }
}