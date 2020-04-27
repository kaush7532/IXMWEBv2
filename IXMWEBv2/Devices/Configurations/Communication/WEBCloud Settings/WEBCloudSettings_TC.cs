using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IXMWEBv2.AccessLayer.DeviceAccessLayers;
using IXMWEBv2.Constants;
using IXMWEBv2.Helper_SDK;
using IXMWEBv2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IXMWEBv2.Devices.Configurations.Communication.WEBCloud_Settings
{
    [TestClass]
    public class WEBCloudSettings_TC : BaseTest
    {

        private DeviceOperations_AL deviceListAccessLayer;
        private WEBCloudSettings_AL webcloudSettingsAccessLayer;
        private CommunicationSDK webcloudSDK;

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

            webcloudSettingsAccessLayer = new WEBCloudSettings_AL();
            webcloudSDK = new CommunicationSDK();
        }

        #endregion Initialization methods

        #region Verify WEBCloud Settings UI testcase

        [TestMethod]
        [TestCategory(Module.WEBCloudModule), TestCategory(TestSuite.UI), TestCategory(Module.DeviceConfiguration)]
        public void WEBCloudSettingUI()
        {
            try
            {
                //Verify UI
                Assert.IsTrue(webcloudSettingsAccessLayer.ValidateWEBCloudSettingUI());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed Test: WEBCloud Settings UI test failed");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }
        #endregion Verify WEBCloud Settings UI testcase

        #region Set WEBCloud setting Test Case

        [TestMethod]
        [TestCategory(Module.WEBCloudModule), TestCategory(TestSuite.Regression), 
            TestCategory(TestSuite.Functional), TestCategory(Module.DeviceConfiguration)]
        public void SetWEBCloudSettings()
        {
            try
            {
                //Reset WEBCloud Settings Using SDK
                Assert.IsTrue(webcloudSDK.ResetWEBCloudSettings(), "SDK: Reset WEBCloud settings failed");

                //Enable WEBCloud settings from ui
                var uiWEBCloud = webcloudSettingsAccessLayer.SetWEBCloudSettings(status: true, cloudurl: "http://27.54.184.26");

                //Get UI value and assert
                Assert.AreEqual("WEB Cloud settings saved", uiWEBCloud.WEBCloudSettingsStatusTxtValue, "WEBCloud settings failed to set");

                //Get using SDK and assert
                var sdkGetWEBCloud = webcloudSDK.GetWEBCloudSettings();

                ////Verify message
                Assert.AreEqual(uiWEBCloud.WEBCloudStatus, sdkGetWEBCloud.CloudStatus, "WEBCloud status failed");
                Assert.AreEqual(uiWEBCloud.WEBCloudSettingsUrlTxtValue, sdkGetWEBCloud.CloudUrl, "WEBCloud URL failed");
                Assert.AreEqual(uiWEBCloud.WEBCloudPortValue, sdkGetWEBCloud.Port, "WEBCloud Port failed");
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Enable WEBCloud setting failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        #endregion Set WEBCloud setting Test Case

        #region Reset WEBCloud Setting Test Case

        [TestMethod]
        [TestCategory(Module.WEBCloudModule), TestCategory(TestSuite.Regression), 
            TestCategory(TestSuite.Functional), TestCategory(Module.DeviceConfiguration)]
        public void ResetWEBCloudSettings()
        //Test to reset WEBCloud settings
        {
            try
            {
                #region SDK setup

                //Reset WEBCloud Settings Using SDK
                Assert.IsTrue(webcloudSDK.ResetWEBCloudSettings(), "SDK: Reset WEBCloud settings failed");

                ///Get WEBCloud settings using SDK and assert
                var sdkGetWEBCloud = webcloudSDK.GetWEBCloudSettings();

                // Update WEBCloud values in Get varable
                sdkGetWEBCloud.CloudStatus = true;
                sdkGetWEBCloud.CloudUrl = "http://27.54.184.26";
                sdkGetWEBCloud.Port = 1255;

                Logger.Info(string.Format("WEBCloud settings using SDK {0}, {1}, {2}",
                         sdkGetWEBCloud.CloudStatus, sdkGetWEBCloud.CloudUrl, sdkGetWEBCloud.Port));

                //Set updated value using SDK
                webcloudSDK.SetWEBCloudSettings(sdkGetWEBCloud.CloudStatus, sdkGetWEBCloud.CloudUrl, sdkGetWEBCloud.Port);

                #endregion SDK setup

                //Reset WEBCloud setting from UI
                var uiResetWEBCloud = webcloudSettingsAccessLayer.ResetWEBCloudSettings();

                //get WEBCloud settings from UI
                var UIGetWEBCloud = webcloudSettingsAccessLayer.GetWEBCloudSettingUI();

                //get WEBCloud settings using SDK
                var sdkGetWEBCloudSettings = webcloudSDK.GetWEBCloudSettings();
               

                //Verify message
                Assert.AreEqual(UIGetWEBCloud.WEBCloudStatus, sdkGetWEBCloudSettings.CloudStatus, "WEBCloud status Restored");
                //Assert.AreEqual(UIGetWEBCloud.WEBCloudPortValue, sdkGetWEBCloudSettings.Port, "WEBCloud Port Restored");
                Assert.AreEqual(UIGetWEBCloud.WEBCloudSettingsUrlTxtValue, sdkGetWEBCloudSettings.CloudUrl, "WEBCloud URL Restored");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Restored WEBCloud setting failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        #endregion Reset WEBCloud Setting Test Case

        [TestCleanup]
        public void Cleanup()
        {
            base.TearDown();
            webcloudSDK.ResetWEBCloudSettings();
        }

        [ClassCleanup]
        public static void Quit()
        {
            //loginAccessLayer.GoToHomePageUrl();

            loginAccessLayer.Quit();
        }
    }
}
