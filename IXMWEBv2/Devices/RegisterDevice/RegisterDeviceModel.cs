using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IXMWEBv2.Devices.RegisterDevice
{
    public class RegisterDeviceModel
    {
    }
    public class DiscoveredDevicesUI
    {
        public string DeviceName { get; set; }
        public string DeviceSerial { get; set; }
        public string DeviceMAC { get; set; }
        public bool IsAlreadyRegistered { get; set; }
        public string DeviceIpAddress { get; set; }
    }
}
