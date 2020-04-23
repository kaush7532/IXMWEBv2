using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IXMWEBv2.Devices.Configurations.Communication.Bluetooth_Settings
{
    public class BluetoothSettingsLocator
    {
        #region Bluetooth Settings Locators
        public const string BluetoothDiv = "Bluetooth";
        public const string BluetoothBodySection = "bluetoothCommBody";

        public const string BluetoothSettingsSwitchChkBox = "btnBluetoothCommHideShow";

        public const string BluetoothSettingsSwitchChkBoxId = "bluetoothenableDisable";

        public const string BluetoothSettingsResetBtn = ".//*[@id='" + BluetoothBodySection + "']//a[contains(.,'Reset')]";
        public const string BluetoothSettingsRefreshBtn = ".//*[@id='" + BluetoothBodySection + "']//a[contains(.,'Refresh')]";
        public const string BluetoothSearchProgressBar = "progressBarForBluetooth";
        public const string BluetoothResetWindow = "ResetBluetoothStatusWindow";
        public const string BluetoothResetWindowMsg = ".//*[@id='" + BluetoothResetWindow + "']//p";
        public const string BluetoothResetWindowResetBtn = ".//*[@id='" + BluetoothResetWindow + "']//a[@title='Reset']";
        public const string BluetoothResetWindowCancelBtn = ".//*[@id='" + BluetoothResetWindow + "']//a[@title='Cancel']";


        #endregion
    }
}
