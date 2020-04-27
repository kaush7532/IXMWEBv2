using IXMWEBv2.Constants;
using IXMWEBv2.Resources.Locators;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace IXMWEBv2.PageObjects
{
    public class LoginPage_PO : GenericBasePage
    {
        private IWebDriver driver;

        public LoginPage_PO(IWebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = LoginPageLocators.UserNameTxt)]
        private IWebElement UsernameTxt { get; set; }

        [FindsBy(How = How.Id, Using = LoginPageLocators.PasswordTxt)]
        private IWebElement PasswordTxt { get; set; }

        [FindsBy(How = How.XPath, Using = LoginPageLocators.SignInBtn)]
        private IWebElement SignInBtn { get; set; }

        [FindsBy(How = How.LinkText, Using = LoginPageLocators.ForgotPasswordLink)]
        private IWebElement ForgotLink { get; set; }

        [FindsBy(How = How.Id, Using = LoginPageLocators.KeepSignedIn)]
        private IWebElement KeepSignedIn { get; set; }

        [FindsBy(How = How.Id, Using = LoginPageLocators.ConfigureEmailLink)]
        private IWebElement EmailLink { get; set; }

        [FindsBy(How = How.XPath, Using = LoginPageLocators.OverviewDashboard)]
        private IWebElement overviewDashboard { get; set; }

        public void SetUserName(string username)
        {
            EnterValueTextbox(UsernameTxt, username);
        }

        public void SetPassword(string userPassword)
        {
            EnterValueTextbox(PasswordTxt, userPassword);
        }

        public void SelectKeepSignedIn()
        {
            if (!IsSelectedKeepMeSignedIn())
            {
                ClickElement(KeepSignedIn);
            }
        }

        public void ClickSignInBtn()
        {
            ClickElement(SignInBtn);
            Logger.Info("Logged in to IXM Web", Module.LoginModule);
        }

        /// <summary>
        /// Method to verify status of 'Keep me signed in' checkbox
        /// </summary>
        /// <returns>Status of checkbox</returns>
        public bool IsSelectedKeepMeSignedIn()
        {
            return KeepSignedIn.Selected;
        }

        public bool IsLoggedIn()
        {
            bool result = false;
            try
            {
                result = !IsElementPresent(SignInBtn);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Is Logged in Check Failed");
                throw;
            }
            return result;
        }

        /// <summary>
        /// A method to Sign In given username and password fields
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="timeOut">Specify explicit timeout</param>
        public void Login(string username, string password, int timeOut = 30)
        {
            try
            {
                WaitForElementPresent(SignInBtn, timeOut);
                Logger.Info(string.Format("Logging in to IXM Web with uname: '{0}' and pwd: '{1}'.", username, password), Module.LoginModule);
                SetUserName(username);
                SetPassword(password);
                ClickSignInBtn();
                WaitForVisibleElement(By.Id(LoginPageLocators.OverviewDashboard));
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Login as failed");
                throw;
            }
        }

        /// <summary>
        /// A method to verify if web elements in Login page are present
        /// </summary>
        /// <returns>Status of web elements</returns>
        public bool PageElementsAreVisible()
        {
            Logger.Info("Verifying login page UI elements", Module.LoginModule);
            WaitForElementPresent(SignInBtn);
            if (IsElementPresent(UsernameTxt) &&
                IsElementPresent(PasswordTxt) &&
                IsLoginBtnVisible() &&
                IsKeepMeSignedVisible())
                return true;
            return false;
        }

        public bool IsLoginBtnVisible()
        {
            WaitForElementPresent(SignInBtn);
            return SignInBtn.Displayed && SignInBtn.Enabled;
        }

        public bool IsForgotPwdorEmailLinkVisible()
        {
            return IsForgotPasswordLinkVisible() || IsConfigureEmailLinkVisible();
        }

        public bool IsKeepMeSignedVisible()
        {
            WaitForElementPresent(KeepSignedIn);
            return KeepSignedIn.Displayed;
        }

        public bool IsForgotPasswordLinkVisible()
        {
            return IsElementPresent(ForgotLink, 3);
        }

        public bool IsConfigureEmailLinkVisible()
        {
            return IsElementPresent(EmailLink, 3);
        }

        /// <summary>
        /// Method to quit the browser
        /// </summary>
        public void Quit()
        {
            SetNullInstance();
            _driver.Quit();
        }
    }
}