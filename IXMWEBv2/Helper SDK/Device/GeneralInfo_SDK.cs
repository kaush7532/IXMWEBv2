using IXMSoft.Business.SDK.Commands;
using IXMSoft.Business.SDK.Data;
using IXMWEBv2.Utils;
using System;

namespace IXMWEBv2.Helper_SDK.Device
{
    public class GeneralInfo_SDK : DeviceInfo_SDK
    {
        public IDeviceInfo deviceInfo;

        //public GeneralInfo_SDK(string ipAddress, string port, DeviceConnectionType connectionType) : base(ipAddress, port, connectionType)
        //{
        //    deviceInfo = dim.GetDeviceInfoByIP();
        //}

        public GeneralInfo_SDK(string ipAddress, string port, DeviceConnectionType connectionType) : base()
        {
            deviceInfo = dim.GetDeviceInfoByIP();
        }  

        /// <summary>
        /// Get generalinfo of device
        /// </summary>
        /// <returns>IDeviceInfo having general info values</returns>
        public IDeviceInfo GetDeviceGeneralInfo()
        {
            try
            {
                Logger.Info("SDK: Getting device general info by ip");
                return dim.GetDeviceInfoByIP();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to get device information by IP");
                throw;
            }
        }
    }
}
