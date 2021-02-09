using System;
using IXMSoft.Business.SDK;
using IXMSoft.Business.SDK.Data;
using IXMWEBv2.Utils;

namespace IXMWEBv2.Helper_SDK.Device
{
    public class Device_SDK : DeviceInfo_SDK
    {
        public Device_SDK()
        {
        }

        #region Set Device methods

        /// <summary>
        /// Set SSL Mode enabled
        /// </summary>
        public void EnableSSLMode()
        {
            try
            {
                ncm.EnableSslAuthentication(true, "default.pfx", "", true);
                Logger.Info("SDK: SSL enabled successfully for device");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SDK: Failed to enable SSL mode");
                throw;
            }
        }

        protected void ChangeDeviceMode(bool identify, bool verify)
        {
            BiometricConfigurationManager bcm = new BiometricConfigurationManager(nc);
            UserRecordManager urm = new UserRecordManager(nc);

            var retrivedbcm = bcm.RetrieveBiometricConfiguration();
            if (identify && retrivedbcm.DeviceMode == DeviceMode.Verify)
            {
                retrivedbcm.DeviceMode = DeviceMode.Identify;
                bcm.StoreBiometricConfiguration(retrivedbcm);
            }
            else if (verify && retrivedbcm.DeviceMode == DeviceMode.Identify)
            {
                retrivedbcm.DeviceMode = DeviceMode.Verify;
                bcm.StoreBiometricConfiguration(retrivedbcm);
            }
        }

        public void ChangeDevicePort(string portValue)
        {
            try
            {
                var ethernetworksettings = ncm.RetrieveEthernetNetworkSettings();
                Logger.Info("SDK: Port value before changing is: " + ethernetworksettings.Port);
                ethernetworksettings.Port = Convert.ToUInt16(portValue);
                ncm.StoreEthernetNetworkSettings(ethernetworksettings);
                Logger.Info("SDK: Changed Port of device successfully");
                base.Initialize(ethernetworksettings.IPAddress.ToString(), ethernetworksettings.Port.ToString(), DeviceConnectionType.Ethernet);
                Logger.Info("SDK: Port value after changing is: " + portValue);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "SDK: Failed to change device port to : " + portValue);
                throw;
            }
        }

        #endregion Set Device methods
    }
}