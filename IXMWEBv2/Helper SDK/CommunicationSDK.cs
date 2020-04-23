using System;
using IXMSoft.Business.SDK;
using IXMSoft.Business.SDK.Commands;
using IXMSoft.Business.SDK.IXMException;
using IXMWEBv2.Constants;
using IXMWEBv2.Utils;

namespace IXMWEBv2.Helper_SDK
{
    public class CommunicationSDK : DeviceInfo_SDK
    {
        private VOIPConfigurationManager dtmfVoip;
        private BluetoothManager bluetooth;
        //private NetworkConfigurationManager ncm;

        public CommunicationSDK()
        {
            dtmfVoip = new VOIPConfigurationManager(nc);
            bluetooth = new BluetoothManager(nc);
            //ncm = new NetworkConfigurationManager(nc);
        }

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

        #endregion

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
    }
}