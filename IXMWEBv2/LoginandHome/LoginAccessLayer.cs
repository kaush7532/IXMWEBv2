using System;
using IXMWEBv2.PageObjects;
using IXMWEBv2.Utils;
using IXMWEBv2.WebDriverFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IXMWEBv2.AccessLayer
{
    public class LoginAccessLayer
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        /// <summary>
        /// protected method for login page
        /// </summary>
        protected LoginPage_PO loginPage;

        public HomePage_PO _home;

        /// <summary>
        /// Constructor to initialize Driver Manager's instance by reading values from test.runsettings file
        /// </summary>
        public LoginAccessLayer()
        {
            _driver = DriverManager.GetInstance().GetDriver();
            _wait = DriverManager.GetInstance().GetWait();
            _home = new HomePage_PO();
            loginPage = new LoginPage_PO(_driver);
        }

        /// <summary>
        /// Method to login in access layer
        /// </summary>
        /// <param name="browser"></param>
        public LoginAccessLayer(string browser)
        {
            _driver = DriverManager.GetInstance(browser).GetDriver();
            _home = new HomePage_PO();
        }

        /// <summary>
        /// Method to sign in as username password from test.runsettings file
        /// </summary>
        /// <param name="timeOut">Specify explicit timeout</param>
        public void LoginIXMWeb(int timeOut = 30)
        {
            if (!loginPage.IsLoggedIn())
            {
                loginPage.Login(DriverManager.ixmWebUsername, DriverManager.ixmWebPassword, 30);
            }
        }

        /// <summary>
        /// Method to sign in providing username and password explicitly
        /// </summary>
        /// <param name="timeOut">Specify explicit timeout</param>
        public void LoginIXMWeb(string userName, string passWord, int timeOut = 30)
        {
            if (_driver.Title.Equals("Sign In with INVIXIUM ID", StringComparison.InvariantCultureIgnoreCase))
            {
                loginPage.Login(userName, passWord, 30);
            }
        }

        /// <summary>
        /// Method to logout from username dropdown
        /// </summary>
        public void Logout()
        {
            try
            {
                if (_home.TopBar.IsTopBarVisible())
                {
                    _home.TopBar.LogOut();
                }

                Assert.IsTrue(loginPage.PageElementsAreVisible());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Logout failed:");
                Assert.IsTrue(false);
            }
        }

        /// <summary>
        /// Method to quit the browser
        /// </summary>
        public void Quit()
        {
            loginPage.Quit();
            Logger.Info("Closing browser", "");
        }

        /// <summary>
        /// A function to validate web elements in Login page
        /// </summary>
        /// <returns></returns>
        public bool ValidateWebElementsLoginPage()
        {
            return loginPage.PageElementsAreVisible();
        }

        /// <summary>
        /// A function that returns login button status showing
        /// </summary>
        /// <returns></returns>
        public bool IsLoginButtonAvailable()
        {
            Assert.IsTrue(loginPage.IsLoginBtnVisible(), "Fail: Login button is not shown");
            return loginPage.IsLoginBtnVisible();
        }

        /// <summary>
        /// A function that returns forgot link status showing
        /// </summary>
        /// <returns></returns>
        public bool IsForgotorEmailLinkDisplayed()
        {
            return loginPage.IsForgotPwdorEmailLinkVisible();
        }

        /// <summary>
        /// A function that returns signed in status showing
        /// </summary>
        /// <returns></returns>
        public bool IsSignedInDisplayed()
        {
            Assert.IsTrue(loginPage.IsKeepMeSignedVisible(), "Fail: Keep me signed in not displayed");
            return loginPage.IsKeepMeSignedVisible();
        }

        public void GoToHomePageUrl()
        {
            if (!_driver.Title.Equals("Sign In with INVIXIUM ID", StringComparison.InvariantCultureIgnoreCase))
            {
                Logger.Info(string.Format("Navigating to URL: '{0}'", DriverManager.ixmWebUrl), "");
                _driver.Navigate().GoToUrl(DriverManager.ixmWebUrl);
            }
        }

        public void GoToUrl(string url)
        {
            Logger.Info(string.Format("Navigating to URL: '{0}'", url), "");
            _driver.Navigate().GoToUrl(url);
        }
    }
}