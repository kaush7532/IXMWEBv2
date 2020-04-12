using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using IXMWEBv2.Constants;
using IXMWEBv2.Models;
using IXMWEBv2.Models.DBModels;
using IXMWEBv2.QuickNavigationPane.Logs.ApplicationLogs;
using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Resources.Locators.Config.Communication;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace IXMWEBv2.Utils
{
    public class IXMWebUtils : GenericBasePage
    {
        public static IWebElement switchXpath;
        private static IWebDriver driver;
        private static WebDriverWait wait;
        private static DateTime execStart;
        private static DateTime execStop;

        public IXMWebUtils()
        {
            driver = this._driverManager.GetDriver();
            wait = this._driverManager.GetWait();
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = CommonLocators.CloseButtonOnModal)]
        private IList<IWebElement> CloseModalWindows { get; set; }

        [FindsBy(How = How.ClassName, Using = CommonLocators.KendoWindowActionClass)]
        private IList<IWebElement> CloseKendoWindows { get; set; }

        [FindsBy(How = How.XPath, Using = CommonLocators.applicationLogWindow)]
        private IWebElement appLogWindow { get; set; }

        [FindsBy(How = How.XPath, Using = CommonLocators.applicationLogWindowCloseBtn)]
        private IWebElement appWindowCloseBtn { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.HomeBtn)]
        private IWebElement HomeBtn { get; set; }

        #region Tile WebElement Declaration and initialization

        [FindsBy(How = How.XPath, Using = HomePageLocators.UserTile)]
        private IWebElement userTile { get; set; }

        [FindsBy(How = How.Id, Using = HomePageLocators.DeviceTab)]
        private IWebElement DeviceTab { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.ConfigTile)]
        private IWebElement configTile { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.ConvertTile)]
        private IWebElement convertTile { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.LicenseTile)]
        private IWebElement licenseTile { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.LinkTile)]
        private IWebElement linkTile { get; set; }

        [FindsBy(How = How.Id, Using = HomePageLocators.HomeBtn)]
        private IWebElement homeTab { get; set; }

        [FindsBy(How = How.Id, Using = HomePageLocators.LogsTab)]
        private IWebElement logsTab { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.ReportTile)]
        private IWebElement reportTile { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.SmartCardTile)]
        private IWebElement smartCardTile { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.SyncTile)]
        private IWebElement syncTile { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.ToolsTile)]
        private IWebElement toolsTile { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.TranslateTile)]
        private IWebElement translateTile { get; set; }

        [FindsBy(How = How.Id, Using = HomePageLocators.NavigationButton1)]
        private IWebElement navButton1 { get; set; }

        [FindsBy(How = How.Id, Using = HomePageLocators.NavigationButton2)]
        private IWebElement navButton2 { get; set; }

        [FindsBy(How = How.Id, Using = HomePageLocators.EmployeeTab)]
        private IWebElement EmployeeTab { get; set; }

        #endregion Tile WebElement Declaration and initialization

        #region Modules hyperlink WebElement

        [FindsBy(How = How.XPath, Using = HomePageLocators.HomePageHyperLink)]
        private IWebElement homePageHyperLink { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.AlreadyInUsersTile)]
        private IWebElement alreadyInUsersTile { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.AlreadyInDeviceTile)]
        private IWebElement alreadyInDeviceTile { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.AlreadyInConfigTile)]
        private IWebElement alreadyInConfigTile { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.AlreadyInLogsTile)]
        private IWebElement alreadyInLogs { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.AlreadyInToolsTile)]
        private IWebElement alreadyInToolsTile { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.AlreadyInTLogs)]
        private IWebElement alreadyInTLogs { get; set; }

        [FindsBy(How = How.XPath, Using = HomePageLocators.AlreadyInAppLogs)]
        private IWebElement alreadyInAppLogs { get; set; }

        #endregion Modules hyperlink WebElement

        #region Device Configuration WebElement

        [FindsBy(How = How.Id, Using = CommunicationTabLocators.CommunicationTab)]
        private IWebElement deviceCommunicationTab { get; set; }

        #endregion Device Configuration WebElement

        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgWindow)]
        private IWebElement kendoMsgWindow { get; set; }

        [FindsBy(How = How.XPath, Using = CommonLocators.KendoMsgTxt)]
        private IWebElement KendoMsgTxt { get; set; }

        [FindsBy(How = How.Id, Using = CommonLocators.KendoMsgOKBtn)]
        private IWebElement kendoMsgOKBtn { get; set; }

        /// <summary>
        /// Method to go to main modules like users, device, license, etc
        /// </summary>
        /// <param name="tabName">Provide module name from ENUM class Modules</param>
        public void GoToTab(MainTabs tabName)
        {
            switch (tabName)
            {
                //case MainTabs.Home:
                //    ClickOnModuleTab(homeTab);
                //    break;

                case MainTabs.Employee:
                    ClickOnModuleTab(EmployeeTab);
                    break;

                case MainTabs.Devices:
                    ClickOnModuleTab(DeviceTab);
                    break;

                case MainTabs.Config:
                    if (IsElementPresent(alreadyInConfigTile, 2))
                    {
                        Logger.Info("Already in Config tile");
                    }
                    else
                    {
                        ClickOnModuleTab(configTile);
                    }
                    break;

                case MainTabs.Convert:
                    ClickOnModuleTab(convertTile);
                    break;

                case MainTabs.License:
                    ClickOnModuleTab(licenseTile);
                    break;

                case MainTabs.Link:
                    ClickOnModuleTab(linkTile);
                    break;

                case MainTabs.Logs:
                    ClickOnModuleTab(logsTab);

                    break;

                case MainTabs.Report:
                    ClickOnModuleTab(reportTile);
                    break;

                case MainTabs.SmartCard:
                    ClickOnModuleTab(smartCardTile);
                    break;

                case MainTabs.Sync:
                    ClickOnModuleTab(syncTile);
                    break;

                case MainTabs.Tools:
                    if (IsElementPresent(alreadyInToolsTile, 2))
                    {
                        Logger.Info("Already in Tools tile");
                    }
                    else
                    {
                        ClickOnModuleTab(toolsTile);
                    }
                    break;

                case MainTabs.Translate:
                    ClickOnModuleTab(translateTile);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Method to navigate to device configurations
        /// </summary>
        /// <param name="configurationName">config name</param>
        public void GoToDeviceConfigurations(DeviceConfigurationTabs configurationName)
        {
            switch (configurationName)
            {
                case DeviceConfigurationTabs.Communication:
                    ClickOnDeviceConfigurationTab(deviceCommunicationTab);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Method to click on Module tile
        /// It waits for tile to be present and tile is clicked
        /// If tile doesn't exist page is scrolled to next page and tile is clicked
        /// </summary>
        /// <param name="tabWebElement">webelement of module tile</param>
        public void ClickOnModuleTab(IWebElement tabWebElement)
        {
            try
            {
                //Check for any of the model (modal or kendo) open or not. If yes then close it

                var result = CloseModalWindows.Where(x => x.Displayed);
                Logger.Info("Found ModalWindows: " + result.Count());
                foreach (var item in result)
                {
                    ClickElement(item);
                }
                var kendoresult = CloseKendoWindows.Where(x => x.Displayed);
                Logger.Info("Found KendoWindows: " + kendoresult.Count());
                foreach (var item in kendoresult)
                {
                    ClickElement(item);
                }

                WaitElementToBeClickable(tabWebElement);
                var currentTab = tabWebElement.GetAttribute("class");

                if (!currentTab.Contains("active"))
                {
                    Logger.Info(string.Format("Navigating to {0} tile", tabWebElement.Text), "");
                    WaitElementToBeClickable(tabWebElement);
                    ClickElement(tabWebElement);
                    // Thread.Sleep(1000);
                }
                else
                {
                    Logger.Info("Already in page");
                    //Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Click on moduletile: " + tabWebElement.ToString());
                throw;
            }
        }

        public void ClickOnDeviceConfigurationTab(IWebElement tabWebElement)
        {
            try
            {
                WaitElementToBeClickable(tabWebElement, 5);
                var currentTab = tabWebElement.GetAttribute("class");

                if (!currentTab.Contains("active"))
                {
                    Logger.Info(string.Format("Navigating to {0} configuration", tabWebElement.Text), "");
                    WaitElementToBeClickable(tabWebElement);
                    ClickElement(tabWebElement);
                    Thread.Sleep(1000);
                }
                else
                {
                    Logger.Info("Already in configuration");
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Click on moduletile: " + tabWebElement.ToString());
                throw;
            }
        }

        public bool IsAppLogWindowVisible()
        {
            WaitForVisibleElement(By.XPath(CommonLocators.applicationLogWindow));
            return IsElementPresent(appLogWindow);
        }

        /// <summary>
        /// Verify Success message on Application log window
        /// </summary>
        /// <returns>true if all logs are success else false</returns>
        public bool VerifySuccessOnAppWindowTemp(bool continueExec = false)
        {
            List<IWebElement> webElements = new List<IWebElement>();
            //bool result;

            if (IsAppLogWindowVisible())
            {
                Logger.Info("Application logs has all success message");
                Thread.Sleep(500);
                if (continueExec)
                {
                    var chkbx = driver.FindElement(By.Id("chkQuickEnrollment1"));
                    WaitElementToBeClickable(chkbx);
                    if (!chkbx.Selected)
                    {
                        chkbx.Click();
                    }
                }

                CloseApplicationWindow();
                return true;
            }
            else
            {
                Logger.Error("Fail: Unable to see application window", Module.ApplicationLogModule.ToString());
                return false;
            }
        }

        /// <summary>
        /// Verify Success message on Application log window
        /// It will filter with Fail; if any single app log is visible with fail then method will return false
        /// </summary>
        /// <returns>true if all logs are success else false</returns>
        public bool VerifySuccessOnAppWindow()
        {
            List<IWebElement> webElements = new List<IWebElement>();
            //bool result;
            try
            {
                if (IsAppLogWindowVisible())
                {
                    // Apply filter on Appwindow with Fail
                    var result1 = FilterAppWindow(AppLogFilterOnColums.EventStatus, "Fail");

                    if (result1.PageCountString.Equals("No items found"))
                    {
                        Logger.Info("Application logs has all success message");

                        CloseApplicationWindow();
                        return true;
                    }
                    else
                    {
                        Logger.Error("Application logs has failure message", Module.ApplicationLogModule.ToString());
                        //CloseApplicationWindow();
                        return false;
                    }
                }
                else
                {
                    Logger.Error("Fail: Unable to see application window", Module.ApplicationLogModule.ToString());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to verify Application logs");
                throw;
            }
        }

        public PageItemsMetadataModel FilterAppWindow(AppLogFilterOnColums columnName, string filterValue)
        {
            try
            {
                string col = columnName.ToString();
                IWebElement statusFilterIcon = driver.FindElement(By.XPath(".//*[@id='ApplicationEvent']//th[@data-field='" + col + "']//span[@title='Filter']"));
                ClickElement(statusFilterIcon);
                Thread.Sleep(250);

                string selectValue1 = ".//form[contains(@style,'display: block')]/div[1]//select[@data-bind='value:filters[0].value']/ancestor::span";

                ClickElement(_driver.FindElement(By.XPath(selectValue1)));
                Thread.Sleep(250);
                ClickElement(_driver.FindElement(By.XPath(".//li[text()='" + filterValue + "']")));
                Thread.Sleep(500);
                string filterBtn = ".//form[contains(@style,'display: block')]/div[1]//button[@type='submit']";
                ClickElement(_driver.FindElement(By.XPath(filterBtn)));
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to do filter on app log window");
            }
            Logger.Info("Count of application logs events on column: " + columnName.ToString() + " after filtering with " + filterValue);
            return ItemsCountDetails(ApplicationLogsLocators.AppLogGridDivId, driver);
        }

        public void CloseApplicationWindow()
        {
            ClickElement(appWindowCloseBtn);
            Logger.Info("Closed Application logs window", Module.ApplicationLogModule.ToString());
        }

        /// <summary>
        /// check if switch button on page is enabled or disabled
        /// set IWebElement value for switch in 'switchXpath' variable
        /// </summary>
        /// <param name="driver">current driver</param>
        /// <param name="switchInputName">switch input name</param>
        /// <returns>true if button is active; false if button is inactive</returns>

        public static bool IsSwitchButtonEnabled(IWebDriver driver, string switchInputName)
        {
            try
            {
                bool flag = false;

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1.5);
                if (driver.FindElements(By.XPath(CommonLocators.switchActive.Replace("#SWITCHNAME#", switchInputName))).Count == 1)
                {
                    Logger.Info("Found Switch button in ACTIVE state", "");
                    switchXpath = driver.FindElement(By.XPath(CommonLocators.switchActive.Replace("#SWITCHNAME#", switchInputName)));
                    flag = true;
                }
                else if (driver.FindElements(By.XPath(CommonLocators.switchInactive.Replace("#SWITCHNAME#", switchInputName))).Count == 1)
                {
                    Logger.Info("Found Switch button in IN-ACTIVE state", "");
                    switchXpath = driver.FindElement(By.XPath(CommonLocators.switchInactive.Replace("#SWITCHNAME#", switchInputName)));
                    flag = false;
                }
                return flag;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to get kendo switch status.");
                return false;
            }
        }

        /// <summary>
        /// check if switch button on page is enabled or disabled
        /// </summary>
        /// <param name="driver">current driver</param>
        /// <returns>true if button is active; false if button is inactive</returns>
        public static bool IsSwitchButtonThinEnabled(IWebDriver driver)
        {
            try
            {
                bool flag = false;

                if (driver.FindElements(By.XPath(CommonLocators.SwitchBtnThinActive)).Count > 0)
                {
                    Logger.Info("Found Switch button in ON state", "");
                    flag = true;
                }
                else if (driver.FindElements(By.XPath(CommonLocators.SwitchBtnThinInactive)).Count > 0)
                {
                    Logger.Info("Found Switch button in OFF state", "");
                    flag = false;
                }
                return flag;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to get kendo thin switch status.");
                throw ex;
            }
        }

        public void SelectDeviceFromTreeView(List<DeviceInfo> listOfDevices, string deviceTreeID)
        {
            try
            {
                List<string> deviceNames = new List<string>(listOfDevices.Select(x => x.DeviceName).ToList());

                //Search Device 
                foreach (var item in listOfDevices)
                {

                    EnterValueTextbox(_driver.FindElement(By.Id(CommonLocators.searchDeviceBox)), item.DeviceName);
                    ClickElement(_driver.FindElement(By.XPath(CommonLocators.searchDeviceBtn.Replace("#GRIDID", deviceTreeID))));
                    string DeviceChkBox = CommonLocators.DeviceSelectionChkBox.Replace("#GRIDID", deviceTreeID).Replace("#DEVICENAME", item.DeviceName);
                    var deviceChkBoxElement = _driver.FindElement(By.XPath(DeviceChkBox));
                    ClickElement(deviceChkBoxElement);
                }



                //From search result select device to download logs



                var deviceGroupNamesXpath = _driver.FindElements(By.XPath(".//*[@class='k-icon k-i-expand']/following-sibling::span[@class='k-in']"));

                //_wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(deviceGroupNamesXpath));

                foreach (var devGroupNameXpath in deviceGroupNamesXpath)
                {
                    ClickElement(devGroupNameXpath);

                    //string arrowXpath = ".//*[@class='k-icon k-plus']/following-sibling::span[text()='" + devGroupNameXpath.Text + "']/preceding-sibling::span[@class='k-icon k-plus']";

                    //string arrowXpath = ".//*[@class='k-checkbox-wrapper']/following-sibling::span[text()='" + devGroupNameXpath.Text + "']/preceding-sibling::span[@class='k-icon k-i-expand']";
                    string arrowXpath = ".//*[@id='devices_unread']//div/span[text()='" + devGroupNameXpath.Text + "']/preceding-sibling::span[1]";
                    IWebElement arrow = _driver.FindElement(By.XPath(arrowXpath));
                    ClickElement(arrow);

                    //var shownDeviceXpaths = _driver.FindElements(By.XPath(".//*[@id='DeviceGroupDeviceTreeView_tv_active']//span[@class='k-in']"));

                    var shownDeviceXpaths = _driver.FindElements(By.XPath(".//*[@id='devices_unread_tv_active']//span[@class='k-in']"));

                    //_wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(shownDeviceXpaths));
                    foreach (var deviceToBeChecked in shownDeviceXpaths)
                    {
                        Thread.Sleep(500);
                        string deviceNameTxt = deviceToBeChecked.Text;
                        if (deviceNames.Any(d => d.Contains(deviceNameTxt)))
                        {
                            deviceToBeChecked.Click();

                            //IWebElement ele = _driver.FindElement(By.XPath(".//*[@id='DeviceGroupDeviceTreeView_tv_active']/div/span/*"));

                            IWebElement ele = _driver.FindElement(By.XPath(".//*[@id='devices_unread_tv_active']/div/span/*"));
                            var path = ".//*[@id='devices_unread']//div/span[text()='" + deviceNameTxt + "']/preceding-sibling::span[1]";
                            IWebElement ele2 = _driver.FindElement(By.XPath(path));
                            if (!(ele2.Selected))
                            {
                                ClickElement(ele);
                                Logger.Info(string.Format("Device checkbox Selected: '{0}'", ele.Text), "");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to select checkbox of the device from device tree view");
                throw;
            }
        }

        /// <summary>
        /// Method to get total number of items on page grid details
        /// e.g userall page, application logs page, etc.
        /// </summary>
        /// <param name="gridOrDivId">table/grid div id</param>
        /// <param name="driver">Driver object</param>
        /// <returns>PageItemstMetadataModel having every details of items count</returns>
        public static PageItemsMetadataModel ItemsCountDetails(string gridOrDivId, IWebDriver driver)
        {
            Logger.Info("Getting value of items from UI grid");
            int currentPageStartIndex = 0, currentPageLastIndex = 0, totalItems = 0;
            string moduleName = string.Empty;
            IWebElement countXpath = driver.FindElement(By.XPath(CommonLocators.itemsCountOnPage.Replace("#GRIDID", gridOrDivId)));
            if (DoItemsExist(gridOrDivId, driver))
            {
                string[] parts = countXpath.Text.Split(' ');
                currentPageStartIndex = int.Parse(parts[0]);
                currentPageLastIndex = int.Parse(parts[2]);
                totalItems = int.Parse(parts[4]);
                moduleName = parts[5];
            }
            Logger.Info(string.Format("Item count details are full string '{0}'", countXpath.Text));

            return new PageItemsMetadataModel()
            {
                PageCountString = countXpath.Text,
                TotalItemsCount = totalItems,
                CurrentPageStartCount = currentPageStartIndex,
                CurrentPageEndCount = currentPageLastIndex,
                ModuleName = moduleName
            };
        }

        public static bool DoItemsExist(string gridOrDivId, IWebDriver driver)
        {
            IWebElement countXpath = driver.FindElement(By.XPath(CommonLocators.itemsCountOnPage.Replace("#GRIDID", gridOrDivId)));
            if (countXpath.Text.Equals("No items found"))
            {
                return false;
            }
            else if (countXpath.Text.Contains("to"))
            {
                return true;
            }
            Logger.Info("Current page items count value: '" + countXpath.Text + "'");
            return false;
        }

        /// <summary>
        /// Method to select item from kendo dropdown by value
        /// </summary>
        /// <param name="elementName">name of input id element</param>
        /// <param name="itemValueToSelect">item to select</param>
        /// <param name="driver">webdriver</param>
        public static void KendoDropDownSelectItemByValue(string elementName, string itemValueToSelect, IWebDriver _driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            try
            {
                var test = js.ExecuteScript("$('#" + elementName + "').data('kendoDropDownList').select(0);");
                var test1 = js.ExecuteScript("$('#" + elementName + "').data('kendoDropDownList').toggle();");
                try
                {
                    for (int i = 0; i < 50000; i++)
                    {
                        string returnValue = js.ExecuteScript(
                                        "return $('#"
                                                + elementName
                                                + "').data('kendoDropDownList').dataSource._data["
                                                + Convert.ToString(i) + "].Text").ToString();
                        if (itemValueToSelect.Equals(returnValue, StringComparison.InvariantCultureIgnoreCase))
                        {
                            js.ExecuteScript("$('#" + elementName + "').data('kendoDropDownList').select(" + Convert.ToString(i) + ");");
                            break;
                        }
                    }
                    js.ExecuteScript("$('#" + elementName + "').data('kendoDropDownList').toggle();");
                    js.ExecuteScript("$('#" + elementName + "').data('kendoDropDownList').trigger('change');");
                    Logger.Info("Kendodropdown selected value '" + itemValueToSelect + "' from dropdown element id/name '" + elementName + "'.");
                }
                catch (WebDriverException e)
                {
                    throw new Exception("Value provided with name'" + itemValueToSelect + "'is not Found in Drop Down Please select Valid Value" + e.Message + ".");
                    // Throw Custom Exception for invalid Element Name
                }
            }
            catch (WebDriverException e)
            {
                throw new Exception("Wrong Element Name Provided" + e.Message + ".");
                // Throw Custom Exception for invalid Element Name
            }
            Thread.Sleep(500);
        }

        /// <summary>
        /// Method to select item from kendoComboBox by value
        /// </summary>
        /// <param name="elementName">name of input id element</param>
        /// <param name="itemValueToSelect">item to select</param>
        /// <param name="driver">webdriver</param>
        public static void KendoComboBoxSelectItemByValue(string elementName, IWebDriver _driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            try
            {
                var test1 = js.ExecuteScript("$('#" + elementName + "').data('kendoComboBox').toggle();");
                var test2 = js.ExecuteScript("$('#" + elementName + "').data('kendoComboBox').select(0);");
                var test3 = js.ExecuteScript("$('#" + elementName + "').data('kendoComboBox').toggle();");
            }
            catch (WebDriverException e)
            {
                throw new Exception("Wrong Element Name Provided" + e.Message + ".");
                // Throw Custom Exception for invalid Element Name
            }
        }

        /// <summary>
        /// Method to enter value on the Kendo text box
        /// </summary>
        /// <param name="elementName">name of input id element</param>
        /// <param name="value">value to enter in the textbox</param>
        /// <param name="_driver">webdriver</param>

        public static void KendoNumericTextboxValueChange(string elementName, string value, IWebDriver _driver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;

            js.ExecuteScript("$('#" + elementName + "').data('kendoNumericTextBox').value('" + value + "');");

            js.ExecuteScript("$('#" + elementName + "').data('kendoNumericTextBox').trigger('change');");
        }

        /// <summary>
        /// Method to check if progress bar is shown or not
        /// </summary>
        /// <param name="waitforDisappear">true if you want to wait till progress bar disappears</param>
        /// <returns>true if progress bar exists else false</returns>
        public static bool IsProgressBarShown(bool waitforDisappear, string loaderImage, int secondsToWaitForProgressBar = 70)
        {
            bool flag = false;
            try
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWaitForProgressBar));
                WebDriverWait _waittemp = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

                flag = _waittemp.Until<bool>((d) => { return d.FindElements(By.XPath(loaderImage)).Any(x => x.Displayed.Equals(true)); });


                if (flag && waitforDisappear)
                {

                    DateTime before = DateTime.Now;
                    try
                    {
                        var allele = driver.FindElement(By.XPath(loaderImage));
                        Logger.Info("Found progress bar on screen. Waiting for progress bar to disappear");
                        //var ele = allele.FirstOrDefault(d => { return d.Displayed.Equals(true); });
                        wait.Until(_driver => !allele.Displayed);
                        flag = false;
                    }
                    catch (StaleElementReferenceException ex)
                    {
                        DateTime after = DateTime.Now;
                        Logger.Info("Stale element. Progress bar disappeared in time: " + after.Subtract(before));
                        flag = true;
                    }
                    catch (NoSuchElementException ex)
                    {
                        DateTime after = DateTime.Now;
                        Logger.Info("No Element found. Progress bar disappeared in time: " + after.Subtract(before));
                        throw;
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("Timed out after " + secondsToWaitForProgressBar + " seconds"))
                {
                    Logger.Error("Progress not completed in " + secondsToWaitForProgressBar + " seconds duration", "ProgressBar");
                    flag = false;
                }
                Logger.Error(ex, "Unable to verify if progress bar is shown or not.");
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// Method searches provided locator across pages wherever applicable
        /// </summary>
        /// <param name="gridOrdivId">div/grid id of the table</param>
        /// <param name="locator">locator value to search</param>
        /// <returns>found element</returns>
        public static IWebElement FindElementAcrossPages(string gridOrdivId, By locator)
        {
            try
            {
                PageItemsMetadataModel pgitems = ItemsCountDetails(gridOrdivId, driver);
                bool elementFound = false;
                IWebElement element = null;

                while (!elementFound)
                {
                    try
                    {
                        element = driver.FindElement(locator);
                        if (element.Displayed)
                        {
                            elementFound = true;
                            Logger.Info("Found element " + element.ToString() + "on page number " + pgitems.PageCountString + " page");
                            break;
                        }
                    }
                    catch (NoSuchElementException ex)
                    {
                        //Click next button if next page exists
                        if (pgitems.CurrentPageEndCount < pgitems.TotalItemsCount)
                        {
                            Logger.Info("Navigating to other page to find element since found: ");
                            string nextPageXPath = CommonLocators.nextPage.Replace("#GridId", gridOrdivId);
                            driver.FindElement(By.XPath(nextPageXPath)).Click();
                            pgitems = ItemsCountDetails(gridOrdivId, driver);
                        }
                        else
                        {
                            Logger.Error(ex, "Item not found on current page and no more pages exist to find element");
                            throw;
                        }
                    }
                }
                return element;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Find element across failed");
                throw;
            }
        }

        /// <summary>
        /// Method to return text of kendo message box
        /// </summary>
        /// <returns>message value from kendobox</returns>
        public string ReturnKendoTextValue()
        {
            string msg = null;
            try
            {
                if (IsElementPresent(kendoMsgWindow))
                {
                    msg = KendoMsgTxt.Text;

                    if (IsClickable(kendoMsgOKBtn))
                    {
                        ClickElement(kendoMsgOKBtn);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to get text from Kendo message box");
                throw;
            }
            return msg;
        }
    }
}