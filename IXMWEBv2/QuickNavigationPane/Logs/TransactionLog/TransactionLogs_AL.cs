using System;
using IXMWEBv2.PageObjects.QuickNavigationPanePageObjects.LogsPageObjects;
using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Resources.Locators.Logs;
using IXMWEBv2.Utils;
using IXMWEBv2.WebDriverFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IXMWEBv2.AccessLayer.QuickNavigationPaneAccessLayers.LogsAccessLayers
{
    public class TransactionLogs_AL
    {
        public TransactionLogs_PO tlogs;
        public static IXMWebUtils ixmUtils;
        public int downloadedMediaCount;

        public TransactionLogs_AL()
        {
            tlogs = new TransactionLogs_PO();
            //tlogs.GoToTLogsPage();
            ixmUtils = new IXMWebUtils();
        }

        public bool ValidateTLogsPageUI()
        {
            return tlogs.PageElementsAreVisible();
        }

        //public void ClickScheduleBtn()
        //{
        //    tlogs.ClickSetScheduleBtn();
        //}

        /// <summary>
        /// Method to Enable Switch Btn if it is inactive
        /// </summary>
        //public void EnableSwitchBtn()
        //{
        //    if (!IXMWebUtils.IsSwitchButtonThinEnabled(DriverManager.GetInstance().GetDriver()))
        //    {
        //        tlogs.ToogleStatusSwitch();
        //    }
        //    else
        //    {
        //        Logger.Info("Switch Btn already enabled.", Modules.Logs.ToString());
        //    }
        //}

        //public void SetBasicSchedule()
        //{
        //    tlogs.ClickBasicSchedule();
        //    tlogs.SetStartHours();
        //    tlogs.SetStartMins();
        //    tlogs.SetStartSecs();
        //    tlogs.ClickSundayChkBox();
        //    ixmUtils.DeviceSelectionChkBox(DBInteraction.listOfDevicesTreefromDb);
        //    tlogs.ClickApplyBtn();
        //}

        //public void SetAdvanceSchedule()
        //{
        //    tlogs.ClickAdvanceSchedule();
        //    tlogs.SetAdvDateTxt();
        //    tlogs.SetAdvStartHours();
        //    tlogs.SetAdvStartMins();
        //    tlogs.SetAdvStartSecs();
        //    ixmUtils.DeviceSelectionChkBox(DBInteraction.listOfDevicesTreefromDb);
        //    tlogs.ClickApplyBtn();
        //}

        public void ExportTLogs()
        {
            tlogs.ClickExportTLogsBtn();
        }

        public void DownloadAllTransactionLogs()
        {
            try
            {
                tlogs.HoverDownloadDropDown();
                tlogs.ClickDownloadAllTLogs();
                ixmUtils.SelectDeviceFromTreeView(DBInteraction.listOfDevicesTreefromDb, TransactionLogsLocators.DownloadDeviceTreeViewID);
                tlogs.ClickDownloadUnreadBtn();
                IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to DownloadAllTransactionLogs");
                throw;
            }
        }

        public void DownloadUnreadTransactionLogs()
        {
            try
            {
                tlogs.HoverDownloadDropDown();
                tlogs.ClickDownloadUnreadTLogs();
                ixmUtils.SelectDeviceFromTreeView(DBInteraction.listOfDevicesTreefromDb, TransactionLogsLocators.DownloadDeviceTreeViewID);
                tlogs.ClickDownloadUnreadBtn();
                IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to download unread TLogs: Failed in TransactionLogsAccessLayer");
                throw;
            }
        }

        public void DownloadMediaTransactionLogs()
        {
            tlogs.HoverDownloadDropDown();
            tlogs.ClickDownloadMediaTLogs();
            IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader);

            string msg = tlogs.GetTextFromMsgBox();
            downloadedMediaCount = int.Parse(msg.Substring(0, msg.IndexOf(" ")));
        }

        public string GetTextFromMsgBox()
        {
            return tlogs.GetTextFromMsgBox();
        }

        public void DeleteAllTransactionLogs()
        {
            try
            {
                tlogs.HoverDeleteDropDown();
                tlogs.ClickDeleteAll();
                tlogs.SetPassword(DriverManager.ixmWebPassword);
                tlogs.ClickDeleteTLogOkBtn();
                IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to delete transactionlogs");
                throw;
            }
        }

        public int GetDownloadedTransactionLogCount()
        {
            int count = tlogs.GetDownloadedLogsCount();
            Assert.IsTrue(tlogs.VerifySuccessOnDownloadStatusWindow());
            return count;
        }
    }
}