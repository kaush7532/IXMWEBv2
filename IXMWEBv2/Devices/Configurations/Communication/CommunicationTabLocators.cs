using IXMWEBv2.Devices.Configurations.Communication.Bluetooth_Settings;
using IXMWEBv2.Devices.Configurations.Communication.DTMFSettings;
using IXMWEBv2.Devices.Configurations.Communication.EthernetSettings;
using IXMWEBv2.Devices.Configurations.Communication.IXMWEB_Server_Settings;
using IXMWEBv2.Devices.Configurations.Communication.USBAuxSettings;
using IXMWEBv2.Devices.Configurations.Communication.WEBCloud_Settings;

namespace IXMWEBv2.Resources.Locators.Config.Communication
{
    public class CommunicationTabLocators
    {
        public const string CommunicationTab = "communication-tab";
        public const string communicationDiv = "communication";
        public const string ExpandedConfig = ".//*[@id='" + communicationDiv + "']//div[@class[contains(.,'hide-body-content')]]";

        public const string DTMFSettingsConfig = ".//*[@id='" + communicationDiv + "']//div[normalize-space(text())='" + DTMFLocators.DTMFDiv + "']";
        public const string USBAuxPortSettingsConfig = ".//*[@id='" + communicationDiv + "']//div[normalize-space(text())='" + USBAuxPortLocator.USBAuxPortDiv + "']";
        public const string EthernetSettingsConfig = ".//*[@id='" + communicationDiv + "']//div[normalize-space(text())='" + EthernetSettingsLocators.EthernetDiv + "']";
        public const string WEBCloudSetttingsConfig = ".//*[@id='" + communicationDiv + "']//div[normalize-space(text())='" + WEBCloudLocators.WEBCloudDiv + "']";
        public const string BluetoothSettingsConfig = ".//*[@id='" + communicationDiv + "']//div[normalize-space(text())='" + BluetoothSettingsLocator.BluetoothDiv + "']";
        public const string IXMWEBServerSettingsConfig = ".//*[@id='" + communicationDiv + "']//div[normalize-space(text())='" + IXMWEBServerLocator.IXMWEBServerDiv + "']";
    }
}