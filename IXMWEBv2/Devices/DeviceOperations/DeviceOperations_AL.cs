using IXMWEBv2.Constants;
using IXMWEBv2.Models.DBModels;
using IXMWEBv2.PageObjects.DevicePageObjects;
using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Utils;
using System;
using System.Linq;

namespace IXMWEBv2.AccessLayer.DeviceAccessLayers
{
    public class DeviceOperations_AL
    {
        private DeviceOperations_PO deviceOperationPO;

        public DeviceOperations_AL()
        {
            deviceOperationPO = new DeviceOperations_PO();
            if (!deviceOperationPO.IsDevicePageLoaded())
            {
                Logger.Error("Devices tab UI not loaded", Module.DeviceModule);
                throw new Exception("Devices tab UI not loaded");
            }
        }

        /// <summary>
        /// Contructor to select device based on name or IP
        /// </summary>
        /// <param name="deviceIpOrNameToSelect"></param>
        public DeviceOperations_AL(DeviceInfo deviceInfofromDb)
        {
            deviceOperationPO = new DeviceOperations_PO();
            bool isdevicepageloaded = false;
            isdevicepageloaded = deviceOperationPO.IsDevicePageLoaded();

            if (!isdevicepageloaded)
            {
                Logger.Error("Devices tab UI not loaded", Module.DeviceModule);
                throw new Exception("Devices tab UI not loaded");
            }
            SelectDevice(deviceInfofromDb);
        }

        public void SelectDevice(DeviceInfo deviceInfofromDb)
        {
            bool result = false;
            try
            {
                //If current selection is not valid device then
                //{
                result = deviceOperationPO.SelectDevice(deviceInfofromDb);

                // If device is visible then select
                if (!result)
                {
                    deviceOperationPO.ScrollDeviceList();
                    result = deviceOperationPO.SelectDevice(deviceInfofromDb);
                }

                // If device is not visible then scroll once and select
                if (!result)
                {
                    var list = deviceOperationPO.SearchDevice(deviceInfofromDb.DeviceName);
                    Logger.Info("Searched device count: " + list.Count);
                    if (list.Count < 10)
                    {
                        deviceOperationPO.SelectDevice(deviceInfofromDb);
                    }
                    else
                    {
                        Logger.Warning("Device search results greater than 10. Hence can't select");
                    }
                }

                // If still device is not visible then Search device and select
                //}
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Select Device: " + deviceInfofromDb.DeviceName);
                throw;
            }
        }

        /// <summary>
        /// Method to validate UI elements of Discover device page
        /// </summary>
        /// <returns>true if UI is valid else false</returns>
        public bool IsDeviceListPageUIValid()
        {
            try
            {
                return deviceOperationPO.IsDevicePageLoaded();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Invalid UI for device discovery page");
                throw;
            }
        }

        public bool IsDeviceSuccessfullyRegistered(string deviceSerialNo)
        {
            bool result = false;
            try
            {
                //IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader);
                if (IsDeviceListPageUIValid())
                {
                    var list = deviceOperationPO.GetDeviceListDetails();
                    result = list.Any(x => x.DeviceSerial.Equals(deviceSerialNo, StringComparison.OrdinalIgnoreCase));
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to check if device is successfully registered or not");
                throw;
            }
            Logger.Info("Device Registration for serial: " + deviceSerialNo + " " + result);
            return result;
        }

        public string RebootDevice()
        {
            string selectedDevice = null;
            try
            {
                selectedDevice = deviceOperationPO.GetSelectedDeviceSerial();
                deviceOperationPO.ClickReboot();
                IXMWebUtils.IsProgressBarShown(true, CommonLocators.IXMLoader, 20);
                var status = deviceOperationPO.GetDeviceStatus().Trim();
                Logger.Info("Device status on reboot " + status);
                return status;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to reboot device: " + selectedDevice);
                throw;
            }
        }

        public RegisterDevice_PO AddDevice()
        {
            try
            {
                return deviceOperationPO.ClickAddDevice();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "AddDevice failed");
                throw;
            }
        }
    }
}