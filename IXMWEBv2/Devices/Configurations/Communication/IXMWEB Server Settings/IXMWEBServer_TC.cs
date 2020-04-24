using IXMWEBv2.AccessLayer.DeviceAccessLayers;
using IXMWEBv2.Constants;
using IXMWEBv2.Helper_SDK;
using IXMWEBv2.Utils;
using IXMWEBv2.WebDriverFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IXMWEBv2.Devices.Configurations.Communication.IXMWEB_Server_Settings
{
    [TestClass]
    public class IXMWEBServer_TC : BaseTest
    {
        private DeviceOperations_AL deviceListAccessLayer;
        private IXMWEBServer_AL ixmwebserverAccessLayer;
        private CommunicationSDK ixmwebServerSDK;

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

            ixmwebserverAccessLayer = new IXMWEBServer_AL();
            ixmwebServerSDK = new CommunicationSDK();
        }

        #endregion Initialization methods

        #region Test Methods
        [TestMethod]
        [TestCategory(Module.DeviceConfiguration), TestCategory(Module.IXMWEBServerURL),
            TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void SetValidIXMWEBServerURL()
        {
            //SDK reset server URL
            //ixmwebServerSDK.ResetIXMWEBServerURL();

            //Set SERVER url UI
            var ui = ixmwebserverAccessLayer.SetIXMWEBServerURL(DriverManager.ixmWebUrl);

            //Assert UI
            Assert.AreEqual(CommunicationResourceStrings.IXMWEBServerURLSetMsg, ui.IXMWEBServerStatusTxtValue,
                "IXMWEB Server successfully set message invalid");
            Assert.AreEqual(CommunicationResourceStrings.IXMWEBServerPopUpTitle, ui.IXMWEBServerPopupTitleValue,
                "Invalid title of successfully set server url popup");
            Assert.AreEqual(DriverManager.ixmWebUrl, ui.IXMWEBServerURLTxtValue, "Invalid IXMWEB Server URL set");

            //SDK Assertion with UI
            var sdkURLValue = ixmwebServerSDK.GetIXMWEBServerURL();
            Assert.AreEqual(DriverManager.ixmWebUrl, sdkURLValue, "Invalid IXMWEB Server URL set");
        }

        /// <summary>
        /// Bug 7101 to be referred
        /// </summary>
        [TestMethod]
        [TestCategory(Module.DeviceConfiguration), TestCategory(Module.IXMWEBServerURL),
            TestCategory(TestSuite.Negative)]
        public void SetInvalidIXMWEBServerURL()
        {
            var sdkUrl = ixmwebServerSDK.GetIXMWEBServerURL();
            //Set invalid value of ip
            var ui = ixmwebserverAccessLayer.SetIXMWEBServerURL("http://192.168.500.1");
            Assert.AreEqual(CommunicationResourceStrings.IXMWEBServerInvalidURLSetMsg, ui.IXMWEBServerStatusTxtValue,
                "IXMWEB server invalid URL message incorrect");
            Assert.AreEqual(CommunicationResourceStrings.IXMWEBServerPopUpTitle, ui.IXMWEBServerPopupTitleValue,
                "Invalid title of successfully set server url popup");

            var sdkUrlAfterSet = ixmwebServerSDK.GetIXMWEBServerURL();
            Assert.AreEqual(sdkUrl, sdkUrlAfterSet, "IXMWEB Server invalid url set to device");

            //Set blank value
            ixmwebserverAccessLayer.commpo.ShowIXMWEBServerSettings(true);
            var uiblank = ixmwebserverAccessLayer.SetIXMWEBServerURL(string.Empty);
            Assert.AreEqual(CommunicationResourceStrings.IXMWEBServerInvalidURLSetMsg, ui.IXMWEBServerStatusTxtValue,
                "IXMWEB server invalid URL message incorrect");
            Assert.AreEqual(CommunicationResourceStrings.IXMWEBServerPopUpTitle, ui.IXMWEBServerPopupTitleValue,
                "Invalid title of successfully set server url popup");

            var sdkUrlAfterBlank = ixmwebServerSDK.GetIXMWEBServerURL();
            Assert.AreEqual(sdkUrl, sdkUrlAfterBlank, "IXMWEB Server Blank url set to device");
        }

        #endregion

        #region Test Cleanup procedure
        [TestCleanup]
        public void Cleanup()
        {
            base.TearDown();
            if (ixmwebServerSDK != null)
            {
                //bluetoothSDK.ResetBluetoothStatus();
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
