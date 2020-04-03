using System;
using IXMWEBv2.AccessLayer.EmployeeAccessLayer;
using IXMWEBv2.Resources.Locators.Users;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using IXMWEBv2.Employees.EmployeeList;

namespace IXMWEBv2.PageObjects.EmployeePageObject
{
    public class EmployeeAllPage_PO : GenericBasePage
    {
        public EmployeeAllPage_PO()
        {
            // IXMWebUtils.OfflineDeviceWait(_driver);
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = EmployeeListPageLocators.UserAllTile)]
        private IWebElement UserAllTile { get; set; }

        [FindsBy(How = How.Id, Using = EmployeeListPageLocators.TransferBtn)]
        private IWebElement TransferBtn { get; set; }

        [FindsBy(How = How.XPath, Using = EmployeeListPageLocators.TransferAllBtn)]
        private IWebElement TransferAllBtn { get; set; }

        [FindsBy(How = How.Id, Using = EmployeeListPageLocators.AddBtn)]
        private IWebElement AddUserBtn { get; set; }

        [FindsBy(How = How.Id, Using = EmployeeListPageLocators.OverwriteBtn)]
        private IWebElement OverwriteBtn { get; set; }

        public EmployeeAllPage_PO GoToUserAllTile()
        {
            //if (!_driver.Url.Contains(Urls.UserAllURL))
            //{
            //    Logger.Info("Clicking on Add User Tile", Modules.Users.ToString());
            //    ClickElement(UserAllTile);
            //}
            //else
            //{
            //    Logger.Info("Current page is Add userpage", Modules.Users.ToString());
            //}

            return new EmployeeAllPage_PO();
        }

        /// <summary>
        /// Replaces #USERID in xpath to the current userid which is created
        /// </summary>
        /// <param name="userId">current userid is passed as parameter</param>
        /// <returns>Returns "True" if able to find element with created xpath else returns "False"</returns>
        public bool doesUserWithIDPresent(string userId)
        {
            string userIDXpath = EmployeeListPageLocators.UserID.Replace("#USERID", userId);
            IWebElement userID = _driver.FindElement(By.XPath(userIDXpath));
            return userID.Displayed;
        }

        public bool IsTranserVisible()
        {
            WaitForVisibleElement(By.Id(EmployeeListPageLocators.TransferBtn));
            return TransferBtn.Displayed && TransferBtn.Enabled;
        }

        public void HoverTransferBtn()
        {
            if (IsTranserVisible())
            {
                HoverWebElement(TransferBtn);
            }
        }

        public bool IsTransferAllBtnVisible()
        {
            WaitForVisibleElement(By.XPath(EmployeeListPageLocators.TransferAllBtn));
            return TransferAllBtn.Displayed && TransferAllBtn.Enabled;
        }

        public void ClickTransferAllBtn()
        {
            HoverTransferBtn();
            if (IsTransferAllBtnVisible())
            {
                ClickElement(TransferAllBtn);
            }
        }

        public void ClickOverwriteBtn()
        {
            try
            {
                WaitElementToBeClickable(OverwriteBtn);
                ClickElement(OverwriteBtn);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to click overwrite button");
                throw;
            }
        }

        public AddEmployeeAccessLayer ClickAddButton()
        {
            try
            {
                ClickElement(AddUserBtn);
                return new AddEmployeeAccessLayer();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to click add button");
                throw;
            }
        }
    }
}