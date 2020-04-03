using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IXMWEBv2.Devices.DeviceOperations
{
    class DeviceOperationsModel
    {
    }
    public class DeviceListModel
    {
        public string DeviceName { get; set; }
        public string DeviceSerial { get; set; }
        public string DeviceIp { get; set; }
        public string ProductType { get; set; }
    }
    public class SearchedDevices : DeviceListModel
    {

    }    
}
