using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IXMWEBv2.Devices.RegisterDevice
{
    public class DiscoveredDevicesUI
    {
        public string DeviceName { get; set; }
        public string DeviceSerial { get; set; }
        public string DeviceMAC { get; set; }
        public bool IsAlreadyRegistered { get; set; }
        public string DeviceIpAddress { get; set; }
    }
    public class RegisteredDeviceSummaryUI
    {
        public DeviceInformationSummaryUI deviceInfo = new DeviceInformationSummaryUI();
        public NetworkInformationSummaryUI networkInfo = new NetworkInformationSummaryUI();

    }
    public class DeviceInformationSummaryUI
    {
        public string DeviceName { get; set; }
        public string ModelName { get; set; }
        public string SerialNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public string TransactionCapacity { get; set; }
        public string UserCapacity1N { get; set; }
        public string UserCapaicty11 { get; set; }

    }
    public class NetworkInformationSummaryUI
    {
        public string CommMode { get; set; }
        public string IPMode { get; set; }
        public string IP { get; set; }
        public string Subnet { get; set; }
        public string GateWay { get; set; }
        public string MacID { get; set; }
        public string DNS { get; set; }
    }
}
