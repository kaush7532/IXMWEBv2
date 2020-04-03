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
}