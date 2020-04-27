using IXMWEBv2.Constants;
using IXMWEBv2.WebDriverFactory;
using Microsoft.Expression.Encoder.ScreenCapture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace IXMWEBv2.Utils
{
    public class CommonUtils
    {
        private static ScreenCaptureJob job = new ScreenCaptureJob();
        public static string AssemblyPath;
        private static Screenshot _screenshot;
        private static ITakesScreenshot _screenshotDriver;

        #region Video Recording Methods

        /// <summary>
        /// Start Video Recording
        /// </summary>
        public static void StartVideoRecord()
        {
            job.CaptureMouseCursor = true;
            job.ScreenCaptureVideoProfile.AutoFit = true;

            job.OutputScreenCaptureFileName = AssemblyPath + "\\Results\\" + DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss") + ".wmv";

            job.Start();
            Logger.Info("Started Video Recording.", null);
        }

        /// <summary>
        /// Stop Video Recording
        /// </summary>
        public static void StopVideoRecord()
        {
            job.Stop();
            Logger.Info("Stopped Video Recording.", null);
        }

        #endregion Video Recording Methods

        /// <summary>
        /// A method to save execution status
        /// </summary>
        /// <param name="testContext"></param>
        public static void SaveTestStatus(TestContext testContext, TestResultType resulttype, Result result)
        {
            result.WriteTestResult(resulttype, testContext.TestName, TakeScreenshot(testContext));
        }

        public static string GetCheckBoxId(string elementpath)
        {
            string result = null;
            var val = Regex.Match(elementpath, "@id='[a-z, A-Z, 0-9]*'");
            if (val.Success)
            {
                result = val.Value.Substring(5).Replace("'", "");
            }
            return result;
        }

        /// <summary>
        /// A method to take a screenshot
        /// </summary>
        /// <param name="testContext"></param>
        public static string TakeScreenshot(TestContext testContext)
        {
            string testCasePath = string.Empty;
            try
            {
                string timeStampScreenshot = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
                _screenshotDriver = DriverManager.GetInstance().GetDriver() as ITakesScreenshot;
                _screenshot = _screenshotDriver.GetScreenshot();
                string screenshotDir = testContext.DeploymentDirectory + "\\Results\\Screenshots\\";

                if (!Directory.Exists(screenshotDir))
                {
                    Directory.CreateDirectory(screenshotDir);
                }

                testCasePath = screenshotDir + testContext.TestName + "_" + timeStampScreenshot + ".png";
                Logger.Info(string.Format("Taking Screenshot for test: '{0}'", testContext.TestName), "");
                _screenshot.SaveAsFile(testCasePath, ScreenshotImageFormat.Png);

                //TODO: Get the testContext out of this class
                testContext.AddResultFile(Path.Combine(testContext.TestDeploymentDir, testCasePath));
                testContext.AddResultFile(Path.Combine(testContext.TestDeploymentDir, "Execution.log"));
            }
            catch (Exception e)
            {
                Console.WriteLine("\n TakeIt: \n" + e);
            }
            return Path.GetFullPath(testCasePath);
        }

        /// <summary>
        /// A method that generates a random number based on cureent date and time
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeAsString(string format = null)
        {
            string currenttime = null;
            if (format != null)
                currenttime = DateTime.Now.ToString(format);
            else
                currenttime = DateTime.Now.ToString("ddHHmmssff");
            return currenttime;
        }

        public static string GetDateAsString()
        {
            string currentdate = null;
            currentdate = DateTime.Now.ToString("MM/dd/yyyy");
            return currentdate;
        }

        public static string GetEndDateASString()
        {
            DateTime currentdate = DateTime.Now;
            currentdate = currentdate.AddMonths(2);
            string enddate = null;
            enddate = currentdate.ToString("MM/dd/yyyy");
            return enddate;
        }

        public static string GetDateOfBirth()
        {
            DateTime currentdate = DateTime.Now;
            currentdate = currentdate.AddYears(-20);
            string dob = null;
            dob = currentdate.ToString("MM/dd/yyyy");
            return dob;
        }

        ///// <summary>
        ///// Take screenshot and save it for every exception events raised, add an event listener to browser instance
        /////
        ///// ie:
        /////     var firingDriver = new EventFiringWebDriver(_driver);
        /////     firingDriver.ExceptionThrown += this.FiringDriverTakeScreenshotOnException;
        /////     _driver = firingDriver;
        /////     _driver.Navigate().GoToUrl("http://yizeng.me");
        /////     _driver.FindElement(By.Id("no-existing ID"));
        /////
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e">Exception details raised</param>
        //public void DriverTakeScreenshotOnException(object sender, WebDriverExceptionEventArgs e)
        //{
        //    string timeStampScreenshot = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
        //    _screenshotDriver = _driver as ITakesScreenshot;
        //    _screenshot = _screenshotDriver.GetScreenshot();
        //    Debug.Print(e.ThrownException.ToString());
        //    _screenshot.SaveAsFile("Exception-" + timeStampScreenshot + ".png", ScreenshotImageFormat.Png);
        //}
    }
}