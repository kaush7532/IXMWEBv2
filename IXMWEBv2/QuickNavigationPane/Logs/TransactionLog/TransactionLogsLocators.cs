namespace IXMWEBv2.Resources.Locators.Logs
{
    public class TransactionLogsLocators
    {
        public const string TransactionLogsTab = "btnLoadLogs";

        //#region Set Schedule locators

        //public const string SetScheduleBtn = "scheduleLogs";
        //public const string AutoDownloadWindow = "DownloadTransactionLog_wnd_title";
        //public const string SwitchBtn = ".//*[@class='switchButtonKendoWindow']";
        //public const string ScheduleTypeDropDown = ".//*[@id='settimer']/table[1]/tbody/tr/td[2]/div/table/tbody/tr/td[1]/span/span/span[2]/span";
        //public const string StartTimeHours = ".//*[@name='hourcombo']";
        //public const string StartTimeMins = ".//*[@name='mincombo']";
        //public const string StartTimeSecs = ".//*[@name='seccombo']";
        //public const string SundayScheduleChkBox = "day0";
        //public const string MondayScheduleChkBox = "day1";
        //public const string TuesdayScheduleChkBox = "day2";
        //public const string WednesdayScheduleChkBox = "day3";
        //public const string ThursdayScheduleChkBox = "day4";
        //public const string FridayScheduleChkBox = "day5";
        //public const string SaturdaydayScheduleChkBox = "day6";
        //public const string ScheduleApplyBtn = "btnApply";
        //public const string KendoSelectSchedule = "ScheduleType";
        //public const string DateTxt = "AdvanceDateTime";
        //public const string AdvStartTimeHours = ".//*[@id='advtimepicker']/select[@name='hourcombo']";
        //public const string AdvStartTimeMins = ".//*[@id='advtimepicker']/select[@name='mincombo']";
        //public const string AdvStartTimeSecs = ".//*[@id='advtimepicker']/select[@name='seccombo']";
        //public const string IntervalTxt = ".//*[@id='AdvanceInterval']";

        //#endregion Set Schedule locators

        public const string ExportBtn = ".//*[@id='transaction-logs']//*[normalize-space(text())='Export']";

        #region Download Logs Locators

        //public const string DownloadDropDown = ".//*[@id='transaction-logs']//ul//span[contains(text(),'Download')]";
        //public const string DownloadDropDown = ".//*[@id='transaction-logs']//*[@id='DownloadTLogs_mn_active']";
        public const string DownloadDropDown = "DownloadTLogs";

        public const string DownloadUnread = ".//*[@id='transaction-logs']//ul//span[text() = 'Download']/following-sibling::div/ul/li/span[contains(text(),'Unread')]";
        public const string DownloadUnreadBtn = "DownloadTransaction";

        public const string UnreadTLogDownloadWindow = "StatusUnreadDownload_wnd_title";

        public const string DownloadAll = ".//*[@id='transaction-logs']//ul//span[text() = 'Download']/following-sibling::div/ul/li/span[contains(text(),'All')]";
        public const string DownloadOkBtn = "DownloadOK";
        public const string DownloadPromptWindow = "DownloadLogPromptWindow_wnd_title";

        public const string DownloadStatusWindow = "StatusUnreadDownload_wnd_title";

        public const string DownloadStatus = ".//*[@id='TlogStatusGrid']/div[2]/table/tbody/tr[#num]/td[4]";

        //public const string DownloadStatusWindowCloseBtn = ".//*[@id='StatusUnreadDownload_wnd_title']/following-sibling::div/a/span";

        public const string DownloadStatusWindowCloseBtn = ".//*[@id='StatusUnreadDownload_wnd_title']/following-sibling::div/a";

        public const string DownloadMedia = ".//*[@id='transaction-logs']//ul//span[text() = 'Download']/following-sibling::div/ul/li/span[contains(text(),'Media')]";
        public const string DownloadedLogsCountOnWindow = ".//*[@id='TlogStatusGrid']/div[2]//td[3]";

        public const string DownloadDeviceTreeViewID = "parentDivTLogs";

        #endregion Download Logs Locators

        #region Delete Logs Locators

        public const string DeleteDropDown = "DeleteTLogs";
        public const string DeleteSelected = ".//*[@id = 'DeleteTLogs']//div/ul//span[contains(text(),'Selected')]";
        public const string DeleteAll = ".//*[@id = 'DeleteTLogs']//div/ul//span[contains(text(),'All')]";
        public const string DeletePromptWindow = "DeleteTlogPromptWindow_wnd_title";
        public const string DeletePwdTxt = "tlogPasswordBox";
        public const string DeleteOkBtn = "OK1";

        #endregion Delete Logs Locators

        #region TlogPopup Locators

        public const string TLogMsgWindow = "KendoMsgBox_wnd_title";
        public const string TLogsMsgOkBtn = "msgBoxOkButton";
        public const string TLogsMsgWindowText = ".//*[@id='KendoMsgBox']/div/div/p";

        //public const string ColumnPreference = ".//*[@id='columnedit']/span";
        public const string TLogsGridId = "transactionlogs";

        #endregion TlogPopup Locators
    }
}