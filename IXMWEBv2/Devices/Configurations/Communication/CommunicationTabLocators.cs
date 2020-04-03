using IXMWEBv2.Devices.Configurations.Communication.DTMFSettings;
using IXMWEBv2.Devices.Configurations.Communication.EthernetSettings;
using IXMWEBv2.Devices.Configurations.Communication.USBAuxSettings;

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
    }
}