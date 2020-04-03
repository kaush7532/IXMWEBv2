using System;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace IXMWEBv2.QuickNavigationPane.Sync
{
    public class Sync_PO : GenericBasePage
    {
        public Sync_PO()
        {
            PageFactory.InitElements(_driver, this);
        }

        #region Declaration: Sync Section

        //1 Sync Tab element

        [FindsBy(How = How.Id, Using = SyncLocators.SyncTab)]
        private IWebElement SyncTab { get; set; }

        //2

        [FindsBy(How = How.Id, Using = SyncLocators.AddSyncGrpBtn)]
        private IWebElement AddSyncGrpBtn { get; set; }

        //3 EmpGroup elements

        [FindsBy(How = How.Id, Using = SyncLocators.EmpGrpSearchBox)]
        private IWebElement EmpGrpSearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = SyncLocators.AddVisibleEmpGrpToSyncGrp)]
        private IWebElement AddVisibleEmpGrpToSyncGrp { get; set; }

        [FindsBy(How = How.XPath, Using = SyncLocators.AddEmpGrpToSyncGrp)]
        private IWebElement AddEmpGrpToSyncGrp { get; set; }

        //4 DeviceGroup elements

        [FindsBy(How = How.Id, Using = SyncLocators.DeviceGrpSearchBox)]
        private IWebElement DeviceGrpSearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = SyncLocators.AddVisibleDeviceGrpToSyncGrp)]
        private IWebElement AddVisibleDeviceGrpToSyncGrp { get; set; }

        [FindsBy(How = How.XPath, Using = SyncLocators.AddDeviceGrpToSyncGrp)]
        private IWebElement AddDeviceGrpToSyncGrp { get; set; }

        //5 SyncGroup elements

        [FindsBy(How = How.Id, Using = SyncLocators.SyncGrpNameTxtBox)]
        private IWebElement SyncGrpNameTxtBox { get; set; }

        [FindsBy(How = How.XPath, Using = SyncLocators.CreateSyncBtn)]
        private IWebElement CreateSyncBtn { get; set; }

        [FindsBy(How = How.Id, Using = SyncLocators.CancelSyncBtn)]
        private IWebElement CancelSyncBtn { get; set; }

        //6 SyncGrid elements

        [FindsBy(How = How.XPath, Using = SyncLocators.SyncGroupEdit)]
        private IWebElement SyncGroupEdit { get; set; }

        [FindsBy(How = How.Id, Using = SyncLocators.SyncGroupDelete)]
        private IWebElement SyncGroupDelete { get; set; }

        [FindsBy(How = How.XPath, Using = SyncLocators.SyncGroupSync)]
        private IWebElement SyncGroupSync { get; set; }

        [FindsBy(How = How.Id, Using = SyncLocators.SyncGroupLog)]
        private IWebElement SyncGroupLog { get; set; }

        #endregion Declaration: Sync Section

        /// <summary>
        /// Method clicks on AddSyncGrp Button
        /// </summary>
        public void ClickAddSyncGrpBtn()
        {
            try
            {
                if (IsElementPresent(AddSyncGrpBtn))
                {
                    ClickElement(AddSyncGrpBtn);
                    Logger.Info("Able to click AddSyncGrp button");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to click on AddSyncGrp button");
                throw;
            }
        }

        /// <summary>
        /// Method to add employee group to sync group if it is visible 
        /// </summary>
        /// <param name="EmpGrpName"></param>
        /// <returns></returns>
        //public bool SelectEmpGrp(string EmpGrpName)
        //{
        //    bool isEmpGrpAddedToSyncGrp = false;
        //    try
        //    {
        //        string empGrpXpath = SyncLocators.AddVisibleEmpGrpToSyncGrp.Replace('#EMPGRPNAME', EmpGrpName);
        //        var empGrpToSelect = _driver.FindElement(By.XPath(empGrpXpath));

        //        if(empGrpToSelect.Displayed && empGrpToSelect.Enabled)
        //        {
        //            WaitElementToBeClickable(empGrpToSelect);
        //            ScrollToView(empGrpToSelect);
        //            ClickElement(empGrpToSelect);
        //            isEmpGrpAddedToSyncGrp = true;
        //            Logger.Info("Employee Group:" + EmpGrpName + "added to Sync Group Successfully");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        isEmpGrpAddedToSyncGrp = false;
        //        Logger.Error(ex, "Unable to add Employee Group:" + EmpGrpName + "to sync group");
        //        throw;
        //    }

        //    return isEmpGrpAddedToSyncGrp;
        //}
    }
}