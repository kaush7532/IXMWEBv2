#region Using

using IXMWEBv2.AccessLayer.DeviceAccessLayers;
using IXMWEBv2.Constants;
using IXMWEBv2.Helper_SDK;
using IXMWEBv2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

#endregion Using

namespace IXMWEBv2.Devices.Configurations.Communication.DTMFSettings
{
    [TestClass]
    public class DTMFSettings_TC : BaseTest
    {
        private DeviceOperations_AL deviceListAccessLayer;
        private DTMFSettings_AL dtmfSettingsAccessLayer;
        private CommunicationSDK dtmfSDK;

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

            dtmfSettingsAccessLayer = new DTMFSettings_AL();
            dtmfSDK = new CommunicationSDK();
        }

        #endregion Initialization methods

        #region Testcase Methods

        #region Set DTMF Test Case

        [TestMethod]
        [TestCategory(Module.DTMFModule), TestCategory(Module.DeviceConfiguration), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void SetDTMFSettings()
        {
            try
            {
                //Reset DTMF Settings Using SDK
                Assert.IsTrue(dtmfSDK.ResetDTMFSettings(), "SDK: Reset DTMF settings failed");

                //Enable DTMF settings from ui
                var uiDTMF = dtmfSettingsAccessLayer.SetDTMFSettings(status: true, sendWiegandStatus: true, dtmfCode: "16");

                //Get UI value and assert
                Assert.AreEqual("DTMF settings saved", uiDTMF.DTMFSettingsStatusTxtValue, "DTMF settings failed to set");

                //Get using SDK and assert
                var sdkGetDTMF = dtmfSDK.GetDTMFSettings();

                //Verify message
                Assert.AreEqual(uiDTMF.DTMFStatus, sdkGetDTMF.Status, "DTMF status failed");
                Assert.AreEqual(uiDTMF.SendWiegandStatus, sdkGetDTMF.WiegandStatus, "DTMF Wiegand failed");
                Assert.AreEqual(uiDTMF.DTMFCode, sdkGetDTMF.DTMFEvents.Select(x => x.Code).FirstOrDefault(), "DTMF Code failed");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Enable DTMF setting failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        #endregion Set DTMF Test Case

        #region Reset DTMF Test Case

        [TestMethod]
        [TestCategory(Module.DTMFModule), TestCategory(Module.DeviceConfiguration), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void ResetDTMFSettings()
        //Test to reset DTMF settings
        {
            try
            {
                #region SDK setup

                //Reset DTMF setting using SDk
                Assert.IsTrue(dtmfSDK.ResetDTMFSettings(), "SDK: Failed to reset DTMF settings");

                // Get DTMF setting using SDK
                var dtmfondevice = dtmfSDK.GetDTMFSettings();

                // Update DTMF value in Get varable
                dtmfondevice.Status = true;
                dtmfondevice.WiegandStatus = true;
                dtmfondevice.DTMFEvents.FirstOrDefault().Code = 16;

                Logger.Info(string.Format("DTMF settings using SDK {0}, {1}",
                         dtmfondevice.Status, dtmfondevice.WiegandStatus));

                //Set updated value using SDK
                dtmfSDK.SetDTMFSettings(dtmfondevice);

                #endregion SDK setup

                var uiDTMF = dtmfSettingsAccessLayer.ResetDTMFSettings();

                //Reset dtmf setting from ui
                var UIGetDTMF = dtmfSettingsAccessLayer.GetDTMFSettingUI();

                //get DTMFsettings using SDK
                var sdkGetDTMF = dtmfSDK.GetDTMFSettings();
                //Logger.Info(string.Format("ui status{1} sendwiegandstatus {2} DTMF code {3} SDK Status {4} wiegand{5} code{6}", UIGetDTMF.DTMFStatus, UIGetDTMF.SendWiegandStatus, UIGetDTMF.DTMFCode, sdkGetDTMF.Status,sdkGetDTMF.WiegandStatus, sdkGetDTMF.DTMFEvents.Select(x => x.Code).FirstOrDefault()));

                //Verify message
                Assert.AreEqual(UIGetDTMF.DTMFStatus, sdkGetDTMF.Status, "DTMF status Reseted");
                Assert.AreEqual(UIGetDTMF.SendWiegandStatus, sdkGetDTMF.WiegandStatus, "DTMF Wiegand Reseted");
                Assert.AreEqual(UIGetDTMF.DTMFCode, sdkGetDTMF.DTMFEvents.Select(x => x.Code).FirstOrDefault(), "DTMF Code Reseted");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Reset DTMF setting failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        #endregion Reset DTMF Test Case

        #region Set invalid value in door open code

        [TestMethod]
        [TestCategory(Module.DTMFModule), TestCategory(Module.DeviceConfiguration), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Negative)]
        public void SetInvalidDoorOpenCode()
        //Test to Pass nagative value in door open code
        {
            try
            {
                //try entring 3 digit
                var uiThreeCharValueDTMF = dtmfSettingsAccessLayer.SetDTMFSettings("123", true, true);
                //verify the value
                Assert.AreEqual(CommunicationResourceStrings.DTMFInvalidCodeValue, uiThreeCharValueDTMF.DTMFSettingsStatusTxtValue, "DTMF settings failed to set");

                //try entering 4 digit
                var uiFourCharValueDTMF = dtmfSettingsAccessLayer.SetDTMFSettings("1234", true, true);
                //verify the output
                Assert.AreEqual(CommunicationResourceStrings.DTMFInvalidCodeValue, uiFourCharValueDTMF.DTMFSettingsStatusTxtValue, "DTMF settings failed to set");

                //try entering negative value
                var uiNegativeCharValueDTMF = dtmfSettingsAccessLayer.SetDTMFSettings("-1", true, true);
                //verify the value
                Assert.AreEqual(CommunicationResourceStrings.DTMFInvalidCodeValue, uiNegativeCharValueDTMF.DTMFSettingsStatusTxtValue, "DTMF settings failed to set");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: set invalid door open code");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        #endregion Set invalid value in door open code

        #endregion Testcase Methods

        #region Test Cleanup procedure

        [TestCleanup]
        public void Cleanup()
        {
            base.TearDown();
            if (dtmfSDK != null)
            {
                dtmfSDK.ResetDTMFSettings();
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