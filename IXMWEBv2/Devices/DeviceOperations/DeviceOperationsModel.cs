namespace IXMWEBv2.Devices.DeviceOperations
{
    internal class DeviceOperationsModel
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