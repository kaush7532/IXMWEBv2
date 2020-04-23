using IXMWEBv2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IXMWEBv2.Devices.Configurations.Communication.Bluetooth_Settings
{
    public class BluetoothSettings_AL
    {
        private BluetoothSettings_PO bluetoothpo;
        private Communication_PO commpo;

        public BluetoothSettings_AL()
        {
            bluetoothpo = new BluetoothSettings_PO();
            commpo = new Communication_PO();
            commpo.ShowBluetoothSettings(true);
            
        }

        /// <summary>
        /// Method to Enable and Disable Bluetooth
        /// </summary>
        /// <param name="turnON">true if ToggleBluetooth ON else False to ToggleBluetooth OFF</param>
        /// <returns>Model details</returns>
        public BluetoothSettingsModel EnableDisableBluetoothStatusUI(bool turnON)
        {
            BluetoothSettingsModel bsm = new BluetoothSettingsModel();
            try
            {
                commpo.ShowBluetoothSettings();

                var toggle = bluetoothpo.ToggleBluetoothStatusSwitch(turnON);

                bsm.BluetoothStatus = toggle.BluetoothStatus;
                bsm.BluetoothSettingsStatusTxtValue = toggle.BluetoothSettingsStatusTxtValue;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to make Bluetooth Settings: " + turnON);
                throw new Exception("Enable/disable Bluetooth Status FAILED");
            }
            return bsm;
        }

        public BluetoothSettingsModel ResetBluetoothStatusUI()
        {
            BluetoothSettingsModel bsm;
            try
            {
                commpo.ShowBluetoothSettings();
                bsm = bluetoothpo.ClickReset();
             
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Reset Bluetooth setting from UI");
                throw new Exception("FAILED to reset bluetooth settings from UI");
            }
            return bsm;
        }

    }
}
