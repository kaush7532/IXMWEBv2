using IXMWEBv2.PageObjects.EmployeePageObject;
using IXMWEBv2.Utils;
using System;

namespace IXMWEBv2.AccessLayer.EmployeeAccessLayer
{
    public class AddEmployeeAccessLayer
    {
        public AddEmployeePage_PO addEmployee;
        public AddEmployeeAccessLayer enroll;
        public string userID = null;

        public AddEmployeeAccessLayer()
        {
            addEmployee = new AddEmployeePage_PO();
            //addEmployee.
        }

        public bool ValidateAddEmployeePageUI()
        {
            return addEmployee.PageElementsAreVisible();
        }

        public bool ValidateUserInformationUI()
        {
            return addEmployee.UserInformationElementsAreVisible();
        }

        public bool ValidateContactInformationUI()
        {
            addEmployee.ClickContactInformation();
            return addEmployee.ContactInformationElementsAreVisible();
        }

        public bool ValidateAccessControlUI()
        {
            addEmployee.ClickAccessControlInformation();
            return addEmployee.AccessControlElementsAreVisible();
        }

        public void AddWithMandatoryFields()
        {
            addEmployee.ClickAddEmployee();
            addEmployee.SetFirstName();
            userID = addEmployee.SetUserId();

            addEmployee.IsSaveBtnVisible();
            addEmployee.ClickSaveBtn();
        }

        public void AddWithMandatoryFields(string userId, string firstName)
        {
            addEmployee.SetFirstName(firstName);
            userID = addEmployee.SetUserId(userId);
            addEmployee.IsSaveBtnVisible();
            addEmployee.ClickSaveBtn();
        }

        /// <summary>
        /// Adding user with valid data
        /// </summary>
        public void AddWithValidData()
        {
            try
            {
                addEmployee.SetFirstName();
                userID = addEmployee.SetUserId();
                addEmployee.SetLastName();
                addEmployee.SetDOB();
                addEmployee.IsContactInfoVisible();
                addEmployee.ClickContactInformation();
                addEmployee.IsEmailTxtVisible();
                addEmployee.SetAddress1();
                addEmployee.SetAddress2();
                addEmployee.SetCity();
                addEmployee.SetState();
                addEmployee.SetZipCode();
                addEmployee.SetCountry();
                addEmployee.SetHomePhone();
                addEmployee.SetOfficePhome();
                addEmployee.SetMobile();
                addEmployee.SetCompanyCode();
                addEmployee.SetCompany();
                addEmployee.SetDepartment();
                addEmployee.SetLocation();
                addEmployee.SetEmailId();
                addEmployee.IsAccessControlInfoVisible();
                addEmployee.ClickAccessControlInformation();
                addEmployee.IsSmartCardTxtBoxVisible();
                addEmployee.SelectAccessSchedule("Full Access");
                //addUser.ClickOpenTimeChkBox();
                //addUser.SetOpenTime();
                addEmployee.SetStartDate();
                addEmployee.SetEndDate();
                addEmployee.SetPinNumber();
                addEmployee.SetProxId();
                addEmployee.SetFacilityCode();
                addEmployee.SetIssueLevel();
                addEmployee.SetSmartCardId();
                addEmployee.ClickSaveBtn();
                Logger.Info("User added with valid data, method executed successfully in accesslayer");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to add user with valid data, method failed in accesslayer");
            }
        }

        //public void AddWithPhoto()
        //{
        //    addEmployee.AddEmployeeModule();
        //    addEmployee.SetFirstName();
        //    addEmployee.SetLastName();
        //    userID = addEmployee.SetUserId();
        //    addEmployee.ClickAddPicture();
        //    addEmployee.ClickBrowse();
        //    addEmployee.SetPicture();
        //    addEmployee.ClickDoneBtn();
        //    addEmployee.IsUSerPhotoUploadWindowDisappear();
        //    addEmployee.ClickSaveBtn();
        //}

        //public void AddWithBiometrics(FingerIndex fingerIndex)
        //{
        //    try
        //    {
        //        addEmployee.SetFirstName();
        //        addEmployee.SetLastName();
        //        userID = addEmployee.SetUserId();
        //        addEmployee.isSaveAndEnrollmentBtnVisible();
        //        enroll = addEmployee.ClickSaveAndStartEnrollmentBtn();
        //        enroll.EnrollFinger(fingerIndex);
        //        Thread.Sleep(2000);
        //        enroll.ContinueSavingUserAfterEnrollment();
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Failed to do add user with biometrics.");
        //        throw;
        //    }
        //}

        public string AddWithOutFirstName()
        {
            string msg = null;
            addEmployee.SetUserId();
            addEmployee.ClickSaveBtn();
            if (addEmployee.IsValidationMsgBoxVisible())
            {
                msg = addEmployee.ValidationMsgText().ToString();
                addEmployee.ValidationMsgOkBtn();
                return msg;
            }
            else
            {
                Logger.Info("Unable to find validation box");
                return msg;
            }
        }
    }
}