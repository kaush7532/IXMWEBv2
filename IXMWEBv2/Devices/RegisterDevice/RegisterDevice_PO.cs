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

        #region Common Locators

        [FindsBy(How = How.XPath, Using = CommonLocators.KendoMsgTxt)]
        private IWebElement KendoMsgTxt { get; set; }

        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgOKBtn)]
        private IWebElement KendoMsgOKBtn { get; set; }

        #endregion Common Locators

        #region Declaration: DiscoverTab Page
        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.SearchBtn)]
        private IWebElement SearchBtn { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.EthernetRadioBtn)]
        private IWebElement EthernetRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.SerialRadioBtn)]
        private IWebElement SerialRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.AutoDiscoverRadioBtn)]
        private IWebElement AutoDiscoverRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.SearchSSLChkbox)]
        private IWebElement SSLSearchChkBox { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.PortNo)]
        private IWebElement PortNo { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.StartIpOctet1)]
        private IWebElement StartIpOctet1Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.StartIpOctet2)]
        private IWebElement StartIpOctet2Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.StartIpOctet3)]
        private IWebElement StartIpOctet3Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.StartIpOctet4)]
        private IWebElement StartIpOctet4Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.EndIpOctet1)]
        private IWebElement EndIpOctet1Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.EndIpOctet2)]
        private IWebElement EndIpOctet2Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.EndIpOctet3)]
        private IWebElement EndIpOctet3Txt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.EndIpOctet4)]
        private IWebElement EndIpOctet4Txt { get; set; }
        #endregion Declaration: DiscoverTab Page

        #region Declaration: Discovered Device list

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.DiscoveredDevices)]
        private IList<IWebElement> DiscoveredDevices { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.AlreadyRegisteredDevices)]
        private IList<IWebElement> AlreadyRegisteredDevices { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.RegisterBtnDevList)]
        private IList<IWebElement> RegisterBtnDeviceList { get; set; }
        #endregion Declaration: Discovered Device list

        #region Declaration: RegistrationTab Page

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.AddDeviceRegisterSection)]
        private IWebElement RegisterForm { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.RegisterBtn)]
        private IWebElement RegisterBtn { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.DeviceNameTxt)]
        private IWebElement DeviceNameTxtBox { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.DeviceIdTxt)]
        private IWebElement DeviceIdTxtBox { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.DeviceGroupTxt)]
        private IWebElement DeviceGroupNameTxtBox { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.DeviceModeDrpDown)]
        private IWebElement DeviceModeDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.TnAChkbox)]
        private IWebElement DeviceTnAModeChkBox { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.DHCPChkbox)]
        private IWebElement DeviceDHCPStaticChkBox { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.DeviceIpAddrTxt)]
        private IWebElement DeviceIPAddressTxt { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.DevicePortTxt)]
        private IWebElement DevicePortTxtBox { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.DeviceSubnetMaskTxt)]
        private IWebElement DeviceSubnetTxtBox { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.DeviceGatewayTxt)]
        private IWebElement DeviceGatewayTxtBox { get; set; }

        #endregion Declaration: RegistrationFormDevice

        #region Declaration: SummaryTab Page

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.DoneBtn)]
        private IWebElement DoneBtn { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.AddNewBtnToContinueReg)]
        private IWebElement AddNewBtnToContinueReg { get; set; }

        [FindsBy(How = How.Id, Using = RegisterDeviceLocators.AddDeviceSummarySection)]
        private IWebElement SummarySection { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.DeviceInfoItems)]
        private IList<IWebElement> DeviceInfoItemsList { get; set; }

        [FindsBy(How = How.XPath, Using = RegisterDeviceLocators.NetworkInfoItems)]
        private IList<IWebElement> NetworkInfoItemsList { get; set; }

        #endregion Declaration: SummaryTab Page


        #region Methods: Device Discover Page

        /// <summary>
        /// Validate UI elements of device discover page
        /// </summary>
        /// <returns>true if valid UI else false</returns>
        public bool IsDeviceDiscoveryPageValid()
        {
            bool flag = false;
            int waitTime = 7;
            try
            {
                List<IWebElement> eleList = new List<IWebElement>
                {
                    EthernetRadioBtn,
                    AutoDiscoverRadioBtn,
                    SerialRadioBtn,
                    StartIpOctet1Txt,
                    SearchBtn,
                    SSLSearchChkBox,
                    PortNo,
                    EndIpOctet1Txt
                };

                flag = AreElementsPresent(eleList, waitTime);
                if (flag)
                {
                    Logger.Info("Validation success for UI elements serial section, ethernet section, search button, port num and start/endip octet");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Device reigstration page UI elements invalid");
                flag = false;
            }
            return flag;
        }


        /// <summary>
        /// Method to turn on AutoDiscovery switch
        /// </summary>
        public void SelectAutoDiscoverOption()
        {
            try
            {
                if (!IsCheckboxActive(CommonUtils.GetCheckBoxId(RegisterDeviceLocators.AutoDiscoverRadioBtn)))
                {
                    ClickElement(AutoDiscoverRadioBtn);
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
                if (!SSLSearchChkBox.Selected)
                {
                    ClickElement(SSLSearchChkBox);
                }
                //if (!IXMWebUtils.IsSwitchButtonEnabled(_driver, RegisterDeviceLocators.SSLModeSwitchName))
                //{
                //    WaitForElementPresent(IXMWebUtils.switchXpath, 10);
                //    ClickElement(IXMWebUtils.switchXpath);
                //    Logger.Info("Toggled SSL Switch button On for device discovery.", Module.DeviceModule.ToString());
                //}
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
                if (!string.IsNullOrEmpty(StartIpOctet1Txt.Text))
                {
                    StartIpOctet1Txt.Clear();
                    StartIpOctet2Txt.Clear();
                    StartIpOctet3Txt.Clear();
                    StartIpOctet4Txt.Clear();
                }
                EnterValueTextbox(StartIpOctet1Txt, startIpvalue[0]);
                EnterValueTextbox(StartIpOctet2Txt, startIpvalue[1]);
                EnterValueTextbox(StartIpOctet3Txt, startIpvalue[2]);
                EnterValueTextbox(StartIpOctet4Txt, startIpvalue[3]);

                if (!string.IsNullOrEmpty(endIp))
                {
                    string[] endIpvalue = endIp.Split('.');
                    EnterValueTextbox(EndIpOctet1Txt, endIpvalue[0]);
                    EnterValueTextbox(EndIpOctet2Txt, endIpvalue[1]);
                    EnterValueTextbox(EndIpOctet3Txt, endIpvalue[2]);
                    EnterValueTextbox(EndIpOctet4Txt, endIpvalue[3]);
                }
                else if (EndIpOctet1Txt.Text.Equals(""))
                {
                    EndIpOctet1Txt.Clear();
                    EndIpOctet2Txt.Clear();
                    EndIpOctet3Txt.Clear();
                    EndIpOctet4Txt.Clear();
                }
                if (!string.IsNullOrEmpty(port))
                {
                    EnterValueTextbox(PortNo, port);
                }
                else if (!PortNo.Text.Equals("9734"))
                {
                    EnterValueTextbox(PortNo, "9734");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to enter IP address for start and end range");
                throw;
            }
        }

        /// <summary>
        /// Click on Register button on Device Registration search result
        /// </summary>
        /// <param name="deviceNameOrIpAddress">device name/ip/serial value to register</param>
        public void ClickRegisterOnSearchedDevicePg(DiscoveredDevicesUI deviceToRegister)
        {
            try
            {

                //Change deviceToRegister in format to click single device
                string deviceToRegisterText = string.Format("{0}\r\n{1}\r\nIP Address\r\n{2}\r\nMAC ID\r\n{3}",
                    deviceToRegister.DeviceName,
                    deviceToRegister.DeviceSerial,
                    deviceToRegister.DeviceIpAddress,
                    deviceToRegister.DeviceMAC);
                var deviceToClickforReg = RegisterBtnDeviceList.Where(x => x.Text.Equals(deviceToRegisterText)).FirstOrDefault();

                //click device to register
                ClickElement(deviceToClickforReg);


                Logger.Info("Clicked on Register Button on searched device page for device: "
                    + deviceToRegister.DeviceName, deviceToRegister.DeviceIpAddress);

                WaitForElementPresent(RegisterForm, 15);
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
                //Get already registered devices
                List<string> registeredList = new List<string>();
                if (AlreadyRegisteredDevices.Count > 0)
                {
                    registeredList = AlreadyRegisteredDevices.Select(x => x.Text).ToList();
                }

                //Loop to fill model of all discovered devices
                foreach (var item in DiscoveredDevices)
                {
                    var arr = item.Text.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);

                    list.Add(new DiscoveredDevicesUI
                    {
                        DeviceName = arr[0],
                        DeviceSerial = arr[1],
                        DeviceIpAddress = arr[3],
                        DeviceMAC = arr[5],
                        IsAlreadyRegistered = registeredList.Any(x => x.Equals("MAC ID\r\n" + arr[5] + "")) ? true : false
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
                if (IsElementPresent(KendoMsgTxt, 1))
                {
                    if (KendoMsgTxt.Text.Equals(RegisterDeviceLocators.NoDeviceFoundResource))
                    {
                        flag = false;
                        ClickElement(KendoMsgOKBtn);
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

        #endregion

        #region Methods: Device Register Page

        /// <summary>
        /// Method validates UI elements for Register tab during registration
        /// </summary>
        /// <returns></returns>
        public bool IsDeviceRegisterPageValid()
        {
            bool flag = false;
            int waitTime = 7;
            try
            {
                List<IWebElement> eleList = new List<IWebElement>
                {
                    RegisterForm,
                    DeviceNameTxtBox,
                    DeviceGroupNameTxtBox,
                    DeviceIdTxtBox,
                    DeviceModeDropDown,
                    DeviceTnAModeChkBox,
                    DeviceDHCPStaticChkBox,
                    DeviceIPAddressTxt,
                    DevicePortTxtBox,
                    DeviceSubnetTxtBox,
                    DeviceGatewayTxtBox,
                    RegisterBtn
                };


                flag = AreElementsPresent(eleList, waitTime);
                if (flag)
                {
                    Logger.Info("Validation success for UI elements of Register section (DeviceRegistration)");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Device registration page UI elements invalid");
                flag = false;
            }
            return flag;
        }

        ///<summary>
        /// Enter new device group name
        ///</summary>
        /// <returns>device group name</returns>
        public string SetDeviceGroupName(string deviceGrpName = null)
        {
            try
            {
                var ele = _driver.FindElement(By.Id("uglist"));

                ClickElement(DeviceGroupNameTxtBox);

                string devGroupName = string.Empty;
                if (string.IsNullOrEmpty(deviceGrpName))
                {
                    devGroupName = "Autogrp" + CommonUtils.GetDateTimeAsString("ddMMyyyyhhmmss");
                    EnterValueTextbox(DeviceGroupNameTxtBox, devGroupName);
                    var selectGrp = _driver.FindElement(By.XPath(RegisterDeviceLocators.DeviceGroupSelectValue.Replace("#VALUE", devGroupName)));
                    WaitForElementPresent(selectGrp);
                    ClickElement(selectGrp);
                    //EnterValueTextbox(DeviceGroupNameRegisterForm, Keys.Down + Keys.Enter);
                }
                else
                {
                    SelectItemByVisibleText(ele, deviceGrpName);
                    devGroupName = deviceGrpName;
                    EnterValueTextbox(DeviceGroupNameTxtBox, devGroupName);
                    EnterValueTextbox(DeviceGroupNameTxtBox, Keys.Down + Keys.Enter);
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
                    string devName = "Auto" + deviceName + CommonUtils.GetDateTimeAsString("ddMMyyyy");
                    EnterValueTextbox(DeviceNameTxtBox, devName);
                }
                else
                {
                    string devName = "Auto" + CommonUtils.GetDateTimeAsString("ddMMyyyy");
                    EnterValueTextbox(DeviceNameTxtBox, devName);
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
        /// Method to set device Id while registration. Default value 0 in not passed
        /// </summary>
        /// <param name="deviceId"></param>
        public void SetDeviceId(int deviceId = 0)
        {
            string devId = string.Empty;
            try
            {
                devId = Convert.ToString(deviceId);
                EnterValueTextbox(DeviceIdTxtBox, devId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to set device Id value");
                throw;
            }
            Logger.Info("Device Name set to: " + devId);
        }

        /// <summary>
        /// Method clicks register button on device registration form page
        /// </summary>
        public void ClickRegisterOnDeviceRegForm(bool IsBulkRegisteration = false)
        {
            try
            {
                WaitElementToBeClickable(RegisterBtn);
                ClickElement(RegisterBtn);
                Logger.Info("Clicked on Register button on Device Registration form popup");

                //Case to handle bulk device registration
                if (IsBulkRegisteration)
                {                    
                    if (IsElementPresent(KendoMsgTxt, 5))
                    {
                        Logger.Info("Kendo message visible on device registration form section");
                        if (KendoMsgTxt.Text.Equals("Failed to save network configuration settings on device Communication port in use"))
                        {
                            WaitElementToBeClickable(KendoMsgOKBtn);
                            Thread.Sleep(1000);
                            ClickElement(KendoMsgOKBtn, elementname: CommonLocators.KendoMsgOKBtn);
                            Thread.Sleep(1000);
                            ClickElement(RegisterBtn, elementname: RegisterDeviceLocators.RegisterBtn);
                            //throw new Exception("No device found to register");
                        }
                    }
                    else
                    {
                        Logger.Info("No Error message visible on clicking Register button");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to register device. Failed to click Register button on DeviceRegistrationform.");
                throw;
            }
        }

        #endregion

        #region Methods: Device Summary Page

        /// <summary>
        /// Method to validate UI of Summary page
        /// </summary>
        /// <returns></returns>
        public bool IsDeviceSummaryPageValid()
        {
            bool flag = false;
            int waitTime = 15;
            try
            {
                List<IWebElement> eleList = new List<IWebElement>
                {
                    SummarySection,
                    AddNewBtnToContinueReg,
                    DoneBtn
                };

                flag = AreElementsPresent(eleList, waitTime);
                if (flag)
                {
                    Logger.Info("Validation success for UI elements of Summary section (DeviceRegistration)");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Device Registration Summary page UI elements invalid");
                flag = false;
            }
            return flag;
        }

        public RegisteredDeviceSummaryUI GetSummaryDetails()
        {
            RegisteredDeviceSummaryUI summarydetails = new RegisteredDeviceSummaryUI();

            try
            {
                foreach (var item in DeviceInfoItemsList)
                {
                    string[] arr = item.Text.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    //list.Add(new KeyValuePair<DeviceInformationSummaryUI, string>(deviceInfo.DeviceName, arr[1])); 
                    if (arr[0].Equals("Device Name"))
                    {
                        summarydetails.deviceInfo.DeviceName = arr[1];
                    }
                    else if (arr[0].Equals("Model Name"))
                    {
                        summarydetails.deviceInfo.ModelName = arr[1];
                    }
                    else if (arr[0].Equals("Serial Number"))
                    {
                        summarydetails.deviceInfo.SerialNumber = arr[1];
                    }
                    else if (arr[0].Equals("Firmware Version"))
                    {
                        summarydetails.deviceInfo.FirmwareVersion = arr[1];
                    }
                    else if (arr[0].Equals("Transaction capacity"))
                    {
                        summarydetails.deviceInfo.TransactionCapacity = arr[1];
                    }
                    else if (arr[0].Equals("User Capacity (1:N)"))
                    {
                        summarydetails.deviceInfo.UserCapacity1N = arr[1];
                    }
                    else if (arr[0].Equals("User Capacity (1:1)"))
                    {
                        summarydetails.deviceInfo.UserCapaicty11 = arr[1];
                    }
                }

                foreach (var item in NetworkInfoItemsList)
                {
                    string[] arr = item.Text.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);
                    
                    if (arr[0].Equals("Comm Mode"))
                    {
                        summarydetails.networkInfo.CommMode = arr[1];
                    }
                    else if (arr[0].Equals("IP Mode"))
                    {
                        summarydetails.networkInfo.IPMode = arr[1];
                    }
                    else if (arr[0].Equals("IP Address"))
                    {
                        summarydetails.networkInfo.IP = arr[1];
                    }
                    else if (arr[0].Equals("Subnet Mask"))
                    {
                        summarydetails.networkInfo.Subnet = arr[1];
                    }
                    else if (arr[0].Equals("Gateway"))
                    {
                        summarydetails.networkInfo.GateWay = arr[1];
                    }
                    else if (arr[0].Equals("MAC ID"))
                    {
                        summarydetails.networkInfo.MacID = arr[1];
                    }
                    else if (arr[0].Equals("DNS"))
                    {
                        summarydetails.networkInfo.DNS = arr[1];
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Get summary details from UI");
                throw;
            }
            return summarydetails;
        }

        /// <summary>
        /// Method to close the registered device summary popup
        /// </summary>
        /// <returns>Device List page object</returns>
        public RegisteredDeviceSummaryUI CompleteDeviceRegisteredPopup()
        {
            RegisteredDeviceSummaryUI summaryDetails = new RegisteredDeviceSummaryUI();
            try
            {
                if (IsDeviceSummaryPageValid())
                {
                    summaryDetails = GetSummaryDetails();
                    ClickElement(DoneBtn);
                    Logger.Info("Navigating to DeviceList page to verify if device is successfully registered or not");
                }
                else
                {
                    throw new Exception("Failed to Close Device Registration popup. Unable to view summary page");
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to close registered device popup");
            }
            return summaryDetails;
        }

        /// <summary>
        /// Method to click AddNew button to continue device registration
        /// </summary>
        public RegisteredDeviceSummaryUI ClickAddNewToContinueRegistration()
        {
            RegisteredDeviceSummaryUI summaryDetails = new RegisteredDeviceSummaryUI();
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
            return summaryDetails;
        }

        #endregion

        #region Device Registration Search result page



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






        #endregion Device Registration form Methods
    }
}
