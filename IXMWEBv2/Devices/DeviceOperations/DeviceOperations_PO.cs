using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Resources.Locators.DeviceTile;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using System;
using System.Threading;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using IXMWEBv2.Models.DBModels;
using IXMWEBv2.Devices.DeviceOperations;
using IXMWEBv2.Devices.Configurations.Overview;

namespace IXMWEBv2.PageObjects.DevicePageObjects
{
    public class DeviceOperations_PO : GenericBasePage
    {
        public DeviceOperations_PO()
        {
            PageFactory.InitElements(_driver, this);
        }

        #region Declaration: DeviceListPage        

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.DeviceListLink)]
        private IWebElement DeviceListLink { get; set; }

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.DeviceGroupsLink)]
        private IWebElement DeviceGroupsListLink { get; set; }

        [FindsBy(How = How.XPath, Using = DeviceOperationsLocators.DeviceStatus)]
        private IWebElement DeviceStatus { get; set; }

        [FindsBy(How = How.XPath, Using = DeviceOperationsLocators.DeviceListItems)]
        private IList<IWebElement> DeviceListItems { get; set; }

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.DeviceListGridID)]
        private IWebElement DeviceListItemsGridId { get; set; }

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.DeviceListItemToSelect)]
        private IWebElement DeviceToSelect { get; set; }

        #endregion Declaration: DeviceListPage

        #region Declaration: DeviceListPageButton        

        [FindsBy(How = How.XPath, Using = DeviceOperationsLocators.DeleteBtn)]
        private IWebElement DeleteBtn { get; set; }

        [FindsBy(How = How.XPath, Using = DeviceOperationsLocators.RebootBtn)]
        private IWebElement RebootBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = DeviceOperationsLocators.SearchBtn)]
        private IWebElement SearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = DeviceOperationsLocators.AddDeviceBtn)]
        private IWebElement AddDeviceBtn { get; set; }

        [FindsBy(How = How.XPath, Using = DeviceOperationsLocators.BroadcastBtn)]
        private IWebElement BroadcastBtn { get; set; }

        [FindsBy(How = How.XPath, Using = DeviceOperationsLocators.FirmwareupdateBtn)]
        private IWebElement FirmwareupdateBtn { get; set; }

        [FindsBy(How = How.XPath, Using = DeviceOperationsLocators.FactoryDefaultBtn)]
        private IWebElement FactoryDefaultBtn { get; set; }



        #endregion Declaration: DeviceListPageButton

        #region Declaration: DeviceListPage Msg/text boxes

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.DeleteWindow)]
        private IWebElement DeleteWindow { get; set; }

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.PasswordTxt)]
        private IWebElement DeletePasswordTxtbox { get; set; }

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.RebootWindow)]
        private IWebElement RebootWindow { get; set; }


        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.DeleteBtnOnWindow)]
        private IWebElement DeleteBtnOnWindow { get; set; }

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.CancelBtnOnWindow)]
        private IWebElement CancelBtnOnWindow { get; set; }



        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.KendoMsgWindow)]
        private IWebElement KendoMsgWindow { get; set; }

        [FindsBy(How = How.XPath, Using = DeviceOperationsLocators.KendoMsgTxt)]
        private IWebElement KendoMsgTxtValue { get; set; }

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.KendoMsgOKBtn)]
        private IWebElement KendoMsgOkBtn { get; set; }

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.RebootBtnOnWindow)]
        private IWebElement RebootBtnOnWindow { get; set; }

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.CancelBtnOnRebootWindow)]
        private IWebElement CancelBtnOnRebootWindow { get; set; }

        [FindsBy(How = How.Id, Using = DeviceOperationsLocators.SearchTxtBox)]
        private IWebElement SearchTxtBox { get; set; }



        #endregion Declaration: DeviceListPage Msg/Text boxes

        #region DeviceConfiguration details
        [FindsBy(How = How.Id, Using = OverviewTabLocators.OverviewTab)]
        private IWebElement Overviewtab { get; set; }
        #endregion

        /// <summary>
        /// Validate UI elements of device list page
        /// </summary>
        /// <returns>true if valid UI else false</returns>
        public bool IsDevicePageLoaded()
        {
            bool flag = false;
            int waitTime = 7;
            try
            {
                Thread.Sleep(3000);
                List<IWebElement> eleList = new List<IWebElement>
                {
                    DeviceGroupsListLink,
                    DeviceListLink,
                    DeleteBtn,
                    RebootBtn,
                    SearchBtn,
                    AddDeviceBtn,
                    BroadcastBtn,
                    FirmwareupdateBtn,
                    FactoryDefaultBtn,
                    Overviewtab
                };

                flag = AreElementsPresent(eleList, waitTime);


                Logger.Info("Validating Device Tab loading and UI");
                if (flag)
                {
                    Logger.Info("Validation success for UI elements buttons and device list grid data.");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Device List page UI elements invalid");
                flag = false;
            }
            return flag;
        }

        //public bool IsDeviceRegistered(string deviceNameOrIPValue)
        //{
        //    bool flag = false;
        //    try
        //    {
        //        string deviceXpath = DeviceActionsLocators.DeviceExist.Replace("#DEVICEPARAM", deviceNameOrIPValue);
        //        IWebElement device = IXMWebUtils.FindElementAcrossPages(DeviceActionsLocators.DeviceListGridID, By.XPath(deviceXpath));
        //        flag = IsElementPresent(device, 2);
        //        HoverWebElement(device);
        //        Logger.Info("Device '" + deviceNameOrIPValue + "' registration on Device List page is " + flag);
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        Logger.Info("Device " + deviceNameOrIPValue + " is not found on device list page.");
        //        flag = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to check if device is registered or not");
        //        throw;
        //    }
        //    return flag;
        //}

        //public bool IsDeviceOnline()
        //{
        //    WaitForVisibleElement(By.XPath(DeviceActionsLocators.DeviceStatus));
        //    return DeviceStatus.Displayed;
        //}

        public string GetDeviceStatus(string deviceNameOrIpvalue)
        {
            string status = null;
            try
            {
                //string deviceXpath = DeviceOperationsLocators.DeviceStatus.Replace("#DEVICEPARAM", deviceNameOrIpvalue);
                //string deviceXpath = DeviceOperationsLocators.DeviceStatus;

                WaitForElementDisappear(By.XPath(CommonLocators.loadingIconSmall), 20);
                //IWebElement ele = _driver.FindElement(By.XPath(DeviceStatus));
                status = DeviceStatus.Text;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to get Device Status from list.");
                throw;
            }

            return status;
        }

        public string GetDeviceStatus()
        {
            string status = null;
            try
            {

                WaitForElementDisappear(By.XPath(CommonLocators.loadingIconSmall), 20);
                status = DeviceStatus.Text;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to get Device Status from list.");
                throw;
            }

            return status;
        }

        public void ClickReboot()
        {
            string msg = string.Empty;
            try
            {
                //click delete button on device list page
                ClickElement(RebootBtn);

                WaitForElementPresent(RebootBtnOnWindow);
                WaitElementToBeClickable(RebootBtnOnWindow);
                ClickElement(RebootBtnOnWindow);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to click Reboot button");
                throw;
            }
        }


        public void ScrollDeviceList()
        {
            try
            {
                ScrollPageList(DeviceListItemsGridId, 1);
                //scroll_Page(DeviceListItems, 100);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Method to select device as per deviceinfo
        /// </summary>
        /// <param name="deviceInfo">device information parameter from db</param>
        /// <returns>true is device is selected else false</returns>
        public bool SelectDevice(DeviceInfo deviceInfo)
        {
            bool isselected = false;
            try
            {
                string deviceXpath = DeviceOperationsLocators.DeviceListItemToSelect.Replace("#DEVICEPARAM", deviceInfo.SerialNo);
                var deviceToSelect = _driver.FindElement(By.Id(deviceXpath));
                if (GetSelectedDeviceSerial().Equals(deviceInfo.SerialNo, StringComparison.InvariantCultureIgnoreCase))
                {
                    Logger.Info(string.Format("Device {0} is already selected", deviceInfo.DeviceName));
                    return isselected = true;
                };

                if (deviceToSelect.Displayed)
                {
                    WaitElementToBeClickable(deviceToSelect);
                    ScrollToView(deviceToSelect);
                    ClickElement(deviceToSelect);
                    WaitForElementPresent(Overviewtab);
                    isselected = true;
                    Logger.Info("Device '" + deviceInfo.DeviceName + "' selected successfully.");
                }
            }
            catch (Exception ex)
            {
                isselected = false;
                Logger.Error(ex, "Failed to select device: " + deviceInfo.DeviceName);
                throw;
            }
            return isselected;
        }

        /// <summary>
        /// Method to get SelectedDevice
        /// </summary>
        /// <returns></returns>
        public string GetSelectedDeviceSerial()
        {
            string serialno = null;
            try
            {
                List<IWebElement> selected = _driver.FindElements(By.XPath(DeviceOperationsLocators.SelectedDevice)).ToList();

                foreach (var item in selected)
                {
                    if (!string.IsNullOrEmpty(item.GetAttribute("id")))
                    {
                        serialno = item.GetAttribute("id");
                        break;
                    }
                }
                serialno = serialno.Replace("deviceName_", "");
                Logger.Info("Selected device serial is " + serialno);

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "No element found for SelectedDevice");
                throw;
            }
            return serialno;
        }


        public List<DeviceListModel> GetDeviceListDetails()
        {
            List<DeviceListModel> list = new List<DeviceListModel>();
            try
            {

                foreach (var item in DeviceListItems)
                {
                    var arr = item.Text.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    list.Add(new DeviceListModel
                    {
                        ProductType = arr[0],
                        DeviceName = arr[1],
                        DeviceSerial = arr[2]
                    });
                    Logger.Info(string.Format("DeviceList has {0}, {1}, {2}", arr[0], arr[1], arr[2]));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed in getting device list details such as productype, devicename and serial");
                throw;
            }
            return list;
        }

        /// <summary>
        /// Bug already logged. Search button doesn't work rather user Enter key
        /// Method to Search device based on serial, name, ip address 
        /// </summary>
        /// <param name="deviceinfo"></param>
        public List<DeviceListModel> SearchDevice(string deviceinfo)
        {
            try
            {
                WaitElementToBeClickable(SearchBtn);
                ClickElement(SearchBtn);
                EnterValueTextbox(SearchTxtBox, deviceinfo);
                SearchTxtBox.SendKeys(Keys.Enter);

                Logger.Info("Searched devices with criteria: " + deviceinfo);

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Search Device");
                throw;
            }
            return GetDeviceListDetails();
        }

        public RegisterDevice_PO ClickAddDevice()
        {
            try
            {
                WaitElementToBeClickable(AddDeviceBtn);
                ClickElement(AddDeviceBtn);
                Logger.Info("Clicked Add Device button");
                if (!IsElementPresent(By.Id(RegisterDeviceLocators.AddDeviceDiscoverySection), 5))
                {
                    throw new Exception("Register Device dialog not visible to proceed with device registration");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Click on AddDevice button");
                throw;
            }
            return new RegisterDevice_PO();
        }

        public string ClickDelete(string password)
        {
            string msg = string.Empty;
            try
            {
                //click delete button on device list page

                ClickElement(DeleteBtn);

                //enter password on delete popup and click on delete button
                if (IsElementPresent(DeleteWindow))
                {
                    EnterValueTextbox(DeletePasswordTxtbox, password);
                    ClickElement(DeleteBtnOnWindow);
                    if (IsElementPresent(KendoMsgWindow))
                    {
                        msg = KendoMsgTxtValue.Text;
                        ClickElement(KendoMsgOkBtn);
                    }
                }
                else
                {
                    throw new Exception("Fail: Delete window not visible to enter password.");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to click Delete button");
                throw;
            }
            return msg;
        }
    }
}
