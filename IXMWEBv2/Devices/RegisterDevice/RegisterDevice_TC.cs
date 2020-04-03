using IXMWEBv2.AccessLayer.DeviceAccessLayers;
using IXMWEBv2.Constants;
using IXMWEBv2.Helper_SDK.Device;
using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Utils;
using IXMWEBv2.WebDriverFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace IXMWEBv2.Devices.RegisterDevice
{
    //[TestClass]
    public class RegisterDevice_TC : BaseTest
    {
        private RegisterDevice_AL registerdeviceAL;
        private DeviceOperations_AL deviceListAccessLayer;
        private Device_SDK deviceSDKSettings;

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
            registerdeviceAL = new RegisterDevice_AL();
            dbInteraction.DeleteDeviceFromDb(DriverManager.deviceToRegisterIP);
        }

        #endregion Initialization methods

        #region Test Methods

        [TestMethod]
        [TestCategory(Module.DeviceModule), TestCategory(TestSuite.Smoke), TestCategory(TestSuite.UI)]
        public void RegisterDeviceUI()
        {
            try
            {
                //get UI

                //Get DiscoverUI
                //Get RegisterUI
                //Get SummaryUI

                Assert.IsTrue(registerdeviceAL.IsDeviceRegistrationPageUIValid());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Device Register page UI failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]       
        [Ignore]
        public void BulkDeviceRegistration()
        {
            try
            {
                deviceListAccessLayer = new DeviceOperations_AL();
                deviceListAccessLayer.AddDevice();

                registerdeviceAL.SearchDevice(autoDiscover: true);
                Thread.Sleep(2000);
                Assert.IsTrue(IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader),
                    "Fail: Progress bar not displayed while doing AutoDiscovery");

                string deviceName = "IXMSHR";
                registerdeviceAL.BulkRegisterDevice(deviceName, deviceGrpName: "Simulator");

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Register device using auto discover failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        ///ToDo: Provide value of device to register: Name, IPAddress, Serial, Mac, etc
        /// <summary>
        /// Autodiscover devices and register with IXM Web
        /// </summary>
        [TestMethod]
        [TestCategory(Module.DeviceModule), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void RegisterDeviceAutoDiscovery()
        {
            try
            {
                deviceListAccessLayer = new DeviceOperations_AL();
                deviceListAccessLayer.AddDevice();

                registerdeviceAL.SearchDevice(autoDiscover: true);
                //Assert.IsTrue(IXMWebUtils.IsProgressBarShown(true),
                //    "Fail: Progress bar not displayed while doing AutoDiscovery");

                registerdeviceAL.RegisterDevice(DriverManager.deviceToRegisterIP);
                deviceListAccessLayer = new DeviceOperations_AL();

                //Verify device registration on device list page.
                Assert.IsTrue(deviceListAccessLayer.IsDeviceSuccessfullyRegistered(DriverManager.deviceToRegisterIP));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Register device using auto discover failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory(Module.DeviceModule), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional), TestCategory(TestSuite.Smoke)]
        public void RegisterDeviceIPMode()
        {
            try
            {
                deviceListAccessLayer = new DeviceOperations_AL();
                deviceListAccessLayer.AddDevice();

                registerdeviceAL.SearchDevice(startIp: "192.168.1.85", port: "10004");
                //Assert.IsTrue(IXMWebUtils.IsProgressBarShown(true),
                //    "Fail: Progress bar not displayed while searching device in single device IP mode");

                registerdeviceAL.RegisterDevice(DriverManager.deviceToRegisterIP);


                //Verify device registration on device list page.
                Assert.IsTrue(deviceListAccessLayer.IsDeviceSuccessfullyRegistered(DriverManager.deviceToRegisterIP));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Register device using IP failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory(Module.DeviceModule), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void RegisterDeviceIPModeSSL()
        {
            try
            {
                //enabling SSL mode for device IP
                deviceSDKSettings = new Device_SDK();

                deviceSDKSettings.EnableSSLMode();

                //searching device using ip mode with ssl
                registerdeviceAL.SearchDevice(startIp: DriverManager.deviceToRegisterIP, ssl: true);
                Assert.IsTrue(IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader),
                    "Fail: Progress bar not displayed while searching device in SSL device IP mode");

                //registering discovered device
                registerdeviceAL.RegisterDevice(DriverManager.deviceToRegisterIP);
                deviceListAccessLayer = new DeviceOperations_AL();

                //Verify device registration on device list page.
                Assert.IsTrue(deviceListAccessLayer.IsDeviceSuccessfullyRegistered(DriverManager.deviceToRegisterIP));

                //To Do Reset settings providing ssl mode
                //deviceSettings = new Device_SDK(new Device_SDKModel
                //{ DeviceName = "", IpAddress = DriverManager.deviceToRegisterIP, Port = deviceport }, DeviceConnectionType.EthernetSecure);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Register device using IP failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory(Module.DeviceModule), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void RegisterDeviceIPModeDifferentPort()
        {
            string changedPort = "1265";
            try
            {
                deviceSDKSettings = new Device_SDK();

                deviceSDKSettings.ChangeDevicePort(changedPort);

                registerdeviceAL.SearchDevice(startIp: DriverManager.deviceToRegisterIP, port: changedPort);
                Assert.IsTrue(IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader),
                    "Fail: Progress bar not displayed while searching device in single device IP mode");

                registerdeviceAL.RegisterDevice(DriverManager.deviceToRegisterIP);

                deviceListAccessLayer = new DeviceOperations_AL();

                //Verify device registration on device list page.
                Assert.IsTrue(deviceListAccessLayer.IsDeviceSuccessfullyRegistered(DriverManager.deviceToRegisterIP));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Register device using IP failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
            finally
            {
                deviceSDKSettings.ChangeDevicePort(DriverManager.deviceToRegisterPort);
                Logger.Info("Reverted PORT number back to " + DriverManager.deviceToRegisterPort + " from " + changedPort + " using SDK");
            }
        }

        [TestMethod]
        [TestCategory(Module.DeviceModule), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void RegisterDeviceIPModeStartEndRange()
        {
            try
            {
                deviceListAccessLayer = new DeviceOperations_AL();
                deviceListAccessLayer.AddDevice();

                registerdeviceAL.SearchDevice(startIp: "192.168.1.222", endIp: "192.168.1.255");
                Assert.IsTrue(IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader),
                    "Fail: Progress bar not displayed while searching device in range mode");

                registerdeviceAL.BulkRegisterDevice();

                //Verify device registration on device list page.
                Assert.IsTrue(deviceListAccessLayer.IsDeviceSuccessfullyRegistered(DriverManager.deviceToRegisterIP));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Register device using IP for start ip end ip range failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Cleanup methods

        [TestCleanup]
        public void Cleanup()
        {
            base.TearDown();
        }

        [ClassCleanup]
        public static void Quit()
        {
            loginAccessLayer.Quit();
        }

        #endregion Cleanup methods

    }
}
