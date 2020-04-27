using IXMWEBv2.AccessLayer.DeviceAccessLayers;
using IXMWEBv2.Constants;
using IXMWEBv2.Helper_SDK;
using IXMWEBv2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IXMWEBv2.Devices.Configurations.Communication.Bluetooth_Settings
{
    [TestClass]
    public class BluetoothSettings_TC : BaseTest
    {
        private DeviceOperations_AL deviceListAccessLayer;
        private BluetoothSettings_AL bluetoothSettingsAccessLayer;
        private CommunicationSDK bluetoothSDK;

        #region Initialization methods

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();

            loginAccessLayer.LoginIXMWeb();
            ixmUtils.GoToTab(MainTabs.Devices);

            //ToDo selection of device for applying settings

            deviceListAccessLayer = new DeviceOperations_AL(dbInteraction.onlineDeviceInfo);
            ixmUtils.GoToDeviceConfigurations(DeviceConfigurationTabs.Communication);

            bluetoothSettingsAccessLayer = new BluetoothSettings_AL();
            bluetoothSDK = new CommunicationSDK();
        }

        #endregion Initialization methods

        #region Test Methods

        #region Set bluetooth Test Case

        [TestMethod]
        [TestCategory(Module.BluetoothModule), TestCategory(Module.DeviceConfiguration), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void EnableBluetoothSettings()
        {
            try
            {
                //Reset bluetooth Settings Using SDK
                Assert.IsTrue(bluetoothSDK.ResetBluetoothStatus(), "SDK: Reset bluetooth settings failed");

                //Disable bluetooth settings from ui
                var uibluetooth = bluetoothSettingsAccessLayer.EnableDisableBluetoothStatusUI(true);

                //Get UI value and assert
                Assert.IsTrue(uibluetooth.BluetoothStatus, "Failed to Enable Bluetooth Settings");
                Assert.AreEqual(CommunicationResourceStrings.BluetoothSearchMsg, uibluetooth.BluetoothSettingsStatusTxtValue,
                    "Searching for Bluetooth devices message invalid");

                //Get using SDK and assert
                var sdkGetbluetooth = bluetoothSDK.GetBluetoothStatus();

                //Verify UI
                Assert.AreEqual(uibluetooth.BluetoothStatus, sdkGetbluetooth, "bluetooth status failed");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Enable bluetooth setting failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory(Module.BluetoothModule), TestCategory(Module.DeviceConfiguration), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void DisableBluetoothSettings()
        {
            try
            {
                //Enable bluetooth settings using SDK
                bluetoothSDK.EnableDisableBluetoothStatus(true);

                //Enable bluetooth settings from ui
                var uibluetooth = bluetoothSettingsAccessLayer.EnableDisableBluetoothStatusUI(false);

                //Get UI value and assert
                Assert.IsFalse(uibluetooth.BluetoothStatus, "Failed to Disable Bluetooth Settings");
                Assert.AreEqual(CommunicationResourceStrings.BluetoothDisabledMsg, uibluetooth.BluetoothSettingsStatusTxtValue,
                    "Bluetooth connection disabled message invalid");

                //Get using SDK and assert
                var sdkGetbluetooth = bluetoothSDK.GetBluetoothStatus();

                //Verify UI
                Assert.AreEqual(uibluetooth.BluetoothStatus, sdkGetbluetooth, "Bluetooth status failed");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Disable bluetooth setting failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory(Module.BluetoothModule), TestCategory(Module.DeviceConfiguration), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void ResetBluetoothSettings()
        {
            try
            {
                //Enable bluetooth settings using SDK
                bluetoothSDK.EnableDisableBluetoothStatus(true);

                //Reset bluetooth settings from ui
                var uibluetooth = bluetoothSettingsAccessLayer.ResetBluetoothStatusUI();

                //Get UI value and assert
                Assert.IsFalse(uibluetooth.BluetoothStatus, "Failed to Reset Bluetooth Settings");
                Assert.AreEqual(CommunicationResourceStrings.BluetoothRestoredMsg, uibluetooth.BluetoothSettingsResetTxtValue,
                    "Bluetooth connection reset message invalid");
                Assert.AreEqual(CommunicationResourceStrings.BluetoothRestoredStatusMsg, uibluetooth.BluetoothSettingsStatusTxtValue,
                    "Bluetooth connection reset message invalid");

                //Get using SDK and assert
                var sdkGetbluetooth = bluetoothSDK.GetBluetoothStatus();

                //Verify UI
                Assert.AreEqual(uibluetooth.BluetoothStatus, sdkGetbluetooth, "Bluetooth status failed");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Reset bluetooth setting failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        #endregion Set bluetooth Test Case

        #endregion Test Methods

        #region Test Cleanup procedure

        [TestCleanup]
        public void Cleanup()
        {
            base.TearDown();
            if (bluetoothSDK != null)
            {
                bluetoothSDK.ResetBluetoothStatus();
            }
        }

        [ClassCleanup]
        public static void Quit()
        {
            loginAccessLayer.Quit();
        }

        #endregion Test Cleanup procedure
    }
}