using IXMWEBv2.AccessLayer.QuickNavigationPaneAccessLayers.LogsAccessLayers;
using IXMWEBv2.Constants;

//using IXMWEBv2.HelperSDK.Config;
using IXMWEBv2.Resources.Locators.Logs;
using IXMWEBv2.Utils;
using IXMWEBv2.WebDriverFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IXMWEBv2.Tests.QuickNavigationPane.Logs
{
    [TestClass]
    public class TransactionLogs_TC : BaseTest
    {
        private TransactionLogs_AL tlogsaccessLayer;
        //private GeneralInfo_SDK di;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
            loginAccessLayer.LoginIXMWeb();
            //ixmUtils.SelectDevice(DriverManager.onlineDeviceName);
            ixmUtils.GoToTab(MainTabs.Logs);
            tlogsaccessLayer = new TransactionLogs_AL();
            //di = new GeneralInfo_SDK(dbInteraction.onlineDeviceInfo.IpAddress, DriverManager.onlineDevicePort, DeviceConnectionType.Ethernet);
            //ixmUtils.SelectDevice(dbInteraction.onlineDeviceInfo.DeviceName);
        }

        [TestMethod]
        [TestCategory(TestSuite.UI), TestCategory(Module.TransactionLogModule)]
        public void TLogsPageUI()
        {
            try
            {
                Assert.IsTrue(tlogsaccessLayer.ValidateTLogsPageUI());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to verify transaction logs page ui successfully");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Assertion of this method is yet left to be done
        /// </summary>
        //[TestMethod]
        //[TestCategory(TestSuite.Functional), TestCategory(Module.TransactionLogModule)]
        //public void ExportTLogs()
        //{
        //    try
        //    {
        //        tlogsaccessLayer.ExportTLogs();
        //        //string expectedTxt = tlogspo.TLogsMsgWindowText();
        //        //Assert.IsFalse(expectedTxt.Equals("No Logs to export"));
        //        Logger.Info("Export of TLogs completed successfully", Module.TransactionLogModule.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to export TLogs");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //[TestCategory(TestSuite.Functional), TestCategory(Module.TransactionLogModule)]
        //public void SetBasicSchedule()
        //{
        //    try
        //    {
        //        tlogsaccessLayer.ClickScheduleBtn();
        //        tlogsaccessLayer.EnableSwitchBtn();
        //        tlogsaccessLayer.SetBasicSchedule();

        //        Assert.IsTrue(tlogsaccessLayer.GetTextFromMsgBox().Equals("Auto-Download Schedule saved"));
        //        Logger.Info("set basic schedule", Module.TransactionLogModule.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to set basic schedule");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //[TestCategory(TestSuite.Functional), TestCategory(Module.TransactionLogModule)]
        //public void SetAdvanceSchedule()
        //{
        //    try
        //    {
        //        tlogsaccessLayer.ClickScheduleBtn();
        //        tlogsaccessLayer.EnableSwitchBtn();

        //        tlogsaccessLayer.SetAdvanceSchedule();

        //        Assert.IsTrue(tlogsaccessLayer.GetTextFromMsgBox().Equals("Auto-Download Schedule saved"));
        //        Logger.Info("set Advance schedule", Module.TransactionLogModule.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to set advance schedule");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //[TestCategory(TestSuite.Functional), TestCategory(Module.TransactionLogModule)]
        //public void DownloadAllTLogs()
        //{
        //    try
        //    {
        //        tlogsaccessLayer.DownloadAllTransactionLogs();
        //        int totaldevice = di.deviceInfo.ReadTransactionLogCount + di.deviceInfo.UnreadTransactionLogCount;
        //        int totalUI = tlogsaccessLayer.GetDownloadedTransactionLogCount();
        //        Logger.Info("All logs count from device: " + totaldevice + " and from UI: " + totalUI, Module.TransactionLogModule.ToString());
        //        Assert.AreEqual(totaldevice, totalUI, "Fail: Invalid tlogs count");

        //        Logger.Info("Download of all TLogs is completed successfully", Module.TransactionLogModule.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to download all TLogs successfully");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //[TestCategory(TestSuite.Functional), TestCategory(Module.TransactionLogModule)]
        //public void DownloadUnreadTLogs()
        //{
        //    try
        //    {
        //        ixmUtils.SelectDevice(dbInteraction.onlineDeviceInfo.DeviceName);
        //        tlogsaccessLayer.DownloadUnreadTransactionLogs();

        //        int unreadDevice = di.deviceInfo.UnreadTransactionLogCount;
        //        int unreadUI = tlogsaccessLayer.GetDownloadedTransactionLogCount();
        //        Logger.Info("Download Unread Tlogs count of device: " + unreadDevice + " and from UI: " + unreadUI, Module.TransactionLogModule.ToString());
        //        Assert.AreEqual(unreadDevice, unreadUI, "Fail: Mismatch in unread tlogs count.");

        //        Logger.Info("Download of unread TLogs is completed successfully", Module.TransactionLogModule.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to download unread TLogs successfully");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //[TestCategory(TestSuite.Functional), TestCategory(Module.TransactionLogModule)]
        //public void DownloadMediaTLogs()
        //{
        //    try
        //    {
        //        tlogsaccessLayer.DownloadMediaTransactionLogs();
        //        int totaldevice = di.deviceInfo.UnreadImageTransactionLogCount;
        //        int totalUI = tlogsaccessLayer.downloadedMediaCount;
        //        Logger.Info("Download Media Tlogs count from device: " + totaldevice + " and from UI: " + totalUI, Module.TransactionLogModule.ToString());
        //        Assert.AreEqual(totaldevice, totalUI, "Fail: Mismatch Media TLogs count");
        //        Logger.Info("Download of media is completed successfully", Module.TransactionLogModule.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to download media successfully");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        [TestMethod]
        [TestCategory(TestSuite.Functional), TestCategory(Module.TransactionLogModule)]
        public void DeleteAllTLogs()
        {
            try
            {
                //Check if grid has any count or not
                var tlogsgrid = IXMWebUtils.ItemsCountDetails(TransactionLogsLocators.TLogsGridId, DriverManager.GetInstance().GetDriver());

                if (tlogsgrid.TotalItemsCount == 0)
                {
                    tlogsaccessLayer.DownloadAllTransactionLogs();
                    tlogsaccessLayer.GetDownloadedTransactionLogCount();
                }

                //delete trasaction logs and verify the count on window
                tlogsaccessLayer.DeleteAllTransactionLogs();
                Assert.AreEqual("Transaction Log(s) deleted", tlogsaccessLayer.GetTextFromMsgBox(), "Fail: Mismatch in text on delete message box");
                Assert.IsFalse(IXMWebUtils.DoItemsExist(TransactionLogsLocators.TLogsGridId, DriverManager.GetInstance().GetDriver()), "Fail: TLogs exist after deletion");

                Logger.Info("All TLogs deleted successfully", Module.TransactionLogModule.ToString());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to delete all the TLogs successfully");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            base.TearDown();
            //loginAccessLayer.GoToUrl(Urls.LogsPageURL);
            //loginAccessLayer.GoToUrl(Urls.TransactionLogPageURL);
        }

        [ClassCleanup]
        public static void Quit()
        {
            loginAccessLayer.Quit();
        }
    }
}