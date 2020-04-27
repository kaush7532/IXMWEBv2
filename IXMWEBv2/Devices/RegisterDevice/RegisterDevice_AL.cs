using IXMWEBv2.Constants;
using IXMWEBv2.PageObjects.DevicePageObjects;
using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            try
            {
                result = registerDevicePO.IsDeviceDiscoveryPageValid();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Invalid UI for device discovery page");
                throw;
            }
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
        /// Method to Search device using different modes of network
        /// </summary>
        /// <param name="autoDiscover">true if want to do autodiscover</param>
        /// <param name="startIp">start IP value</param>
        /// <param name="endIp">end IP value</param>
        /// <param name="port">port value</param>
        /// <param name="ssl">true if want to enable ssl mode</param>
        public List<DiscoveredDevicesUI> SearchDevice(bool autoDiscover = false, string startIp = null, string endIp = null, string port = null, bool ssl = false)
        {
            try
            {
                if (IsAddDeviceDiscoveryUIValid())
                {
                    //Autodiscover
                    if (autoDiscover)
                    {
                        Logger.Info("Search device by auto discover mode");
                        registerDevicePO.SelectAutoDiscoverOption();
                    }

                    //single ip mode
                    if (!string.IsNullOrEmpty(startIp) && string.IsNullOrEmpty(endIp))
                    {
                        Logger.Info("Search device by single IP discover mode");
                        registerDevicePO.EnterIpPortAddress(startIp, port: port);
                        registerDevicePO.ClickSearchBtn();
                    }
                    //range mode
                    else if (!string.IsNullOrEmpty(startIp) && !string.IsNullOrEmpty(endIp))
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
                else
                {
                    throw new Exception("Failed to Search device. Device Discover UI not valid");
                }
                Assert.IsTrue(IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader),
                    "Fail: Progress bar not displayed while doing discovery");
                return registerDevicePO.GetDiscoveredDevicesList();
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
        public RegisteredDeviceSummaryUI RegisterDevice(string deviceNameOrIPValue, List<DiscoveredDevicesUI> discoveredDevicesUI)
        {
            try
            {
                if (registerDevicePO.IsSearchSuccessfull())
                {
                    var deviceToRegister = discoveredDevicesUI.Where(x => x.DeviceIpAddress.Equals(deviceNameOrIPValue) || x.DeviceName.Equals(deviceNameOrIPValue)).FirstOrDefault();

                    if (!deviceToRegister.IsAlreadyRegistered)
                    {
                        registerDevicePO.ClickRegisterOnSearchedDevicePg(deviceToRegister);

                        //Enter device name and device group name
                        if (registerDevicePO.IsDeviceRegisterPageValid())
                        {
                            registerDevicePO.SetDeviceName(deviceNameOrIPValue + deviceToRegister.DeviceSerial);
                            registerDevicePO.SetDeviceGroupName();

                            //Click register button and wait for progress bar to disappear
                            registerDevicePO.ClickRegisterOnDeviceRegForm();
                            Assert.IsTrue(IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader), "Fail: Progress bar not shown on register device");
                        }
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
            return registerDevicePO.CompleteDeviceRegisteredPopup();
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
        public List<RegisteredDeviceSummaryUI> BulkRegisterDevice(string deviceNamePattern = null, string changeDeviceName = null, string deviceGrpName = null)
        {
            List<RegisteredDeviceSummaryUI> listOfRegisteredDevices = new List<RegisteredDeviceSummaryUI>();
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

                            //Enter device name and device group name
                            if (registerDevicePO.IsDeviceRegisterPageValid())
                            {
                                registerDevicePO.SetDeviceName();

                                registerDevicePO.SetDeviceGroupName(deviceGrpName);

                                //Click register button and wait for progress bar to disappear
                                registerDevicePO.ClickRegisterOnDeviceRegForm(true);
                                Assert.IsTrue(IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader), "Fail: Progress bar not shown on register device");
                            }
                            var continueRegistration = registerDevicePO.ClickAddNewToContinueRegistration();
                            listOfRegisteredDevices.Add(continueRegistration);

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
            return listOfRegisteredDevices;
        }
    }
}