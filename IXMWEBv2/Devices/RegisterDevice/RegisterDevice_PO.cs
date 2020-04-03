using IXMWEBv2.Constants;
using IXMWEBv2.Devices.RegisterDevice;
using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Resources.Locators.DeviceTile;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace IXMWEBv2.PageObjects.DevicePageObjects
{
    public class RegisterDevice_PO : GenericBasePage
    {
        public RegisterDevice_PO()
        {
            PageFactory.InitElements(_driver, this);
        }




        #region Declaration: RegisterDevice

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.SearchBtn)]
        private IWebElement SearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.EthernetSection)]
        private IWebElement EthernetSection { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.SerialSection)]
        private IWebElement SerialSection { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.AutoDiscoverRadioBtn)]
        private IWebElement AutoDiscoverBtn { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.DiscoveredDevices)]
        private IList<IWebElement> DiscoveredDevices { get; set; }



        #region Declaration: Start IP, End ip and port

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.PortNo)]
        private IWebElement portNo { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.StartIpOctet1)]
        private IWebElement startIpOctet1Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.StartIpOctet2)]
        private IWebElement startIpOctet2Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.StartIpOctet3)]
        private IWebElement startIpOctet3Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.StartIpOctet4)]
        private IWebElement startIpOctet4Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.EndIpOctet1)]
        private IWebElement endIpOctet1Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.EndIpOctet2)]
        private IWebElement endIpOctet2Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.EndIpOctet3)]
        private IWebElement endIpOctet3Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.EndIpOctet4)]
        private IWebElement endIpOctet4Txt { get; set; }

        [FindsBy(How = How.XPath, Using = CommonLocators.KendoMsgTxt)]
        private IWebElement kendoMsgTxt { get; set; }

        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgOKBtn)]
        private IWebElement kendoMsgOKBtn { get; set; }

        #endregion Declaration: Start IP, End ip and port

        #endregion Declaration: RegisterDevice

        #region Declaration: RegistrationFormDevice

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.RegistrationFormSection)]
        private IWebElement registerForm { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.RegisterBtnDevForm)]
        private IWebElement registerBtnForm { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.DeviceNameTxtBox)]
        private IWebElement deviceNameRegisterForm { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.DeviceGroupTxtBox)]
        private IWebElement deviceGroupNameRegisterForm { get; set; }

        #endregion Declaration: RegistrationFormDevice

        #region Declaration: DeviceRegisteredDetails

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.OkBtn)]
        private IWebElement okBtn { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.AddNewBtnToContinueReg)]
        private IWebElement AddNewBtnToContinueReg { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.SummaryFormSection)]
        private IWebElement SummarySection { get; set; }


        #endregion Declaration: DeviceRegisteredDetails

        #region Device registration page common methods

        /// <summary>
        /// Validate UI elements of page
        /// </summary>
        /// <returns>true if valid UI else false</returns>
        public bool IsDeviceRegistrationPageValid()
        {
            bool flag = false;
            try
            {
                flag = EthernetSection.Displayed
                    && SerialSection.Displayed
                    && SearchBtn.Displayed
                    && portNo.Displayed
                    && startIpOctet1Txt.Displayed
                    && endIpOctet1Txt.Displayed;
                Logger.Info("Validation success for UI elements serial section, ethernet section, search button, port num and start/endip octet");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Device reigstration page UI elements invalid");
                flag = false;
            }
            return flag;
        }

        #endregion Device registration page common methods

        #region Device Discovery section methods





        /// <summary>
        /// Method to turn on AutoDiscovery switch
        /// </summary>
        public void SelectAutoDiscoverOption()
        {
            try
            {
                if (!IsCheckboxActive(CommonUtils.GetCheckBoxId(RegisterDeviceLocators.AutoDiscoverRadioBtn)))
                {
                    ClickElement(AutoDiscoverBtn);
                    Logger.Info("AutoDiscover Button clicked");
                }
                else
                {
                    Logger.Info("AutoDiscover Option already selected");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to turn on Auto Discovery");
                throw;
            }
        }

        /// <summary>
        /// Method to turn on SSL switch
        /// </summary>
        public void SelectSSLModeDiscoveryOption()
        {
            try
            {
                if (!IXMWebUtils.IsSwitchButtonEnabled(_driver, RegisterDeviceLocators.SSLModeSwitchName))
                {
                    WaitForElementPresent(IXMWebUtils.switchXpath, 10);
                    ClickElement(IXMWebUtils.switchXpath);
                    Logger.Info("Toggled SSL Switch button On for device discovery.", Module.DeviceModule.ToString());
                }
                else
                {
                    Logger.Info("SSL Mode is already active.", Module.DeviceModule.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to turn on SSL Mode discovery");
                throw;
            }
        }

        /// <summary>
        /// Click search button on Device registration page
        /// </summary>
        public void ClickSearchBtn()
        {
            try
            {
                WaitForElementPresent(SearchBtn);
                ClickElement(SearchBtn);
                Logger.Info("Clicked Search button on register device page", Module.DeviceModule.ToString());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to click Search button.");
                throw;
            }
        }

        /// <summary>
        /// Method to enter Ip and port value
        /// Can be used for single ip, ip range, different port
        /// </summary>
        /// <param name="startIp">start IP value</param>
        /// <param name="endIp">end IP value</param>
        /// <param name="port">port value</param>
        public void EnterIpPortAddress(string startIp, string endIp = null, string port = null)
        {
            try
            {
                string[] startIpvalue = startIp.Split('.');

                //Make start ip empty if anthing exists
                if (!String.IsNullOrEmpty(startIpOctet1Txt.Text))
                {
                    startIpOctet1Txt.Clear();
                    startIpOctet2Txt.Clear();
                    startIpOctet3Txt.Clear();
                    startIpOctet4Txt.Clear();
                }
                EnterValueTextbox(startIpOctet1Txt, startIpvalue[0]);
                EnterValueTextbox(startIpOctet2Txt, startIpvalue[1]);
                EnterValueTextbox(startIpOctet3Txt, startIpvalue[2]);
                EnterValueTextbox(startIpOctet4Txt, startIpvalue[3]);

                if (!String.IsNullOrEmpty(endIp))
                {
                    string[] endIpvalue = endIp.Split('.');
                    EnterValueTextbox(endIpOctet1Txt, endIpvalue[0]);
                    EnterValueTextbox(endIpOctet2Txt, endIpvalue[1]);
                    EnterValueTextbox(endIpOctet3Txt, endIpvalue[2]);
                    EnterValueTextbox(endIpOctet4Txt, endIpvalue[3]);
                }
                else if (endIpOctet1Txt.Text.Equals(""))
                {
                    endIpOctet1Txt.Clear();
                    endIpOctet2Txt.Clear();
                    endIpOctet3Txt.Clear();
                    endIpOctet4Txt.Clear();
                }
                if (!String.IsNullOrEmpty(port))
                {
                    EnterValueTextbox(portNo, port);
                }
                else if (!portNo.Text.Equals("9734"))
                {
                    EnterValueTextbox(portNo, "9734");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to enter IP address for start and end range");
                throw;
            }
        }

        #endregion Device Discovery section methods

        #region Device Registration Search result page

        /// <summary>
        /// Click on Register button on Device Registration search result
        /// </summary>
        /// <param name="deviceNameOrIpAddress">device name/ip/serial value to register</param>
        public void ClickRegisterOnSearchedDevicePg(DiscoveredDevicesUI deviceToRegister)
        {
            try
            {
                //Find all device xpath
                var allDevices = _driver.FindElements(By.XPath(RegisterDeviceLocators.RegisterBtnDevList));
                //Change deviceToRegister in format to click single device
                string deviceToRegisterText = string.Format("{0}\r\n{1}\r\nIP Address\r\n{2}\r\nMAC ID\r\n{3}",
                    deviceToRegister.DeviceName,
                    deviceToRegister.DeviceSerial,
                    deviceToRegister.DeviceIpAddress,
                    deviceToRegister.DeviceMAC);
                var deviceToClickforReg = allDevices.Where(x => x.Text.Equals(deviceToRegisterText)).FirstOrDefault();

                //click device to register
                ClickElement(deviceToClickforReg);


                Logger.Info("Clicked on Register Button on searched device page for device: "
                    + deviceToRegister.DeviceName, deviceToRegister.DeviceIpAddress);

                WaitForElementPresent(registerForm, 15);
                Logger.Info("Navigated to Device registration form");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to click register button or registration form not visible");
                throw;
            }
        }




        /// <summary>
        /// Method to get discovered device from Register device page
        /// </summary>
        /// <returns>Discovered devices details</returns>
        public List<DiscoveredDevicesUI> GetDiscoveredDevicesList()
        {
            List<DiscoveredDevicesUI> list = new List<DiscoveredDevicesUI>();
            try
            {
                var registeredDevices = _driver.FindElements(By.XPath("//img[@title='Registered']/preceding-sibling::ul//p"));
                List<string> resisteredList = new List<string>();
                if (registeredDevices.Count > 0)
                {
                    resisteredList = registeredDevices.Select(x => x.Text).ToList();
                }


                foreach (var item in DiscoveredDevices)
                {
                    var arr = item.Text.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);

                    list.Add(new DiscoveredDevicesUI
                    {

                        DeviceName = arr[0],
                        DeviceSerial = arr[1],
                        DeviceIpAddress = arr[3],
                        DeviceMAC = arr[5],
                        IsAlreadyRegistered = resisteredList.Any(x => x.Equals("MAC ID\r\n" + arr[5] + "")) ? true : false
                    });
                }
                Logger.Info("Discovered device list successful");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed in getting device list details such as productype, devicename and serial");
                throw;
            }
            return list;
        }

        /// <summary>
        /// Method to check if No Device found is shown or not
        /// </summary>
        /// <returns>true if no deivce found popup is not shown else false</returns>
        public bool IsSearchSuccessfull()
        {
            bool flag = false;
            try
            {
                //Verify no device found
                if (IsElementPresent(kendoMsgTxt, 1))
                {
                    if (kendoMsgTxt.Text.Equals("No device found, try again"))
                    {
                        flag = false;
                        ClickElement(kendoMsgOKBtn);
                        throw new Exception("No device found to register");
                    }
                }
                else
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to get device search result");
                throw;
            }
            Logger.Info("No device found message popup visible: " + !flag);
            return flag;
        }

        ///// <summary>
        ///// Method to get DeviceType e.g. Touch FPL 5 from search result of device discovery
        ///// </summary>
        ///// <param name="deviceNameOrIpAddress">value of deviceIP or deviceName</param>
        ///// <returns>Device type name</returns>
        //public string GetDeviceTypeName(string deviceNameOrIpAddress)
        //{
        //    string deviceType = string.Empty;
        //    try
        //    {
        //        IWebElement device = _driver.FindElement(By.XPath(RegisterDeviceLocators.DeviceType.Replace("#VALUE", deviceNameOrIpAddress)));
        //        Logger.Info("Device Type of '" + deviceNameOrIpAddress + "' is: " + device.Text.Trim());
        //        deviceType = device.Text.Trim();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to get device type for device with property: " + deviceNameOrIpAddress);
        //    }
        //    return deviceType;
        //}

        #endregion Device Registration Search result page

        #region Device Registration form Methods

        /// <summary>
        /// Method clicks register button on device registration form page
        /// </summary>
        public void ClickRegisterOnDeviceRegForm()
        {

            try
            {
                WaitElementToBeClickable(registerBtnForm);
                ClickElement(registerBtnForm);
                Logger.Info("Clicked on Register button on Device Registration form popup");
                if (IsElementPresent(kendoMsgTxt, 5))
                {
                    Logger.Info("Kendo message visible on device registration form section");
                    if (kendoMsgTxt.Text.Equals("Failed to save network configuration settings on device Communication port in use"))
                    {
                        WaitElementToBeClickable(kendoMsgOKBtn);
                        Thread.Sleep(1000);
                        ClickElement(kendoMsgOKBtn, elementname: CommonLocators.KendoMsgOKBtn);
                        Thread.Sleep(1000);
                        ClickElement(registerBtnForm, elementname: RegisterDeviceLocators.RegisterBtnDevForm);
                        //throw new Exception("No device found to register");
                    }
                }
                else
                {

                }


            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to register device. Failed to click Register button on DeviceRegistrationform.");
                throw;
            }



        }

        // <summary>
        // Enter new device group name
        // </summary>
        // <returns>device group name</returns>
        public string SetDeviceGroupName(string deviceGrpName = null)
        {
            try
            {
                var ele = _driver.FindElement(By.Id("uglist"));

                ClickElement(deviceGroupNameRegisterForm);
                SelectItemByVisibleText(ele, deviceGrpName);



                string devGroupName = string.Empty;
                if (string.IsNullOrEmpty(deviceGrpName))
                {
                    devGroupName = "Autogrp" + CommonUtils.GetDateTimeAsString();
                    EnterValueTextbox(deviceGroupNameRegisterForm, devGroupName);
                    var selectGrp = _driver.FindElement(By.XPath(RegisterDeviceLocators.DeviceGroupSelectValue.Replace("#VALUE", devGroupName)));
                    WaitForElementPresent(selectGrp);

                    EnterValueTextbox(deviceGroupNameRegisterForm, Keys.Down + Keys.Enter);
                }
                else
                {
                    devGroupName = deviceGrpName;
                    EnterValueTextbox(deviceGroupNameRegisterForm, devGroupName);
                    EnterValueTextbox(deviceGroupNameRegisterForm, Keys.Down + Keys.Enter);
                }
                Logger.Info("Set DeviceGroupName as: " + devGroupName);

                return devGroupName;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to set device group name value");
                throw;
            }
        }

        /// <summary>
        /// Method to set device name while registration. If null name will not change
        /// If not null then provided deviceName will be set.
        /// </summary>        
        public void SetDeviceName(string deviceName = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(deviceName))
                {
                    string devName = "Auto" + deviceName + CommonUtils.GetDateTimeAsString();
                    EnterValueTextbox(deviceNameRegisterForm, devName);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to set device name value");
                throw;
            }
            Logger.Info("Device Name set to: " + deviceName);
        }

        /// <summary>
        /// Method to close the registered device summary popup
        /// </summary>
        /// <returns>Device List page object</returns>
        public DeviceOperations_PO CloseDeviceRegisteredPopup()
        {
            try
            {
                ClickElement(okBtn);
                Logger.Info("Navigating to DeviceList page to verify if device is successfully registered or not");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to close registered device popup");
            }
            return new DeviceOperations_PO();
        }

        /// <summary>
        /// Method to click AddNew button to continue device registration
        /// </summary>
        public void ClickAddNewToContinueRegistration()
        {
            try
            {
                if (IsElementPresent(SummarySection, 10))
                {
                    WaitElementToBeClickable(AddNewBtnToContinueReg);
                    AddNewBtnToContinueReg = _driver.FindElement(By.XPath(RegisterDeviceLocators.AddNewBtnToContinueReg));
                    ClickElement(AddNewBtnToContinueReg, elementname: RegisterDeviceLocators.AddNewBtnToContinueReg);
                    Logger.Info("Add New clicked for continue of device registration");
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Click on AddNew for continue of device registration");
                throw;
            }
        }

        #endregion Device Registration form Methods
    }
}
