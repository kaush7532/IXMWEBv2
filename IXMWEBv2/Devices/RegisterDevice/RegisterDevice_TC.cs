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
    [TestClass]
    public class RegisterDevice_TC : BaseTest
    {
        private RegisterDevice_AL registerdeviceAL;
        private DeviceOperations_AL deviceListAccessLayer;
        private GeneralInfo_SDK deviceSDKSettings;

        #region Initialization methods

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
            dbInteraction.DeleteDeviceFromDb(DriverManager.deviceToRegisterIP);
            loginAccessLayer.LoginIXMWeb();

            ixmUtils.GoToTab(MainTabs.Devices);
            registerdeviceAL = new RegisterDevice_AL();
        }

        #endregion Initialization methods

        #region Test Methods

        [TestMethod]
        [TestCategory(Module.DeviceModule), TestCategory(TestSuite.Smoke), TestCategory(TestSuite.UI)]
        public void RegisterDeviceUI()
        {
            try
            {
                deviceListAccessLayer = new DeviceOperations_AL();
                deviceListAccessLayer.AddDevice();

                Assert.IsTrue(registerdeviceAL.IsAddDeviceDiscoveryUIValid());
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
                //Click Add Device
                deviceListAccessLayer = new DeviceOperations_AL();
                deviceListAccessLayer.AddDevice();

                //Search Device with auto discover mode
                var discoveredDevices = registerdeviceAL.SearchDevice(autoDiscover: true);

                var uidetails = registerdeviceAL.RegisterDevice(DriverManager.deviceToRegisterIP, discoveredDevices);

                //Verify device registration on device list page.
                Assert.IsTrue(deviceListAccessLayer.IsDeviceSuccessfullyRegistered(uidetails.deviceInfo.SerialNumber));

                //Db verification
                //ToDo but already from UI below SDK verification is done

                //SDK for verification
                var deviceSDKSettings = new GeneralInfo_SDK(DriverManager.deviceToRegisterIP, DriverManager.deviceToRegisterPort, IXMSoft.Business.SDK.Data.DeviceConnectionType.Ethernet);
                var sdkdetails = deviceSDKSettings.GetDeviceGeneralInfo();

                Assert.AreEqual(sdkdetails.Name, uidetails.deviceInfo.DeviceName, "Device name invalid");
                Assert.AreEqual(sdkdetails.SerialNo, uidetails.deviceInfo.SerialNumber, "Device serial invalid");
                Assert.AreEqual(sdkdetails.FwVersion, uidetails.deviceInfo.FirmwareVersion, "Device firmware invalid");
                Assert.AreEqual(sdkdetails.Mac, uidetails.networkInfo.MacID, "Device MAC invalid");
                Assert.AreEqual(sdkdetails.IPAddress, uidetails.networkInfo.IP, "Device IP invalid");
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
                //Click Add Device
                deviceListAccessLayer = new DeviceOperations_AL();
                deviceListAccessLayer.AddDevice();

                //Search Device with Ip Mode
                var discoveredDevices = registerdeviceAL.SearchDevice(startIp: DriverManager.deviceToRegisterIP);

                var uidetails = registerdeviceAL.RegisterDevice(DriverManager.deviceToRegisterIP, discoveredDevices);

                //Verify device registration on device list page.
                Assert.IsTrue(deviceListAccessLayer.IsDeviceSuccessfullyRegistered(uidetails.deviceInfo.SerialNumber));

                //Db verification
                //ToDo but already from UI below SDK verification is done

                //SDK for verification
                var deviceSDKSettings = new GeneralInfo_SDK(DriverManager.deviceToRegisterIP, DriverManager.deviceToRegisterPort, IXMSoft.Business.SDK.Data.DeviceConnectionType.Ethernet);
                var sdkdetails = deviceSDKSettings.GetDeviceGeneralInfo();

                Assert.AreEqual(sdkdetails.Name, uidetails.deviceInfo.DeviceName, "Device name invalid");
                Assert.AreEqual(sdkdetails.SerialNo, uidetails.deviceInfo.SerialNumber, "Device serial invalid");
                Assert.AreEqual(sdkdetails.FwVersion, uidetails.deviceInfo.FirmwareVersion, "Device firmware invalid");
                string mac = sdkdetails.Mac == null ? sdkdetails.WiFiMac : sdkdetails.Mac;
                Assert.AreEqual(mac, uidetails.networkInfo.MacID, "Device MAC invalid");
                Assert.AreEqual(sdkdetails.IPAddress, uidetails.networkInfo.IP, "Device IP invalid");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Register device using IP failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        //To Do yet
        [TestMethod]
        [Ignore]
        [TestCategory(Module.DeviceModule), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void RegisterDeviceIPModeSSL()
        {
            try
            {
                //enabling SSL mode for device IP
                deviceSDKSettings = new GeneralInfo_SDK();

                deviceSDKSettings.EnableSSLMode();

                //searching device using ip mode with ssl
                var discoveredDevices = registerdeviceAL.SearchDevice(startIp: DriverManager.deviceToRegisterIP, ssl: true);

                //registering discovered device
                registerdeviceAL.RegisterDevice(DriverManager.deviceToRegisterIP, discoveredDevices);
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
                //SDK for verification
                var deviceSDKSettings = new GeneralInfo_SDK();

                deviceSDKSettings.ChangeDevicePort(changedPort);

                //Click Add Device
                deviceListAccessLayer = new DeviceOperations_AL();
                deviceListAccessLayer.AddDevice();

                //Search Device with Ip Mode with changed port
                var discoveredDevices = registerdeviceAL.SearchDevice(startIp: DriverManager.deviceToRegisterIP, port: changedPort);

                var uidetails = registerdeviceAL.RegisterDevice(DriverManager.deviceToRegisterIP, discoveredDevices);

                //Verify device registration on device list page.
                Assert.IsTrue(deviceListAccessLayer.IsDeviceSuccessfullyRegistered(uidetails.deviceInfo.SerialNumber));

                deviceSDKSettings = new GeneralInfo_SDK(DriverManager.deviceToRegisterIP, changedPort, IXMSoft.Business.SDK.Data.DeviceConnectionType.Ethernet);

                var sdkdetails = deviceSDKSettings.GetDeviceGeneralInfo();

                //Db verification
                //UI doesn't have port so verifying sdk and db for port.
                var deviceDBInfo = dbInteraction.GetDeviceDetailsFromDB(DriverManager.deviceToRegisterIP);
                Assert.AreEqual(sdkdetails.Port, deviceDBInfo.Port);

                Assert.AreEqual(sdkdetails.Name, uidetails.deviceInfo.DeviceName, "Device name invalid");
                Assert.AreEqual(sdkdetails.SerialNo, uidetails.deviceInfo.SerialNumber, "Device serial invalid");
                Assert.AreEqual(sdkdetails.FwVersion, uidetails.deviceInfo.FirmwareVersion, "Device firmware invalid");
                Assert.AreEqual(sdkdetails.Mac, uidetails.networkInfo.MacID, "Device MAC invalid");
                Assert.AreEqual(sdkdetails.IPAddress, uidetails.networkInfo.IP, "Device IP invalid");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Register device using IP failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
            finally
            {
                deviceSDKSettings = new GeneralInfo_SDK(DriverManager.deviceToRegisterIP, changedPort, IXMSoft.Business.SDK.Data.DeviceConnectionType.Ethernet);
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
                //Click Add Device
                deviceListAccessLayer = new DeviceOperations_AL();
                deviceListAccessLayer.AddDevice();

                var discoveredDevices = registerdeviceAL.SearchDevice(startIp: "192.168.138.2", endIp: "192.168.138.4");

                var allRegisteredDevices = registerdeviceAL.BulkRegisterDevice();

                //Verify device registration on device list page.
                foreach (var uidetails in allRegisteredDevices)
                {
                    Assert.IsTrue(deviceListAccessLayer.IsDeviceSuccessfullyRegistered(uidetails.deviceInfo.SerialNumber));
                    deviceSDKSettings = new GeneralInfo_SDK(uidetails.networkInfo.IP, "9734", IXMSoft.Business.SDK.Data.DeviceConnectionType.Ethernet);
                    var sdkdetails = deviceSDKSettings.GetDeviceGeneralInfo();

                    //Db verification

                    //SDK verification
                    Assert.AreEqual(sdkdetails.Name, uidetails.deviceInfo.DeviceName, "Device name invalid");
                    Assert.AreEqual(sdkdetails.SerialNo, uidetails.deviceInfo.SerialNumber, "Device serial invalid");
                    Assert.AreEqual(sdkdetails.FwVersion, uidetails.deviceInfo.FirmwareVersion, "Device firmware invalid");
                    Assert.AreEqual(sdkdetails.Mac, uidetails.networkInfo.MacID, "Device MAC invalid");
                    Assert.AreEqual(sdkdetails.IPAddress, uidetails.networkInfo.IP, "Device IP invalid");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Register device using IP for start ip end ip range failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        #endregion Test Methods

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