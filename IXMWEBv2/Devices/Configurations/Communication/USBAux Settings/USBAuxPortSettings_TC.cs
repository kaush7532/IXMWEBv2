using IXMWEBv2.AccessLayer.DeviceAccessLayers;
using IXMWEBv2.Constants;
using IXMWEBv2.Helper_SDK;
using IXMWEBv2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IXMWEBv2.Devices.Configurations.Communication.USBAuxSettings
{
    [TestClass]
    public class USBAuxPortSettings_TC : BaseTest
    {
        private DeviceOperations_AL deviceListAccessLayer;
        private USBAuxPortSettings_AL usbportSettingsAccessLayer;
        private CommunicationSDK usbportSDK;

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

            deviceListAccessLayer = new DeviceOperations_AL();
            ixmUtils.GoToDeviceConfigurations(DeviceConfigurationTabs.Communication);

            usbportSettingsAccessLayer = new USBAuxPortSettings_AL();
            usbportSDK = new CommunicationSDK();
        }

        #endregion Initialization methods

        [TestMethod]
        [TestCategory(Module.USBAuxPortModule), TestCategory(Module.DeviceConfiguration), TestCategory(TestSuite.UI)]
        public void USBAuxPortSettingUI()
        {
            try
            {
                //Verify UI
                Assert.IsTrue(usbportSettingsAccessLayer.ValidateUSBAuxPortSettingUI());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed Test: USBAux Port Settings UI test failed");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory(Module.USBAuxPortModule), TestCategory(Module.DeviceConfiguration), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void EnableUSBAuxSettings()
        {
            try
            {
                //Reset DTMF Settings Using SDK
                Assert.IsTrue(usbportSDK.ResetUSBAuxPortSettings(), "SDK: Reset USB Aux Port settings failed");

                //Enable USB Aux Port settings from ui
                var uiUSBAuxPort = usbportSettingsAccessLayer.EnableDisbaleUSBAuxPort(true);

                //Get using SDK and assert
                var sdkGetUsbAuxPort = usbportSDK.GetUSBAuxPortSettings();

                //Verify
                Assert.AreEqual(uiUSBAuxPort.USBAuxPortStatus, sdkGetUsbAuxPort, "USB Aux Port status failed");

                Assert.AreEqual(CommunicationResourceStrings.USBAuxStoreMsg, uiUSBAuxPort.USBAuxPortSettingsStatusTxtValue);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed Test: Unable to Enable on USB Aux Port setting");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory(Module.USBAuxPortModule), TestCategory(Module.DeviceConfiguration), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void DisableUSBAuxSettings()
        {
            try
            {
                //Reset DTMF Settings Using SDK
                Assert.IsTrue(usbportSDK.ResetUSBAuxPortSettings(), "SDK: Reset USB Aux Port settings failed");

                //Disable USB Aux Port settings from ui
                var uiUSBAuxPort = usbportSettingsAccessLayer.EnableDisbaleUSBAuxPort(false);

                //Get using SDK and assert
                var sdkGetUsbAuxPort = usbportSDK.GetUSBAuxPortSettings();

                //Verify
                Assert.AreEqual(uiUSBAuxPort.USBAuxPortStatus, sdkGetUsbAuxPort, "USB Aux Port status failed");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed Test: Unable to Disable on USB Aux Port setting");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory(Module.USBAuxPortModule), TestCategory(Module.DeviceConfiguration), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void ResetUSBAuxSettings()
        {
            try
            {
                //Resets USB Aux Port settings from ui
                var uiUSBAuxPort = usbportSettingsAccessLayer.ResetUSBAuxPortSetting();

                //Get using SDK and assert
                var sdkGetUsbAuxPort = usbportSDK.GetUSBAuxPortSettings();

                //Verify
                Assert.AreEqual(uiUSBAuxPort.USBAuxPortStatus, sdkGetUsbAuxPort,
                    "USB Aux Port status failed");
                Assert.AreEqual(uiUSBAuxPort.USBAuxPortSettingsStatusTxtValue, CommunicationResourceStrings.USBAuxRestoredMsg,
                    "USB Restored message incorrect");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed Test: Unable to Reset on USB Aux Port setting");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            base.TearDown();
            usbportSDK.ResetUSBAuxPortSettings();
        }

        [ClassCleanup]
        public static void Quit()
        {
            //loginAccessLayer.GoToHomePageUrl();

            loginAccessLayer.Quit();
        }
    }
}