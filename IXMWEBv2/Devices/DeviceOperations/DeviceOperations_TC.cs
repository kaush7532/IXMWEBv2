using System;
using IXMWEBv2.AccessLayer.DeviceAccessLayers;
using IXMWEBv2.Constants;
using IXMWEBv2.Utils;
using IXMWEBv2.WebDriverFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IXMWEBv2.Tests.Devices
{
    [TestClass]
    public class DeviceOperations_TC : BaseTest
    {
        private DeviceOperations_AL deviceAccessLayer;
        private static string deviceIp = DriverManager.deviceToRegisterIP;
        private static string devicePort = DriverManager.deviceToRegisterPort;

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
            deviceAccessLayer = new DeviceOperations_AL();
            //dbInteraction.DeleteDeviceFromDb(deviceIp);
        }

        #endregion Initialization methods

        #region Testcase Methods

        [TestMethod]
        [TestCategory(Module.DeviceModule), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]
        public void RebootDevice()
        {
            try
            {
                deviceAccessLayer.SelectDevice(dbInteraction.onlineDeviceInfo);
                //Register device ip mode
                //Assert.IsTrue(deviceListAccessLayer.DiscoverandRegisterDevice(deviceIp),
                //    "Fail: Unable to discover and register device with IP: " + deviceIp);

                //Reboot device
                Assert.IsTrue(deviceAccessLayer.RebootDevice().Equals("Offline"),
                    "Device not rebooted.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Reboot device failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory(Module.DeviceModule), TestCategory(TestSuite.Functional), TestCategory(TestSuite.UI)]
        public void SearchDeviceFromList_ToDo()
        {
            try
            {
                //register two devices
                //Search based on ip and only one devcie should be shown in list - ui verification
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: Search device from list failed.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

       

        [TestMethod]
        [TestCategory(Module.DeviceModule), TestCategory(TestSuite.Smoke), TestCategory(TestSuite.UI)]
        public void DeviceListPageUI()
        {
            try
            {
                Assert.IsTrue(deviceAccessLayer.IsDeviceListPageUIValid());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Fail: UI verification failed for device list page.");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }





        #endregion Testcase Methods

        #region Cleanup methods

        [TestCleanup]
        public void Cleanup()
        {
            base.TearDown();
            //loginAccessLayer.GoToUrl(Urls.DevicePageURL);
        }

        [ClassCleanup]
        public static void Quit()
        {
            loginAccessLayer.Quit();
        }

        #endregion Cleanup methods
    }
}