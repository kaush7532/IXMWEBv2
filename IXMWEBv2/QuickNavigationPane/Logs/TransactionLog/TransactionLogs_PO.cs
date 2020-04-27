using IXMWEBv2.Constants;
using IXMWEBv2.Resources.Locators.Logs;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace IXMWEBv2.PageObjects.QuickNavigationPanePageObjects.LogsPageObjects
{
    public class TransactionLogs_PO : GenericBasePage
    {
        public TransactionLogs_PO()
        {
            //IXMWebUtils.OfflineDeviceWait(_driver);
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.TransactionLogsTab)]
        private IWebElement TransactionLogsTab { get; set; }

        [FindsBy(How = How.XPath, Using = TransactionLogsLocators.ExportBtn)]
        private IWebElement exportBtn { get; set; }

        #region Download TLogs Elements

        //[FindsBy(How = How.XPath, Using = TransactionLogsLocators.DownloadDropDown)]
        //private IWebElement downloadDropDown { get; set; }
        [FindsBy(How = How.Id, Using = TransactionLogsLocators.DownloadDropDown)]
        private IWebElement downloadDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = TransactionLogsLocators.DownloadUnread)]
        private IWebElement downloadUnread { get; set; }

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.UnreadTLogDownloadWindow)]
        private IWebElement unreadTLogDownloadWindow { get; set; }

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.DownloadUnreadBtn)]
        private IWebElement downloadUnreadBtn { get; set; }

        [FindsBy(How = How.XPath, Using = TransactionLogsLocators.DownloadAll)]
        private IWebElement downloadAll { get; set; }

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.DownloadOkBtn)]
        private IWebElement downloadOkBtn { get; set; }

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.DownloadPromptWindow)]
        private IWebElement downloadPromptWindow { get; set; }

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.DownloadStatusWindow)]
        private IWebElement downloadStatusWindow { get; set; }

        [FindsBy(How = How.XPath, Using = TransactionLogsLocators.DownloadStatusWindowCloseBtn)]
        private IWebElement downloadStatusWindowCloseBtn { get; set; }

        [FindsBy(How = How.XPath, Using = TransactionLogsLocators.DownloadMedia)]
        private IWebElement downloadMedia { get; set; }

        #endregion Download TLogs Elements

        #region Delete TLogs Elements

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.DeleteDropDown)]
        private IWebElement deleteDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = TransactionLogsLocators.DeleteSelected)]
        private IWebElement deleteSelected { get; set; }

        [FindsBy(How = How.XPath, Using = TransactionLogsLocators.DeleteAll)]
        private IWebElement deleteAll { get; set; }

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.DeletePromptWindow)]
        private IWebElement deletePromptWindow { get; set; }

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.DeletePwdTxt)]
        private IWebElement DeletePwdTxt { get; set; }

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.DeleteOkBtn)]
        private IWebElement deleteOkBtn { get; set; }

        #endregion Delete TLogs Elements

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.TLogMsgWindow)]
        private IWebElement tLogMsgWindow { get; set; }

        [FindsBy(How = How.Id, Using = TransactionLogsLocators.TLogsMsgOkBtn)]
        private IWebElement tLogsMsgOkBtn { get; set; }

        [FindsBy(How = How.XPath, Using = TransactionLogsLocators.TLogsMsgWindowText)]
        private IWebElement tLogsMsgWindowText { get; set; }

        //[FindsBy(How = How.XPath, Using = TransactionLogsLocators.ColumnPreference)]
        //private IWebElement columnPreference { get; set; }

        [FindsBy(How = How.XPath, Using = TransactionLogsLocators.DownloadedLogsCountOnWindow)]
        private IWebElement downloadCount { get; set; }

        //#region Set Schedule Elements

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.SetScheduleBtn)]
        //private IWebElement setScheduleBtn { get; set; }

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.AutoDownloadWindow)]
        //private IWebElement autoDownloadWindow { get; set; }

        //[FindsBy(How = How.XPath, Using = TransactionLogsLocators.SwitchBtn)]
        //private IWebElement switchBtn { get; set; }

        //[FindsBy(How = How.XPath, Using = TransactionLogsLocators.ScheduleTypeDropDown)]
        //private IWebElement scheduleTypeDropDown { get; set; }

        //[FindsBy(How = How.XPath, Using = TransactionLogsLocators.StartTimeHours)]
        //private IWebElement startTimeHours { get; set; }

        //[FindsBy(How = How.XPath, Using = TransactionLogsLocators.StartTimeMins)]
        //private IWebElement startTimeMins { get; set; }

        //[FindsBy(How = How.XPath, Using = TransactionLogsLocators.StartTimeSecs)]
        //private IWebElement startTimeSecs { get; set; }

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.SundayScheduleChkBox)]
        //private IWebElement sundayScheduleChkBox { get; set; }

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.MondayScheduleChkBox)]
        //private IWebElement mondayScheduleChkBox { get; set; }

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.TuesdayScheduleChkBox)]
        //private IWebElement tuesdayScheduleChkBox { get; set; }

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.WednesdayScheduleChkBox)]
        //private IWebElement wednesdayScheduleChkBox { get; set; }

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.ThursdayScheduleChkBox)]
        //private IWebElement thursdayScheduleChkBox { get; set; }

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.FridayScheduleChkBox)]
        //private IWebElement fridayScheduleChkBox { get; set; }

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.SaturdaydayScheduleChkBox)]
        //private IWebElement saturdaydayScheduleChkBox { get; set; }

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.KendoSelectSchedule)]
        //private IWebElement SelectScheduleKendo { get; set; }

        //[FindsBy(How = How.XPath, Using = TransactionLogsLocators.AdvStartTimeHours)]
        //private IWebElement advStartTimeHours { get; set; }

        //[FindsBy(How = How.XPath, Using = TransactionLogsLocators.AdvStartTimeMins)]
        //private IWebElement advStartTimeMins { get; set; }

        //[FindsBy(How = How.XPath, Using = TransactionLogsLocators.AdvStartTimeSecs)]
        //private IWebElement advStartTimeSecs { get; set; }

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.ScheduleApplyBtn)]
        //private IWebElement scheduleApplyBtn { get; set; }

        //[FindsBy(How = How.Id, Using = TransactionLogsLocators.DateTxt)]
        //private IWebElement dateTxt { get; set; }

        //[FindsBy(How = How.XPath, Using = TransactionLogsLocators.IntervalTxt)]
        //private IWebElement intervalTxt { get; set; }

        //#endregion Set Schedule Elements

        public TransactionLogs_PO GoToTLogsPage()
        {
            Logger.Info("Clicking on Transaction Logs Tab", Module.TransactionLogModule.ToString());
            ClickElement(TransactionLogsTab);

            return new TransactionLogs_PO();
        }

        public bool IsTLogsTabVisible()
        {
            WaitForVisibleElement(By.XPath(TransactionLogsLocators.TransactionLogsTab));
            return TransactionLogsTab.Displayed && TransactionLogsTab.Enabled;
        }

        public void ClickTLogsTab()
        {
            if (IsTLogsTabVisible())
            {
                ClickElement(TransactionLogsTab);
            }
        }

        //#region Set Schedule Functions

        //public bool IsSetScheduleBtnVisible()
        //{
        //    return setScheduleBtn.Displayed && setScheduleBtn.Enabled;
        //}

        //public void ClickSetScheduleBtn()
        //{
        //    if (IsSetScheduleBtnVisible())
        //    {
        //        ClickElement(setScheduleBtn);
        //    }
        //}

        //public bool IsAutoDownloadWindowVisible()
        //{
        //    WaitForVisibleElement(By.Id(TransactionLogsLocators.AutoDownloadWindow));
        //    return autoDownloadWindow.Displayed && autoDownloadWindow.Enabled;
        //}

        //public void ToogleStatusSwitch()
        //{
        //    if (IsAutoDownloadWindowVisible())
        //    {
        //        ClickElement(switchBtn);
        //    }
        //}

        //public bool IsScheduleDropDownVisible()
        //{
        //    WaitForVisibleElement(By.XPath(TransactionLogsLocators.ScheduleTypeDropDown));
        //    return scheduleTypeDropDown.Enabled && scheduleTypeDropDown.Displayed;
        //}

        //public void ClickBasicSchedule()
        //{
        //    IXMWebUtils.KendoDropDownSelectItemByValue(TransactionLogsLocators.KendoSelectSchedule, "Basic", _driver);
        //}

        //public bool IsStartHoursVisible()
        //{
        //    WaitForVisibleElement(By.XPath(TransactionLogsLocators.StartTimeHours));
        //    return startTimeHours.Displayed && startTimeHours.Enabled;
        //}

        //public void SetStartHours()
        //{
        //    if (IsStartHoursVisible())
        //    {
        //        ClickElement(startTimeHours);
        //        startTimeHours.SendKeys(DateTime.Now.ToString("HH"));
        //    }
        //}

        //public bool IsStartMinsVisible()
        //{
        //    WaitForVisibleElement(By.XPath(TransactionLogsLocators.StartTimeMins));
        //    return startTimeMins.Displayed && startTimeMins.Enabled;
        //}

        //public void SetStartMins()
        //{
        //    if (IsStartMinsVisible())
        //    {
        //        ClickElement(startTimeMins);
        //        startTimeMins.SendKeys(DateTime.Now.ToString("mm"));
        //    }
        //}

        //public bool IsStartSecsVisible()
        //{
        //    WaitForVisibleElement(By.XPath(TransactionLogsLocators.StartTimeSecs));
        //    return startTimeSecs.Displayed && startTimeSecs.Enabled;
        //}

        //public void SetStartSecs()
        //{
        //    if (IsStartSecsVisible())
        //    {
        //        ClickElement(startTimeSecs);
        //        startTimeSecs.SendKeys(DateTime.Now.ToString("ss"));
        //    }
        //}

        //public bool IsSundayChkBoxVisible()
        //{
        //    WaitForVisibleElement(By.Id(TransactionLogsLocators.SundayScheduleChkBox));
        //    return sundayScheduleChkBox.Displayed && sundayScheduleChkBox.Enabled;
        //}

        //public void ClickSundayChkBox()
        //{
        //    if (IsSundayChkBoxVisible())
        //    {
        //        if (!(sundayScheduleChkBox.Selected))
        //        {
        //            ClickElement(sundayScheduleChkBox);
        //        }
        //    }
        //}

        //public void ClickAdvanceSchedule()
        //{
        //    IXMWebUtils.KendoDropDownSelectItemByValue(TransactionLogsLocators.KendoSelectSchedule, "Advance", _driver);
        //}

        //public bool IsSetAdvDateTxtVisisble()
        //{
        //    WaitForVisibleElement(By.Id(TransactionLogsLocators.DateTxt));
        //    return dateTxt.Enabled && dateTxt.Displayed;
        //}

        //public void SetAdvDateTxt()
        //{
        //    if (IsSetAdvDateTxtVisisble())
        //    {
        //        EnterValueTextbox(dateTxt, Util.GetDateAsString());
        //    }
        //}

        //public bool IsAdvStartHoursVisible()
        //{
        //    WaitForVisibleElement(By.XPath(TransactionLogsLocators.AdvStartTimeHours));
        //    return advStartTimeHours.Displayed && advStartTimeHours.Enabled;
        //}

        //public void SetAdvStartHours()
        //{
        //    if (IsAdvStartHoursVisible())
        //    {
        //        ClickElement(advStartTimeHours);
        //        advStartTimeHours.SendKeys(DateTime.Now.ToString("HH"));
        //    }
        //}

        //public bool IsAdvStartMinsVisible()
        //{
        //    WaitForVisibleElement(By.XPath(TransactionLogsLocators.AdvStartTimeMins));
        //    return advStartTimeMins.Displayed && advStartTimeMins.Enabled;
        //}

        //public void SetAdvStartMins()
        //{
        //    if (IsAdvStartMinsVisible())
        //    {
        //        ClickElement(advStartTimeMins);
        //        advStartTimeMins.SendKeys(DateTime.Now.ToString("mm"));
        //    }
        //}

        //public bool IsAdvStartSecsVisible()
        //{
        //    WaitForVisibleElement(By.XPath(TransactionLogsLocators.AdvStartTimeSecs));
        //    return advStartTimeSecs.Displayed && advStartTimeSecs.Enabled;
        //}

        //public void SetAdvStartSecs()
        //{
        //    if (IsAdvStartSecsVisible())
        //    {
        //        ClickElement(advStartTimeSecs);
        //        advStartTimeSecs.SendKeys(DateTime.Now.ToString("ss"));
        //    }
        //}

        //public bool IsSetIntervalTxtVisible()
        //{
        //    WaitForVisibleElement(By.XPath(TransactionLogsLocators.IntervalTxt));
        //    return intervalTxt.Enabled && intervalTxt.Displayed;
        //}

        //public void SetIntervalTxt(string interval = null)
        //{
        //    if (IsSetIntervalTxtVisible())
        //    {
        //        string setinterval = string.IsNullOrEmpty(interval) ? "30" : interval;

        //        EnterValueTextbox(intervalTxt, setinterval);
        //    }
        //}

        //public void ClickApplyBtn()
        //{
        //    ClickElement(scheduleApplyBtn);
        //}

        //#endregion Set Schedule Functions

        #region Export Logs Functions

        public bool IsExportBtnVisible()
        {
            WaitForVisibleElement(By.XPath(TransactionLogsLocators.ExportBtn));
            return exportBtn.Displayed && exportBtn.Enabled;
        }

        public void ClickExportTLogsBtn()
        {
            if (IsExportBtnVisible())
            {
                ClickElement(exportBtn);
            }
        }

        #endregion Export Logs Functions

        #region Common Download Logs Functions

        public bool IsDownloadDropDownVisible()
        {
            //WaitForVisibleElement(By.XPath(TransactionLogsLocators.DownloadDropDown));
            var ele = WaitForVisibleElement(By.Id(TransactionLogsLocators.DownloadDropDown));
            Logger.Info(ele.Text);
            return downloadDropDown.Displayed && downloadDropDown.Enabled;
        }

        public void HoverDownloadDropDown()
        {
            Thread.Sleep(2000);
            if (IsDownloadDropDownVisible())
            {
                HoverWebElement(downloadDropDown);
                Logger.Info("Download button hovered");
            }
        }

        public int GetDownloadedLogsCount()
        {
            return int.Parse(downloadCount.Text);
        }

        #endregion Common Download Logs Functions

        #region Download All TLogs Functions

        public bool IsDownloadAllTLogsVisible()
        {
            WaitForVisibleElement(By.XPath(TransactionLogsLocators.DownloadAll));
            return downloadAll.Displayed && downloadAll.Enabled;
        }

        public bool IsDownloadAllTLogsClickable()
        {
            WaitElementToBeClickable(downloadAll);
            return downloadAll.Enabled;
        }

        public void ClickDownloadAllTLogs()
        {
            if (IsDownloadAllTLogsClickable())
            {
                ClickElement(downloadAll);
                Logger.Info("Clicked on Download->All button", Module.TransactionLogModule.ToString());
            }
        }

        public bool IsDownloadPromptWindowVisible()
        {
            WaitForVisibleElement(By.Id(TransactionLogsLocators.DownloadPromptWindow));
            return downloadPromptWindow.Displayed && downloadPromptWindow.Enabled;
        }

        public bool IsDownloadPromptWindowDisappear()
        {
            Logger.Info("Waiting for progress bar to be invisible", Module.TransactionLogModule.ToString());
            WaitForElementDisappear(downloadPromptWindow);
            return !downloadPromptWindow.Displayed;
        }

        public void ClickDownloadOkBtn()
        {
            if (IsDownloadPromptWindowVisible())
            {
                ClickElement(downloadOkBtn);
                Logger.Info("Clicked on Download button", Module.TransactionLogModule.ToString());
            }
        }

        #endregion Download All TLogs Functions

        #region Download Unread TLogs Function

        public bool IsDownloadUnreadTLogsVisible()
        {
            WaitForVisibleElement(By.XPath(TransactionLogsLocators.DownloadUnread));
            return downloadUnread.Displayed && downloadUnread.Enabled;
        }

        public void ClickDownloadUnreadTLogs()
        {
            if (IsDownloadUnreadTLogsVisible())
            {
                ClickElement(downloadUnread);
            }
        }

        public bool IsUnreadTLogDownloadWindowVisible()
        {
            WaitForVisibleElement(By.Id(TransactionLogsLocators.UnreadTLogDownloadWindow));
            return unreadTLogDownloadWindow.Displayed && unreadTLogDownloadWindow.Enabled;
        }

        public bool IsUnreadTLogDownloadWindowDisappear()
        {
            WaitForElementDisappear(unreadTLogDownloadWindow);
            return !unreadTLogDownloadWindow.Displayed;
        }

        public bool IsDownloadBtnVisible()
        {
            WaitForVisibleElement(By.Id(TransactionLogsLocators.DownloadUnreadBtn));
            return downloadUnreadBtn.Displayed && downloadUnreadBtn.Enabled;
        }

        public void ClickDownloadUnreadBtn()
        {
            if (IsDownloadBtnVisible())
            {
                ClickElement(downloadUnreadBtn);
            }
        }

        #endregion Download Unread TLogs Function

        #region Download Common Functions for All and Unread TLogs

        public bool IsDownloadStatusWindowVisible()
        {
            WaitForVisibleElement(By.Id(TransactionLogsLocators.DownloadStatusWindow));
            return downloadStatusWindow.Displayed && downloadStatusWindow.Enabled;
        }

        public bool VerifySuccessOnDownloadStatusWindow()
        {
            List<IWebElement> webElements = new List<IWebElement>();
            bool result;

            if (IsDownloadStatusWindowVisible())
            {
                for (int i = 1; i < 5000; i++)
                {
                    string name = TransactionLogsLocators.DownloadStatus.Replace("#num", i.ToString());
                    if (_driver.FindElements(By.XPath(name)).Count > 0)
                    {
                        IWebElement ele = null;
                        ele = _driver.FindElement(By.XPath(name));
                        webElements.Add(ele);
                        HoverWebElement(ele);
                    }
                    else
                    {
                        break;
                    }
                }

                result = webElements.All(d => d.Text.Equals("Success"));

                if (result)
                {
                    Logger.Info("Application logs has success message", Module.TransactionLogModule.ToString());
                    CloseDownloadStatusWindow();
                    return true;
                }
                else
                {
                    Logger.Error("Application logs has failure message", Module.TransactionLogModule.ToString());
                    CloseDownloadStatusWindow();
                    return false;
                }
            }
            else
            {
                Logger.Error("Fail: Unable to see application window", Module.TransactionLogModule.ToString());
                return false;
            }
        }

        public void CloseDownloadStatusWindow()
        {
            ClickElement(downloadStatusWindowCloseBtn);
            Logger.Info("Closed download logs status window", Module.TransactionLogModule.ToString());
        }

        #endregion Download Common Functions for All and Unread TLogs

        #region Download Media TLog Functions

        public bool IsDownloadMediaTLogsVisible()
        {
            WaitForVisibleElement(By.XPath(TransactionLogsLocators.DownloadMedia));
            return downloadMedia.Displayed && downloadMedia.Enabled;
        }

        public void ClickDownloadMediaTLogs()
        {
            if (IsDownloadMediaTLogsVisible())
            {
                ClickElement(downloadMedia);
            }
        }

        public string GetTextFromMsgBox()
        {
            string msgTxt = string.Empty;
            if (IsTLogsMsgWindowVisible())
            {
                msgTxt = tLogsMsgWindowText.Text;
                ClickTLogsMsgOkBtn();
                return msgTxt;
            }
            return null;
        }

        #endregion Download Media TLog Functions

        #region Common Delete Logs Functions

        public bool IsDeleteDropDownVisible()
        {
            try
            {
                var waitelement = WaitForVisibleElement(By.Id(TransactionLogsLocators.DeleteDropDown));
                Logger.Info("DeleteDropdownVisible: " + waitelement.Displayed);
                return deleteDropDown.Displayed && deleteDropDown.Enabled;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to check delete drod down visibility");
                return false;
            }
        }

        public void HoverDeleteDropDown()
        {
            if (IsDeleteDropDownVisible())
            {
                Logger.Info("Transactionlog Delete dropdown is visible.");
                HoverWebElement(deleteDropDown, 5);
            }
        }

        #endregion Common Delete Logs Functions

        #region Delete All TLogs Functions

        public bool IsDeleteAllTLogsVisible()
        {
            try
            {
                WaitForVisibleElement(By.XPath(TransactionLogsLocators.DeleteAll));
                return deleteAll.Displayed && deleteAll.Enabled;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to check visibility of DeleteAll button from dropdown");
                return false;
            }
        }

        public void ClickDeleteAll()
        {
            if (IsDeleteAllTLogsVisible())
            {
                ClickElement(deleteAll);
                Logger.Info("Clicked Delete->All button", Module.TransactionLogModule.ToString());
            }
            else
            {
                throw new Exception("Failed to click DeleteAll Tlogs. Button not visible for deleting Tlogs.");
            }
        }

        #endregion Delete All TLogs Functions

        #region Delete common functions for delete All and delete selected

        public bool IsDeletePromptWindowVisible()
        {
            WaitForVisibleElement(By.Id(TransactionLogsLocators.DeletePromptWindow));
            return deletePromptWindow.Displayed && deletePromptWindow.Enabled;
        }

        public void SetPassword(string password)
        {
            try
            {
                if (IsDeletePromptWindowVisible())
                {
                    EnterValueTextbox(DeletePwdTxt, password);
                    Logger.Info("Entered " + password + " as password value", Module.TransactionLogModule.ToString());
                }
                else
                {
                    throw new Exception("Failed to set password for deleting tlogs. Delete prompt not visible");
                }
            }
            catch (Exception)
            {
                throw new Exception("Failed to set password for deleting tlogs");
            }
        }

        public void ClickDeleteTLogOkBtn()
        {
            try
            {
                ClickElement(deleteOkBtn);
                Logger.Info("Clicked OK button to DeleteTlog on popup");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to click OK button on DeleteTlog popup");
                throw;
            }
        }

        #endregion Delete common functions for delete All and delete selected

        public bool IsTLogsMsgWindowVisible()
        {
            WaitForVisibleElement(By.Id(TransactionLogsLocators.TLogMsgWindow));
            return tLogMsgWindow.Displayed && tLogMsgWindow.Enabled;
        }

        public string TLogsMsgWindowText()
        {
            if (IsTLogsMsgWindowVisible())
            {
                string returnTxt = tLogsMsgWindowText.Text.ToString();
                ClickTLogsMsgOkBtn();
                return returnTxt;
            }
            return null;
        }

        public void ClickTLogsMsgOkBtn()
        {
            if (IsTLogsMsgWindowVisible())
            {
                ClickElement(tLogsMsgOkBtn);
            }
        }

        public bool PageElementsAreVisible()
        {
            //WaitForElementPresent(columnPreference);
            if (IsElementPresent(exportBtn) &&
                IsElementPresent(downloadDropDown) &&
                IsElementPresent(deleteDropDown)
                )
                return true;
            return false;
        }
    }
}