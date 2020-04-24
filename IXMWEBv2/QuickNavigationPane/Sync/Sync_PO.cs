using System;
using System.Collections.Generic;
using System.Linq;
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

        #region Adding employee groups to sync group methods

        /// <summary>
        /// Method to add employee group to sync group if it is visible
        /// </summary>
        /// <param name="EmpGrpNames">Employee group names</param>
        /// <returns></returns>
        public bool SelectEmpGrp(string EmpGrpNames)
        {
            bool isEmpGrpAddedToSyncGrp = false;
            try
            {
                List<string> empGrpName = EmpGrpNames.Split(',').ToList();

                foreach (var item in empGrpName)
                {
                    string empGrpXpath = SyncLocators.AddVisibleEmpGrpToSyncGrp.Replace("#EMPGRPNAME", item);
                    var empGrpToSelect = _driver.FindElement(By.XPath(empGrpXpath));

                    if (empGrpToSelect.Displayed && empGrpToSelect.Enabled)
                    {
                        WaitElementToBeClickable(empGrpToSelect);
                        ScrollToView(empGrpToSelect);
                        ClickElement(empGrpToSelect);
                        isEmpGrpAddedToSyncGrp = true;
                        Logger.Info("Employee Group:" + EmpGrpNames + "added to Sync Group Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                isEmpGrpAddedToSyncGrp = false;
                Logger.Error(ex, "Unable to add Employee Group:" + EmpGrpNames + "to sync group");
                throw;
            }

            return isEmpGrpAddedToSyncGrp;
        }

        /// <summary>
        /// Method to add employee group to sync group after searching the employee group from search box
        /// </summary>
        /// <param name="EmpGrpNames">Employee group names</param>
        public void SearchAndAddEmpGrpToSyncGrp(string EmpGrpNames)
        {
            List<string> empGrpName = EmpGrpNames.Split(',').ToList();

            foreach (var item in empGrpName)
            {
                try
                {
                    if (IsElementPresent(EmpGrpSearchBox))
                    {
                        WaitElementToBeClickable(EmpGrpSearchBox);
                        ClickElement(EmpGrpSearchBox);
                        EnterValueTextbox(EmpGrpSearchBox, item);
                        EmpGrpSearchBox.SendKeys(Keys.Enter);
                        Logger.Info("Searched Employee group with name: " + item);
                        WaitElementToBeClickable(AddEmpGrpToSyncGrp);
                        ClickElement(AddEmpGrpToSyncGrp);
                        Logger.Info("Added Employee Group with name: " + item + "to sync group");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Failed to add Employee group with name: " + item + "to sync group");
                    throw;
                }
            }
        }
        #endregion Adding employee groups to sync group methods



        #region Adding device groups to sync group methods

        /// <summary>
        /// Method to add device group to sync group if it is visible
        /// </summary>
        /// <param name="DeviceGrpNames">Device group names</param>
        /// <returns></returns>
        public bool SelectDeviceGrp(string DeviceGrpNames)
        {
            bool isDeviceGrpAddedToSyncGrp = false;
            try
            {
                List<string> deviceGrpName = DeviceGrpNames.Split(',').ToList();

                foreach (var item in deviceGrpName)
                {
                    string deviceGrpXpath = SyncLocators.AddVisibleDeviceGrpToSyncGrp.Replace("#DEVICEGRPNAME", item);
                    var deviceGrpToSelect = _driver.FindElement(By.XPath(deviceGrpXpath));

                    if (deviceGrpToSelect.Displayed && deviceGrpToSelect.Enabled)
                    {
                        WaitElementToBeClickable(deviceGrpToSelect);
                        ScrollToView(deviceGrpToSelect);
                        ClickElement(deviceGrpToSelect);
                        isDeviceGrpAddedToSyncGrp = true;
                        Logger.Info("Device Group:" + item + "added to Sync Group Successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                isDeviceGrpAddedToSyncGrp = false;
                Logger.Error(ex, "Unable to add Device Groups:" + DeviceGrpNames + "to sync group");
                throw;
            }

            return isDeviceGrpAddedToSyncGrp;
        }

        /// <summary>
        /// Method to add device group to sync group after searching the device group from search box
        /// </summary>
        /// <param name="DeviceGrpNames">Device group names</param>
        public void SearchAndAddDeviceGrpToSyncGrp(string DeviceGrpNames)
        {
            List<string> deviceGrpName = DeviceGrpNames.Split(',').ToList();

            foreach (var item in deviceGrpName)
            {
                try
                {
                    if (IsElementPresent(DeviceGrpSearchBox))
                    {
                        WaitElementToBeClickable(DeviceGrpSearchBox);
                        ClickElement(DeviceGrpSearchBox);
                        EnterValueTextbox(DeviceGrpSearchBox, item);
                        DeviceGrpSearchBox.SendKeys(Keys.Enter);
                        Logger.Info("Searched Device group with name: " + item);
                        WaitElementToBeClickable(AddDeviceGrpToSyncGrp);
                        ClickElement(AddDeviceGrpToSyncGrp);
                        Logger.Info("Added Device Group with name: " + item + "to sync group");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Failed to add Device group with name: " + item + "to sync group");
                    throw;
                }
            }
        }
        #endregion Adding device groups to sync group methods

        /// <summary>
        /// Method enter sync group name in the text box
        /// </summary>
        /// <param name="SyncGrpName">Sync Group name</param>
        public void EnterSyncGrpName(string SyncGrpName = null)
        {
            try
            {
                WaitForElementPresent(SyncGrpNameTxtBox);
                if (SyncGrpName == null)
                {
                    EnterValueTextbox(SyncGrpNameTxtBox, "AutoSyncGrp" + DateTime.Now);
                    Logger.Info("Able to enter name of sync group in sync group text box");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to enter name of sync group in sync group text box");
                throw;
            }
        }

        /// <summary>
        /// Method clicks on "Sync" button 
        /// </summary>
        public void ClickSyncGrpSaveBtn()
        {
            try
            {
                if(IsElementPresent(CreateSyncBtn))
                {
                    ClickElement(CreateSyncBtn);
                    Logger.Info("Able to click on create sync button");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to click on create sync button");
                throw;
            }
        }
    }
}