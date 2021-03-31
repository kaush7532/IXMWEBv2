using IXMWEBv2.Constants;
using IXMWEBv2.Resources.Locators.Users;
using IXMWEBv2.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace IXMWEBv2.PageObjects.EmployeePageObject
{
    public class AddEmployeePage_PO : GenericBasePage
    {
        //private IWebDriver driver;

        public AddEmployeePage_PO()
        {
            PageFactory.InitElements(_driver, this);
        }

        #region User Information elements

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.UserInformation)]
        private IWebElement userInformation { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.AddEmployeeBtn)]
        private IWebElement addEmployeeBtn { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.TitleDropDown)]
        private IWebElement titleDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.GenderDropDown)]
        private IWebElement genderDropDown { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.FirstNameTxt)]
        private IWebElement firstNameTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.DOBTxt)]
        private IWebElement dOBTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.LastNameTxt)]
        private IWebElement lastNameTxt { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.UserIdTxt)]
        private IWebElement userIdTxt { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.AddPicture)]
        private IWebElement addPicture { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.UserPhotoUploadWindow)]
        private IWebElement userPhotoUploadWindow { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.BrowsePictureBtn)]
        private IWebElement browsePictureBtn { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.UploadUserPhotoDoneBtn)]
        private IWebElement uploadUserPhotoDoneBtn { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.UserImportBtn)]
        private IWebElement userImportBtn { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.UserExportBtn)]
        private IWebElement userExportBtn { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.UserTransferBtn)]
        private IWebElement userTransferBtn { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.UserListLink)]
        private IWebElement userListLink { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.UserGroupLink)]
        private IWebElement userGroupLink { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.UserDeleteIcon)]
        private IWebElement userDeleteIcon { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.UserSearchIcon)]
        private IWebElement userSearchIcon { get; set; }

        #endregion User Information elements

        #region Contact Information Elements

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.ContactInformation)]
        private IWebElement contactInformation { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.Address1Txt)]
        private IWebElement address1Txt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.Address2Txt)]
        private IWebElement address2Txt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.CityTxt)]
        private IWebElement cityTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.StateTxt)]
        private IWebElement stateTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.ZIPCodeTxt)]
        private IWebElement zIPCodeTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.CountryTxt)]
        private IWebElement countryTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.HomePhoneTxt)]
        private IWebElement homePhoneTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.OfficePhoneTxt)]
        private IWebElement officePhoneTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.MobileTxt)]
        private IWebElement mobileTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.CompanyCodeTxt)]
        private IWebElement companyCodeTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.CompanyTxt)]
        private IWebElement companyTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.DepartmentTxt)]
        private IWebElement departmentTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.LocationTxt)]
        private IWebElement locationTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.EmailTxt)]
        private IWebElement emailTxt { get; set; }

        #endregion Contact Information Elements

        #region Access Control Information Elements

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.AccessControlInformation)]
        private IWebElement accessControlInformation { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.AccessRuleDropDown)]
        private IWebElement accessRuleDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.AccessScheduleDropDown)]
        private IWebElement AccessScheduleDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.FullAccessSchedule)]
        private IWebElement fullAccessSchedule { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.SecurityLevel1)]
        private IWebElement securityLevel1 { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.SecurityLevelN)]
        private IWebElement securityLevelN { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.UserTypeDropDown)]
        private IWebElement userTypeDropDown { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.StartDate)]
        private IWebElement startDate { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.EndDate)]
        private IWebElement endDate { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.OpenTimeChkBox)]
        private IWebElement openTimeChkBox { get; set; }

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.OpenTimeTxt)]
        private IWebElement openTimeTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.PinNumberTxt)]
        private IWebElement pinNumberTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.ProxIdTxt)]
        private IWebElement proxIdTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.FacilityCodeTxt)]
        private IWebElement facilityCodeTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.IssueLevelTxt)]
        private IWebElement issueLevelTxt { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.SmartCardIdTxt)]
        private IWebElement smartCardIdTxt { get; set; }

        #endregion Access Control Information Elements

        #region User Groups Information Elements

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.UserGroupsInformation)]
        private IWebElement userGroupsInformation { get; set; }

        #endregion User Groups Information Elements

        #region Buttons

        [FindsBy(How = How.XPath, Using = AddUserPageLocators.SaveBtn)]
        private IWebElement saveBtn { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.SaveAndStartEnrollmentBtn)]
        private IWebElement saveAndStartEnrollmentBtn { get; set; }

        #endregion Buttons

        #region Validation Message Box Elements

        [FindsBy(How = How.Id, Using = AddUserPageLocators.ValidationMsgWindow)]
        private IWebElement validationMsgWindow { get; set; }

        [FindsBy(How = How.Id, Using = AddUserPageLocators.ValidationMsgOkBtn)]
        private IWebElement validationMsgOkBtn { get; set; }

        #endregion Validation Message Box Elements

        //public AddEmployeePage_PO GoToAddUserPage()
        //{
        //    if (!_driver.Url.Contains(Urls.AddUserPageURL))
        //    {
        //        Logger.Info("Clicking on Add User Tile", Module.EmployeeModule.ToString());
        //        ClickElement(addUserTile);
        //    }
        //    else
        //    {
        //        Logger.Info("Current page is Add userpage", Module.EmployeeModule.ToString());
        //    }

        //    return new AddEmployeePage_PO();
        //}

        #region User Information related functions

        public bool IsUserInformationVisible()
        {
            WaitForVisibleElement(By.XPath(AddUserPageLocators.UserInformation));
            return userInformation.Displayed && userInformation.Enabled;
        }

        public bool IsAddemployeeBtnVisible()
        {
            try
            {
                WaitForVisibleElement(By.Id(AddUserPageLocators.AddEmployeeBtn));
                return addEmployeeBtn.Displayed && addEmployeeBtn.Enabled;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to check whether add employee button is visible or not");
                throw;
            }
        }

        public void ClickUserInformation()
        {
            if (IsUserInformationVisible())
            {
                ClickElement(userInformation);
            }
        }

        public void ClickAddEmployee()
        {
            try
            {
                if (IsAddemployeeBtnVisible())
                {
                    ClickElement(addEmployeeBtn);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to Click Add Employee button");
                throw;
            }
        }

        public void SetFirstName(string firstName = null)
        {
            try
            {
                string fname = string.IsNullOrEmpty(firstName) ? "FAuto" : firstName;
                EnterValueTextbox(firstNameTxt, fname + Utils.CommonUtils.GetDateTimeAsString());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to set first name in text box");
                throw;
            }
        }

        public void SetLastName(string lastName = null)
        {
            string lname = string.IsNullOrEmpty(lastName) ? "LAuto" : lastName;
            EnterValueTextbox(lastNameTxt, lname + Utils.CommonUtils.GetDateTimeAsString());
        }

        public string SetUserId(string userId = null)
        {
            try
            {
                string userID = string.IsNullOrEmpty(userId) ? "UID" + Utils.CommonUtils.GetDateTimeAsString() : userId;
                EnterValueTextbox(userIdTxt, userID);
                return userID;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to set userid in text box field");
                throw;
            }
        }

        public bool IsAddPictureLinkVisible()
        {
            WaitForElementPresent(addPicture);
            return addPicture.Displayed && addPicture.Enabled;
        }

        public void ClickAddPicture()
        {
            if (IsAddPictureLinkVisible())
            {
                ClickElement(addPicture);
            }
        }

        public bool IsBrowserBtnVisible()
        {
            WaitForVisibleElement(By.Id(AddUserPageLocators.BrowsePictureBtn));
            return browsePictureBtn.Enabled && browsePictureBtn.Displayed;
        }

        public void ClickBrowse()
        {
            if (IsBrowserBtnVisible())
            {
                //IWebElement browsePic = _driver.FindElement(By.Id(AddUserPageLocators.BrowsePictureBtn));
                ClickElement(browsePictureBtn);
            }
        }

        public void SetPicture()
        {
            string imagepath = Utils.CommonUtils.AssemblyPath + "\\TestData\\UserImage\\ValidFile.jpg";
            IWebElement browsePic = _driver.FindElement(By.XPath(AddUserPageLocators.BrowsePictureBtn));
            browsePic.SendKeys(imagepath);
        }

        public bool IsDoneBtnVisible()
        {
            WaitForVisibleElement(By.Id(AddUserPageLocators.UploadUserPhotoDoneBtn));
            return uploadUserPhotoDoneBtn.Enabled && uploadUserPhotoDoneBtn.Displayed;
        }

        public void ClickDoneBtn()
        {
            if (IsDoneBtnVisible())
            {
                ClickElement(uploadUserPhotoDoneBtn);
            }
        }

        public bool IsUSerPhotoUploadWindowDisappear()
        {
            WaitForElementDisappear(userPhotoUploadWindow);
            return !userPhotoUploadWindow.Displayed;
        }

        public void SetDOB()
        {
            EnterValueTextbox(dOBTxt, Utils.CommonUtils.GetDateOfBirth());
        }

        #endregion User Information related functions

        #region Contact Information related funcions

        public bool IsContactInfoVisible()
        {
            WaitElementToBeClickable(contactInformation);
            return contactInformation.Displayed && contactInformation.Enabled;
        }

        public void ClickContactInformation()
        {
            if (IsContactInfoVisible())
            {
                ClickElement(contactInformation);
                Logger.Info("Expanded Contact Information Section", Module.EmployeeModule.ToString());
            }
        }

        public void SetAddress1()
        {
            EnterValueTextbox(address1Txt, "Address1-" + Utils.CommonUtils.GetDateTimeAsString());
        }

        public void SetAddress2()
        {
            EnterValueTextbox(address2Txt, "Address2-" + Utils.CommonUtils.GetDateTimeAsString());
        }

        public void SetCity()
        {
            EnterValueTextbox(cityTxt, "Gandhinagar");
        }

        public void SetState()
        {
            EnterValueTextbox(stateTxt, "Gujarat");
        }

        public void SetZipCode()
        {
            EnterValueTextbox(zIPCodeTxt, Utils.CommonUtils.GetDateTimeAsString());
        }

        public void SetCountry()
        {
            EnterValueTextbox(countryTxt, "India");
        }

        public void SetHomePhone()
        {
            EnterValueTextbox(homePhoneTxt, Utils.CommonUtils.GetDateTimeAsString());
        }

        public void SetOfficePhome()
        {
            EnterValueTextbox(officePhoneTxt, Utils.CommonUtils.GetDateTimeAsString());
        }

        public void SetMobile()
        {
            EnterValueTextbox(mobileTxt, Utils.CommonUtils.GetDateTimeAsString());
        }

        public void SetCompanyCode()
        {
            EnterValueTextbox(companyCodeTxt, "CC" + Utils.CommonUtils.GetDateTimeAsString());
        }

        public void SetCompany()
        {
            EnterValueTextbox(companyTxt, "IXM");
        }

        public void SetDepartment()
        {
            EnterValueTextbox(departmentTxt, "QA");
        }

        public void SetLocation()
        {
            EnterValueTextbox(locationTxt, "Ahmedabad");
        }

        public bool IsEmailTxtVisible()
        {
            WaitForElementPresent(emailTxt);
            return emailTxt.Displayed;
        }

        public void SetEmailId()
        {
            EnterValueTextbox(emailTxt, Utils.CommonUtils.GetDateTimeAsString() + "@gmail.com");
        }

        #endregion Contact Information related funcions

        #region Access Information related functions

        public bool IsAccessControlInfoVisible()
        {
            WaitElementToBeClickable(accessControlInformation);
            return accessControlInformation.Displayed && accessControlInformation.Enabled;
        }

        public void ClickAccessControlInformation()
        {
            if (IsAccessControlInfoVisible())
            {
                ClickElement(accessControlInformation);
                Logger.Info("Expand Access Control Information Section", Module.EmployeeModule.ToString());
            }
        }

        public void ClickAccesScheduleDropDown()
        {
            ClickElement(AccessScheduleDropDown);
        }

        public void SelectAccessSchedule(string scheduleName)
        {
            try
            {
                IXMWebUtils.KendoDropDownSelectItemByValue(AddUserPageLocators.AccessScheduleDropDownId, scheduleName, _driver);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to select Access schedule " + scheduleName);
            }
        }

        public void SetStartDate()
        {
            EnterValueTextbox(startDate, Utils.CommonUtils.GetDateAsString());
        }

        public void SetEndDate()
        {
            EnterValueTextbox(endDate, Utils.CommonUtils.GetEndDateASString());
        }

        public void ClickOpenTimeChkBox()
        {
            ClickElement(openTimeChkBox);
        }

        public bool IsOpenTimeTxtVisible()
        {
            try
            {
                IWebElement txtBox = WaitForVisibleElement(By.XPath(AddUserPageLocators.OpenTimeTxt));
                Logger.Info("Open time text box is visible", Module.EmployeeModule.ToString());
                return txtBox.Displayed;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to find open time check box");
                return false;
            }
        }

        public void SetOpenTime()
        {
            try
            {
                if (IsOpenTimeTxtVisible())
                {
                    IWebElement txtBox = WaitForVisibleElement(By.XPath(AddUserPageLocators.OpenTimeTxt));
                    txtBox.SendKeys(DateTime.Now.ToString("mm"));
                    Logger.Info("Value enterd in open time check box", Module.EmployeeModule.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to enter value in open time check box");
            }
        }

        public void SetPinNumber()
        {
            EnterValueTextbox(pinNumberTxt, Utils.CommonUtils.GetDateTimeAsString());
        }

        public void SetProxId()
        {
            EnterValueTextbox(proxIdTxt, Utils.CommonUtils.GetDateTimeAsString());
        }

        public void SetFacilityCode()
        {
            EnterValueTextbox(facilityCodeTxt, Utils.CommonUtils.GetDateTimeAsString());
        }

        public void SetIssueLevel()
        {
            EnterValueTextbox(issueLevelTxt, (Utils.CommonUtils.GetDateTimeAsString()).Substring(0, 9));
        }

        public bool IsSmartCardTxtBoxVisible()
        {
            WaitForElementPresent(smartCardIdTxt);
            return smartCardIdTxt.Displayed;
        }

        public void SetSmartCardId()
        {
            EnterValueTextbox(smartCardIdTxt, "ABCDEF" + Utils.CommonUtils.GetDateTimeAsString());
        }

        #endregion Access Information related functions

        #region Save Buttons related functions

        public void ClickSaveBtn()
        {
            try
            {
                if (IsSaveBtnVisible())
                {
                    ClickElement(saveBtn);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to click on Save button");
                throw;
            }
        }

        //public EnrollmentAccessLayer ClickSaveAndStartEnrollmentBtn()
        //{
        //    ClickElement(saveAndStartEnrollmentBtn);
        //    Thread.Sleep(2000);
        //    return new EnrollmentAccessLayer();
        //}

        #endregion Save Buttons related functions

        public bool IsValidationMsgBoxVisible()
        {
            WaitForVisibleElement(By.Id(AddUserPageLocators.ValidationMsgWindow));
            return validationMsgWindow.Displayed && validationMsgWindow.Enabled;
        }

        public string ValidationMsgText()
        {
            return validationMsgWindow.Text;
        }

        public void ValidationMsgOkBtn()
        {
            ClickElement(validationMsgOkBtn);
        }

        /// <summary>
        /// A method to verify if web elements in AddUser page are present
        /// </summary>
        /// <returns>Status of web elements</returns>
        public bool PageElementsAreVisible()
        {
            //WaitForElementPresent(saveBtn);
            if (IsElementPresent(addEmployeeBtn) &&
                IsElementPresent(userExportBtn) &&
                IsElementPresent(userGroupLink) &&
                IsElementPresent(userListLink) &&
                IsElementPresent(userTransferBtn) &&
                IsElementPresent(userDeleteIcon) &&
                IsElementPresent(userSearchIcon))
                return true;
            return false;
        }

        public bool UserInformationElementsAreVisible()
        {
            WaitForElementPresent(saveBtn);
            if (IsElementPresent(addPicture) &&
                IsElementPresent(titleDropDown) &&
                IsElementPresent(genderDropDown) &&
                IsElementPresent(firstNameTxt) &&
                IsElementPresent(lastNameTxt) &&
                IsElementPresent(userIdTxt) &&
                IsElementPresent(dOBTxt))
                return true;
            return false;
        }

        public bool ContactInformationElementsAreVisible()
        {
            WaitForElementPresent(emailTxt);
            if (IsElementPresent(address1Txt) &&
                IsElementPresent(address2Txt) &&
                IsElementPresent(cityTxt) &&
                IsElementPresent(stateTxt) &&
                IsElementPresent(zIPCodeTxt) &&
                IsElementPresent(countryTxt) &&
                IsElementPresent(homePhoneTxt) &&
                IsElementPresent(officePhoneTxt) &&
                IsElementPresent(mobileTxt) &&
                IsElementPresent(companyCodeTxt) &&
                IsElementPresent(companyTxt) &&
                IsElementPresent(departmentTxt) &&
                IsElementPresent(locationTxt) &&
                IsElementPresent(emailTxt))
            {
                Logger.Info("All Contact Information UI elements are present", Module.EmployeeModule.ToString());
                return true;
            }
            else
            {
                Logger.Error("Contact Information UI elements are not present", Module.EmployeeModule.ToString());
                return false;
            }
        }

        public bool AccessControlElementsAreVisible()
        {
            WaitForElementPresent(smartCardIdTxt, 10);
            if (IsElementPresent(accessRuleDropDown) &&
                IsElementPresent(AccessScheduleDropDown) &&
                IsElementPresent(securityLevel1) &&
                IsElementPresent(securityLevelN) &&
                IsElementPresent(userTypeDropDown) &&
                IsElementPresent(startDate) &&
                IsElementPresent(endDate) &&
                IsElementPresent(proxIdTxt) &&
                IsElementPresent(facilityCodeTxt) &&
                IsElementPresent(issueLevelTxt) &&
                IsElementPresent(smartCardIdTxt))
            {
                Logger.Info("Access Control Information UI elements are present", Module.EmployeeModule.ToString());
                return true;
            }
            else
            {
                Logger.Error("Access Control Information UI elements are not present", Module.EmployeeModule.ToString());
                return false;
            }
        }

        public bool IsSaveBtnVisible()
        {
            try
            {
                WaitForVisibleElement(By.XPath(AddUserPageLocators.SaveBtn));
                WaitForElementPresent(saveBtn);
                return saveBtn.Displayed && saveBtn.Enabled;
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Failed to check whether save button is visible or not");
                throw;
            }
        }

        public bool isSaveAndEnrollmentBtnVisible()
        {
            WaitForElementPresent(saveAndStartEnrollmentBtn);
            return saveAndStartEnrollmentBtn.Displayed && saveAndStartEnrollmentBtn.Enabled;
        }
    }
}