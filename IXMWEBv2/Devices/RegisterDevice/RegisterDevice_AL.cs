using IXMWEBv2.Constants;
using IXMWEBv2.Models;
using IXMWEBv2.PageObjects.DevicePageObjects;
using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Utils;
using IXMWEBv2.WebDriverFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IXMWEBv2.Devices.RegisterDevice
{
    public class RegisterDevice_AL
    {
        private RegisterDevice_PO registerDevicePO;
        public static string deviceToRegisterName = null;

        public RegisterDevice_AL()
        {
            registerDevicePO = new RegisterDevice_PO();
        }

        public bool IsAddDeviceDiscoveryUIValid()
        {
            bool result = false;
            return result;
        }
        public bool IsAddDeviceRegisterUIValid()
        {
            bool result = false;
            return result;
        }
        public bool IsAddDeviceSummaryUIValid()
        {
            bool result = false;
            return result;
        }


        /// <summary>
        /// Method to validate UI elements of Discover device page
        /// </summary>
        /// <returns>true if UI is valid else false</returns>
        public bool IsDeviceRegistrationPageUIValid()
        {
            try
            {
                return registerDevicePO.IsDeviceRegistrationPageValid();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Invalid UI for device discovery page");
                throw;
            }
        }

        /// <summary>
        /// Method to Search device using different modes of network
        /// </summary>
        /// <param name="autoDiscover">true if want to do autodiscover</param>
        /// <param name="startIp">start IP value</param>
        /// <param name="endIp">end IP value</param>
        /// <param name="port">port value</param>
        /// <param name="ssl">true if want to enable ssl mode</param>
        public void SearchDevice(bool autoDiscover = false, string startIp = null, string endIp = null, string port = null, bool ssl = false)
        {
            try
            {
                //Autodiscover
                if (autoDiscover)
                {
                    Logger.Info("Search device by auto discover mode");
                    //Enable auto discover
                    registerDevicePO.SelectAutoDiscoverOption();
                    //IXMWebUtils.IsProgressBarShown(false, CommonLocators.IXMLoader);
                }

                //single ip mode
                if (!String.IsNullOrEmpty(startIp) && String.IsNullOrEmpty(endIp))
                {
                    Logger.Info("Search device by single IP discover mode");
                    registerDevicePO.EnterIpPortAddress(startIp, port: port);
                    registerDevicePO.ClickSearchBtn();
                }
                //range mode
                else if (!String.IsNullOrEmpty(startIp) && !String.IsNullOrEmpty(endIp))
                {
                    Logger.Info("Search device by start IP and end IP range discover mode");
                    registerDevicePO.EnterIpPortAddress(startIp, endIp: endIp, port: port);
                    registerDevicePO.ClickSearchBtn();
                }
                if (ssl)
                {
                    Logger.Info("Search device by SSL discover mode");
                    registerDevicePO.SelectSSLModeDiscoveryOption();
                    registerDevicePO.ClickSearchBtn();
                }
                Logger.Info("Search device successful", Module.DeviceModule);

            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Autodiscover search failed");
                throw;
            }
        }

        /// <summary>
        /// Prerequisite: Device name or ip must be unique
        /// Method to register device.
        /// </summary>
        /// <param name="deviceNameOrIPValue">unique device name/ip/serial value to register</param>
        public DeviceOperations_PO RegisterDevice(string deviceNameOrIPValue)
        {
            try
            {
                if (registerDevicePO.IsSearchSuccessfull())
                {
                    var discoveredDevices = registerDevicePO.GetDiscoveredDevicesList();

                    var deviceToRegister = discoveredDevices.Where(x => x.DeviceIpAddress.Equals(deviceNameOrIPValue) || x.DeviceName.Equals(deviceNameOrIPValue)).FirstOrDefault();

                    if (!deviceToRegister.IsAlreadyRegistered)
                    {
                        registerDevicePO.ClickRegisterOnSearchedDevicePg(deviceToRegister);

                        //Enter device name and device group name
                        registerDevicePO.SetDeviceName(deviceNameOrIPValue);
                        registerDevicePO.SetDeviceGroupName("Simulator");

                        //Click register button and wait for progress bar to disappear
                        registerDevicePO.ClickRegisterOnDeviceRegForm();
                        Assert.IsTrue(IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader), "Fail: Progress bar not shown on register device");
                    }
                    else
                    {
                        Logger.Info("Device " + deviceNameOrIPValue + " is already registered");
                        throw new Exception("Device '" + deviceNameOrIPValue + "' is already registered with IXM web");
                    }
                }
                else
                {
                    Logger.Info("No Device found");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Click Register device button fails");
                throw;
            }
            return registerDevicePO.CloseDeviceRegisteredPopup();
        }


        public void ContinueDeviceRegistration()
        {
            try
            {
                registerDevicePO.ClickAddNewToContinueRegistration();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to continue after device registration");
                throw;
            }
        }

        /// <summary>
        /// Prerequisite: Device name or ip must be unique
        /// Method to register device.
        /// </summary>
        /// <param name="deviceNameOrIPValue">unique device name/ip/serial value to register</param>
        public void BulkRegisterDevice(string deviceNamePattern = null, string changeDeviceName = null, string deviceGrpName = null)
        {
            try
            {
                if (registerDevicePO.IsSearchSuccessfull())
                {

                    var currentPageDevices = registerDevicePO.GetDiscoveredDevicesList();
                    if (!string.IsNullOrEmpty(deviceNamePattern))
                    {
                        currentPageDevices = currentPageDevices.Where(x => x.DeviceName.StartsWith(deviceNamePattern)).ToList();
                    }
                    currentPageDevices = currentPageDevices.Where(x => x.IsAlreadyRegistered == false).ToList();
                    Logger.Info("Total devices to register: " + currentPageDevices.Count);
                    foreach (var device in currentPageDevices)
                    {
                        try
                        {
                            registerDevicePO.ClickRegisterOnSearchedDevicePg(device);

                            registerDevicePO.SetDeviceName();

                            registerDevicePO.SetDeviceGroupName(deviceGrpName);                            

                            registerDevicePO.ClickRegisterOnDeviceRegForm();

                            Assert.IsTrue(IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader), "Fail: Progress bar not shown on register device");

                            registerDevicePO.ClickAddNewToContinueRegistration();

                            Thread.Sleep(3000);
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex, "Failed in loop of register device" + deviceToRegisterName);
                            throw;

                        }
                    }
                }
                else
                {
                    Logger.Info("No Device found");
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Click Register device button fails");
                throw;
            }
        }
    }
}
