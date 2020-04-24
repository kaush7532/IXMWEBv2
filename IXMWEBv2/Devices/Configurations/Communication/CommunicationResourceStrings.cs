using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IXMWEBv2.Devices.Configurations.Communication
{
    public class CommunicationResourceStrings
    {
        #region DTMF: Text verification Resources Strings
        public const string DTMFTitleTxtConstantResourse = "DTMF Settings";
        public const string DTMFCodeTxtConstantResourse = "Code";
        public const string DTMFEventTxtConstantResourse = "DTMF Event";
        public const string DTMFSendWiegandTxtConstantResourse = "Send Wiegand";
        public const string DTMFDoorOpenTxtConstantResourse = "Door Open";
        public const string DTMFInvalidCodeValue = "Enter Code between 0 to 99";
        #endregion

        #region USB Aux: Resource Strings
        public const string USBAuxRestoredMsg = "USB Aux settings restored";
        public const string USBAuxStoreMsg = "USB Aux settings saved";
        #endregion

        #region Bluetooth: Resource Strings
        public const string BluetoothSearchMsg = "Searching for Devices";
        public const string BluetoothDisabledMsg = "Connection disabled";
        public const string BluetoothRestoredMsg = "This will permanently reset Bluetooth status";
        public const string BluetoothRestoredStatusMsg = "Status restored";
        #endregion

        #region IXMWEB Server: Resource Strings
        public const string IXMWEBServerPopUpTitle = "IXM WEB Server";
        public const string IXMWEBServerURLSetMsg = "Server URL saved";
        public const string IXMWEBServerInvalidURLSetMsg = "Invalid URL";
        public const string IXMWEBServerBlankURLSetMsg = "Valid IXM WEB Server URL is required";
        #endregion
    }
}
