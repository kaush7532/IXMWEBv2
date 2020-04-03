namespace IXMWEBv2.Resources.Locators.Users
{
    public class AddUserPageLocators
    {
        public const string AddEmployeeBtn = "AddUserLink";

        #region User Information web locators

        public const string UserInformation = ".//*[@id='ethernet_text']//div[normalize-space(text())='User Information']";
        public const string TitleDropDown = ".//*[@id='wrapper']/div[2]/table/tbody/tr/td[2]/table/tbody/tr[1]/td[2]/div/table/tbody/tr/td[1]/span/span/span[2]/span";
        public const string GenderDropDown = ".//*[@id='wrapper']/div[2]/table/tbody/tr/td[2]/table/tbody/tr[1]/td[4]/div/table/tbody/tr/td[1]/span/span/span[2]/span";
        public const string FirstNameTxt = "FirstName";
        public const string LastNameTxt = "LastName";
        public const string UserIdTxt = "//div[@class='col-md-25']//input[@id='UserId']";
        public const string AddPicture = "//span[@class='edit-btn align-with-container']//a";
        public const string UserPhotoUploadWindow = "UserPhotoWindow_wnd_title";
        public const string BrowsePictureBtn = "//div[@id='userphotodivset']//div[@class='k-upload-button btn-Primary']";
        public const string UploadUserPhotoDoneBtn = "btnDone";
        public const string DOBTxt = "DOB";

        public const string UserListLink = "home-tab";
        public const string UserGroupLink = "GroupTab";
        public const string UserTransferBtn = "TransferLink";
        public const string UserExportBtn = "ExportLink";
        public const string UserImportBtn = "ImportLink";
        public const string UserDeleteIcon = "//div[@class='right-icons']//a[2]";
        public const string UserSearchIcon = "//a[@class='all-search']";

        #endregion User Information web locators

        #region Contact Information Locators

        public const string ContactInformation = ".//*[@id='ethernet_text']//div[normalize-space(text())='Contact Information']";
        public const string Address1Txt = "Street1";
        public const string Address2Txt = "Street2";
        public const string CityTxt = "City";
        public const string StateTxt = "State";
        public const string ZIPCodeTxt = "ZipCode";
        public const string CountryTxt = "Country";
        public const string HomePhoneTxt = "HomePhoneNo";
        public const string OfficePhoneTxt = "OfficePhoneNo";
        public const string MobileTxt = "MobileNo";
        public const string CompanyCodeTxt = "CompanyCode";
        public const string CompanyTxt = "Company";
        public const string DepartmentTxt = "Department";
        public const string LocationTxt = "Location";
        public const string EmailTxt = "Email";

        #endregion Contact Information Locators

        #region Access Control Information web locators

        public const string AccessControlInformation = ".//*[@id='ethernet_text']//span[normalize-space(text())='Access Control Information']";
        public const string AccessRuleDropDown = ".//*[@id='wrapper']/div[7]/table/tbody/tr[1]/td[2]/div/table/tbody/tr/td[1]/span/span/span[2]/span";
        public const string AccessScheduleDropDown = ".//*[@id='AccessSchedule']//preceding-sibling::span/span/span";
        public const string FullAccessSchedule = ".//*[@id='AccessSchedule_listbox']/li[contains(text(),'Full Access')]";
        public const string AccessScheduleDropDownId = "AccessSchedule";

        //public const string HolidaysSwitchBtn = "ui-switchbutton-handle";
        public const string SecurityLevel1 = ".//*[@id='EditVerificationSecurity']/span/span/span[2]/span";

        public const string SecurityLevelN = ".//*[@id='EditIdentitySecurity']/span/span/span[2]/span";
        public const string OpenTimeChkBox = "chkDoorTimeOut";
        public const string OpenTimeTxt = "DoorTimeOut";
        public const string StartDate = "StartDate";
        public const string EndDate = "ExpiryDate";

        //public const string SuspendUserSwitchBtn = "ExpiryDate";
        public const string PinNumberTxt = "PinNumber";

        public const string UserTypeDropDown = ".//*[@id='wrapper']/div[7]/table/tbody/tr[4]/td[4]/div/table/tbody/tr/td[1]/span/span/span[2]/span";

        //public const string AntiPassBackSwitchBtn = "PinNumber";
        public const string ProxIdTxt = "ProxId";

        public const string FacilityCodeTxt = "FacilityCode";
        public const string IssueLevelTxt = "IssueLevel";
        public const string SmartCardIdTxt = "SmartCardId";

        #endregion Access Control Information web locators

        #region User Groups Locators

        public const string UserGroupsInformation = ".//*[@id='ethernet_text']//span[normalize-space(text())='User Groups']";

        #endregion User Groups Locators

        #region Add User page button locators

        public const string SaveBtn = "//section[@class='form_section User information-section step1']//i[@class='fa fa-floppy-o']";
        public const string SaveAndStartEnrollmentBtn = "btnUserSavecontinue";

        #endregion Add User page button locators

        #region Validation message box locators

        public const string ValidationMsgWindow = "window_wnd_title";
        public const string ValidationMsgOkBtn = "OK";

        #endregion Validation message box locators
    }
}