namespace IXMWEBv2.Devices.Configurations.Communication
{
    public class CommunicationModel
    {
    }

    public class DTMFConfigModel : CommunicationModel
    {
        public bool DTMFStatus { get; set; }
        public bool SendWiegandStatus { get; set; }
        public int DTMFCode { get; set; }
        public string DTMFSettingsStatusTxtValue { get; set; }
    }

    public class USBAuxPortConfigModel : CommunicationModel
    {
        public bool USBAuxPortStatus { get; set; }
        public string USBAuxPortSettingsStatusTxtValue { get; set; }
    }

    public class BluetoothSettingsModel : CommunicationModel
    {
        public bool BluetoothStatus { get; set; }
        public string BluetoothSettingsResetTxtValue { get; set; }
        public string BluetoothSettingsStatusTxtValue { get; set; }
    }

    public class WEBCloudConfigModel : CommunicationModel
    {
        public bool WEBCloudStatus { get; set; }
        public string WEBCloudSettingsUrlTxtValue { get; set; }
        public int WEBCloudPortValue { get; set; }
        public bool WEBCloudSSlStatus { get; set; }
        public bool WEBCloudIsDefaultCert { get; set; }
        public string WEBCloudSelectedCertValue { get; set; }
        public string WEBCloudPasswordTxtValue { get; set; }
        public string WEBCloudSettingsStatusTxtValue { get; set; }
    }

    public class IXMWEBServerURLModel : CommunicationModel
    {
        public string IXMWEBServerURLTxtValue { get; set; }
        public string IXMWEBServerStatusTxtValue { get; set; }
        public string IXMWEBServerPopupTitleValue { get; set; }
    }
}