using IXMWEBv2.WebDriverFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace IXMWEBv2.Utils
{
    public abstract class GenericBasePage
    {
        /// <summary>
        /// Declare variable driver manager
        /// </summary>
        protected DriverManager _driverManager;

        /// <summary>
        /// Declare variable driver
        /// </summary>
        protected IWebDriver _driver;

        /// <summary>
        /// Declare variable wait
        /// </summary>
        protected WebDriverWait _wait;

        /// <summary>
        /// Declare variable loading icon
        /// </summary>
        protected IWebElement _loadingIcon;

        private Cursor Cursor;

        /// <summary>
        /// Constructor for generic base page
        /// </summary>
        public GenericBasePage()
        {
            _driverManager = DriverManager.GetInstance();
            _driver = _driverManager.GetDriver();
            _wait = _driverManager.GetWait();
        }

        /// <summary>
        /// Method to verify is element present
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        protected bool IsElementPresent(By locator, int seconds = 3)
        {
            bool result;
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                var waitResult = _wait.Until(ExpectedConditions.ElementIsVisible(locator));
                result = true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Element no visible in given time: " + locator.ToString());
                result = false;
            }
            return result;
        }

        protected bool IsElementPresent(IWebElement webElement, int seconds = 3)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                return _wait.Until(_driver => webElement.Displayed);
            }
            catch (Exception e)
            {
                //Console.WriteLine("Failed WaitForElementPresent: {0}", e);
                //Logger.Error(e, "WaitForElementPresent:" + e.Message + " " + e.InnerException);
                Logger.Error("EXMessage: " + e.Message + Environment.NewLine + "InnerMessage: " + e.InnerException, "IsElementPresent");

                return false;
            }
        }

        /// <summary>
        /// Method to check all elements present of not
        /// </summary>
        /// <param name="webElements">List of webelements</param>
        /// <param name="seconds">wait seconds</param>
        /// <returns>true if all present else false</returns>
        protected bool AreElementsPresent(List<IWebElement> webElements, int seconds = 3)
        {
            try
            {
                bool result = false;
                bool flag = false;
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                foreach (var item in webElements)
                {
                    try
                    {
                        flag = _wait.Until(_driver => item.Displayed);
                    }
                    catch (Exception ex)
                    {
                        flag = false;
                        //result = false;
                        Logger.Error(ex, "Element not present");
                        break;
                        //throw;
                    }
                }
                result = flag;

                return result;
            }
            catch (Exception e)
            {
                //Console.WriteLine("Failed WaitForElementPresent: {0}", e);
                //Logger.Error(e, "WaitForElementPresent:" + e.Message + " " + e.InnerException);
                Logger.Error("EXMessage: " + e.Message + Environment.NewLine + "InnerMessage: " + e.InnerException, "IsElementPresent");

                return false;
            }
        }

        /// <summary>
        /// Method to verify is element enabled
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        protected bool IsElementEnabled(By locator, int seconds = 5)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                IWebElement element = _wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(locator);
                });
                return element.Enabled;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed IsElementEnabled: {0}", e);
                Logger.Error(e, "IsElementEnabled:");
                return false;
            }
        }

        /// <summary>
        /// Method to check if checkbox is enabled or not
        /// </summary>
        /// <param name="elementId">Id of input type= checkbox</param>
        /// <returns>true if checkbox enabled else false</returns>
        protected bool IsCheckboxActive(string elementId)
        {
            try
            {
                IJavaScriptExecutor je = (IJavaScriptExecutor)_driver;
                return (bool)je.ExecuteScript("return document.getElementById(arguments[0]).checked", elementId);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to get if element is checked or not: " + elementId);
                throw;
            }
        }

        /// <summary>
        /// A method to validate if a web element is clickable
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected bool IsClickable(IWebElement element)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
                _wait.Until(ExpectedConditions.ElementToBeClickable(element));
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed WaitForElementToBeClickable: {0}", e);
                Logger.Error(e, "WaitForElementToBeClickable:");
                return false;
            }
        }

        /// <summary>
        /// Method to wait for element present
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        protected void WaitForElementPresent(By locator, int seconds = 10)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                _wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(locator);
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed WaitForElementPresent: {0}", e);
                Logger.Error(e, "WaitForElementPresent:");
            }
        }

        /// <summary>
        /// A function to wait until the text which is provided is displayed in IWebElement
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="seconds"></param>
        protected void WaitForTextToBePresentInElement(IWebElement webElement, string text, int seconds = 10)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                _wait.Until(ExpectedConditions.TextToBePresentInElement(webElement, text));
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed WaitForTextToBePresentInElement: {0}", e);
                Logger.Error(e, "WaitForTextToBePresentInElement:");
            }
        }

        /// <summary>
        /// A function to wait until an IWebElement is displayed
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="seconds"></param>
        protected void WaitForElementPresent(IWebElement webElement, int seconds = 10)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                _wait.Until(_driver => webElement.Displayed);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed WaitForElementPresent: {0}", e);
                Logger.Error(e, "WaitForElementPresent:");
            }
        }

        /// <summary>
        /// A function to wait until an IWebElement is displayed
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="seconds"></param>
        protected void WaitForVisibilityOfElementLocatedBy(IWebElement webElement, int seconds = 3)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                _wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(GetLocator(webElement)));
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed WaitForElementPresent: {0}", e);
                Logger.Error(e, "WaitForElementPresent:");
            }
        }

        /// <summary>
        /// A method to Get PageFactory IWebElement By locator
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private By GetLocator(IWebElement element)
        {
            // Retrieve a FieldInfo instance corresponding to the field
            FieldInfo field = element.GetType().GetField("bys", BindingFlags.Instance | BindingFlags.NonPublic);

            // Retrieve the value of the field, and cast as necessary
            return ((List<By>)field.GetValue(element))[0];
        }

        /// <summary>
        /// Method to wait for visible element
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        protected IWebElement WaitForVisibleElement(By locator, int seconds = 10)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                return _wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed WaitForVisibleElement: {0}", e);
                Logger.Error(e, "WaitForVisibleElement:");
                return null;
            }
        }

        /// <summary>
        /// Wait for element to be clickable
        /// Method to click on webelement webele.click()
        /// </summary>
        /// <param name="webElement">element to click</param>
        /// <param name="seconds">time to wait for clickable</param>
        protected void ClickElement(IWebElement webElement, int seconds = 10, string elementname = null)
        {
            try
            {
                //Wait element to be clickable
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                webElement = ScrollToView(webElement);

                _wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
                //Mouse mouse cursor to webelement

                MoveToElement(webElement);
                webElement.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed Click Element: {0}", e);
                Logger.Error(e, "Click Element:" + elementname);
                throw;
            }
        }

        /// <summary>
        /// Wait for text field element to be displayed
        /// Method to send keys on webelement webele.clear(), webele.sendkeys()
        /// </summary>
        /// <param name="txtWebElement">element of text field</param>
        /// <param name="textToEnter">text value to enter</param>
        /// <param name="seconds">timeout for element displayed</param>
        protected void EnterValueTextbox(IWebElement txtWebElement, string textToEnter, int seconds = 5)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                _wait.Until(_driver => txtWebElement.Displayed);
                MoveToElement(txtWebElement);
                txtWebElement.Clear();

                txtWebElement.Click();

                for (int i = 0; i <= textToEnter.Length - 1; i++)
                {
                    txtWebElement.SendKeys(char.ToString(textToEnter[i]));
                }

                Logger.Info("Entered text '" + textToEnter + "' in text box");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed Send keys to Element: {0}", e);
                Logger.Error(e, "Send Keys to Element:");
            }
        }

        /// <summary>
        /// Method to wait element to be clickable
        /// </summary>
        /// <param name="webElement"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        protected IWebElement WaitElementToBeClickable(IWebElement webElement, int seconds = 10)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                return _wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed WaitElementToBeClickeable: {0}", e);
                Logger.Error(e, "WaitElementToBeClickeable:");
                return null;
            }
        }

        /// <summary>
        /// Method to wait for element disappear
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        protected void WaitForElementDisappear(By locator, int seconds = 3)
        {
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed WaitForElementDisappear: {0}", e);
                Logger.Error(e, "WaitForElementDisappear:" + e);
            }
        }

        /// <summary>
        /// Method to wait for element disappear
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="seconds"></param>
        protected void WaitForElementDisappear(IWebElement webElement, int seconds = 3)
        {
            DateTime before = DateTime.Now;
            try
            {
                _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
                _wait.Until(_driver => !webElement.Displayed);
                DateTime after = DateTime.Now;
                Logger.Info("Time taken for element to disappear is: " + after.Subtract(before));

                //_wait.Until(ExpectedConditions.InvisibilityOfElementLocated(webElement));
            }
            catch (StaleElementReferenceException)
            {
                DateTime after = DateTime.Now;
                Logger.Info("Time taken for element to disappear is: " + after.Subtract(before));
            }
            catch (NoSuchElementException)
            {
                DateTime after = DateTime.Now;
                Logger.Info("Time taken for element to disappear is: " + after.Subtract(before));
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed WaitForElementDisappear: {0}", e);
                Logger.Error(e, "Failed WaitForElementDisappear: " + webElement.ToString() + e);
            }
        }

        /// <summary>
        /// Move mouse cursor to element
        /// </summary>
        /// <param name="webElement">element to move cursor on</param>
        private void MoveToElement(IWebElement webElement)
        {
            if (DriverManager.recordVideo)
            {
                try
                {
                    int browserOuterHight, browserInnerHight, scrollHight, titlebar, clientHight;

                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView();", webElement);

                    browserOuterHight = int.Parse((((IJavaScriptExecutor)_driver).ExecuteScript("return window.outerHeight")).ToString());
                    browserInnerHight = int.Parse((((IJavaScriptExecutor)_driver).ExecuteScript("return window.innerHeight")).ToString());

                    titlebar = browserOuterHight - browserInnerHight;

                    string execScript = "return document.documentElement.scrollHeight>document.documentElement.clientHeight;";
                    bool isScrollBarPresent = bool.Parse((((IJavaScriptExecutor)_driver).ExecuteScript(execScript)).ToString());

                    if (isScrollBarPresent == true)
                    {
                        scrollHight = int.Parse((((IJavaScriptExecutor)_driver).ExecuteScript("return document.documentElement.scrollHeight")).ToString());

                        clientHight = int.Parse((((IJavaScriptExecutor)_driver).ExecuteScript("return document.documentElement.clientHeight")).ToString());
                    }
                    else
                    {
                        scrollHight = 0;
                        clientHight = 0;
                    }

                    int xCord = webElement.Location.X + (webElement.Size.Width / 2);

                    int yCord = webElement.Location.Y + titlebar + (webElement.Size.Height / 2) - (scrollHight - clientHight);
                    if (yCord < 0)
                    {
                        yCord = titlebar + (webElement.Size.Height / 2);
                    }

                    this.Cursor = new Cursor(Cursor.Current.Handle);

                    Cursor.Position = new Point(xCord, yCord);
                    Thread.Sleep(1500);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to move element: {0}", e);
                    Logger.Error(e, "Faile to move element:" + e);
                }
            }
        }

        /// <summary>
        /// Method to hover any web element
        /// </summary>
        /// <param name="webElement">Provide WebElement</param>
        /// <param name="seconds">Optional time out value</param>
        protected void HoverWebElement(IWebElement webElement, int seconds = 3)
        {
            try
            {
                WaitForElementPresent(webElement, seconds);
                MoveToElement(webElement);
                Actions builder = new Actions(_driver);
                builder.MoveToElement(webElement).Build().Perform();
                Logger.Info("Hovered Web Element");
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to Hover element: {0}", e);
                Logger.Error(e, "Faile to hover element:" + e);
            }
        }

        /// <summary>
        /// Method to verify is element present
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        protected bool ElementIsPresent(By locator)
        {
            try
            {
                return _driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Method to scroll down to element provided
        /// </summary>
        /// <param name="webElement">web element </param>
        protected IWebElement ScrollToView(IWebElement webElement)
        {
            try
            {
                IWebElement ele = webElement;

                if (!webElement.Displayed)
                {
                    IJavaScriptExecutor je = (IJavaScriptExecutor)_driver;
                    je.ExecuteScript("arguments[0].scrollIntoView(true);", webElement);
                    ele = webElement;
                }

                return ele;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Unable to scroll to element");
                throw;
            }
        }

        /// <summary>
        /// Method to scroll down to element provided
        /// </summary>
        /// <param name="webElement">web element </param>
        protected void ScrollPageList(IWebElement element, int count)
        {
            try
            {
                //Actions act = new Actions(_driver);
                //act.SendKeys(element, OpenQA.Selenium.Keys.PageDown).Build().Perform();

                //act.(MouseButton.Middle).Build().Perform();
                IJavaScriptExecutor je = (IJavaScriptExecutor)_driver;
                je.ExecuteScript("arguments[0].scroll(0, 1100);", element);
            }
            catch (Exception e)
            {
                Logger.Error(e, "Unable to scroll to element");
                throw;
            }
        }

        public bool Scroll_Page(IWebElement webelement, int scrollPoints)
        {
            try
            {
                Actions dragger = new Actions(_driver);
                // drag downwards
                int numberOfPixelsToDragTheScrollbarDown = 10;
                for (int i = 10; i < scrollPoints; i = i + numberOfPixelsToDragTheScrollbarDown)
                {
                    dragger.MoveToElement(webelement).ClickAndHold().MoveByOffset(0, numberOfPixelsToDragTheScrollbarDown).Release(webelement).Build().Perform();
                }
                Thread.Sleep(500);
                return true;
            }
            catch (Exception e)
            {
                Logger.Error(e, "Failed to scroll page: genericbase");
                //e.printStackTrace();
                return false;
            }
        }

        /// <summary>
        /// Method to go back
        /// </summary>
        protected void GoBack()
        {
            _driver.Navigate().Back();
        }

        /// <summary>
        /// Method to go to Url
        /// </summary>
        /// <param name="url"></param>
        protected void GoToUrl(string url)
        {
            Logger.Info(string.Format("Navigating to URL: '{0}'", url), "");
            _driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Method to do refresh
        /// </summary>
        protected void Refresh()
        {
            _driver.Navigate().Refresh();
        }

        /// <summary>
        /// Method to set null instance
        /// </summary>
        protected void SetNullInstance()
        {
            _driverManager = DriverManager.SetInstanceToNull();
            Logger.Info("Setting browser instance to null", "");
        }

        /// <summary>
        /// Method to drag and drop element
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        protected void DragAndDropElement(IWebElement source, IWebElement destination)
        {
            Actions act = new Actions(_driver);
            act.DragAndDrop(source, destination).Build().Perform();
        }

        protected void SelectItemByVisibleText(IWebElement dropdownElement, string text)
        {
            try
            {
                SelectElement selectElement = new SelectElement(dropdownElement);
                selectElement.SelectByText(text);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Select Item by visible text " + dropdownElement + " text" + text);
                throw;
            }
        }
    }
}