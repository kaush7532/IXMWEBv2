using IXMWEBv2.AccessLayer.EmployeeAccessLayer;
using IXMWEBv2.Constants;
using IXMWEBv2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace IXMWEBv2.Tests.Employees
{
    [TestClass]
    public class AddEmployee_TC : BaseTest
    {
        private AddEmployeeAccessLayer addEmployeeAccessLayer;
        //private EmployeeAllAccessLayer userallAL;

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
            loginAccessLayer.LoginIXMWeb();
            // Debug.WriteLine("1");
            //ixmUtils.SelectDevice(DriverManager.onlineDeviceName);
            //Debug.WriteLine("2");
            ixmUtils.GoToTab(MainTabs.Employee);
            addEmployeeAccessLayer = new AddEmployeeAccessLayer();
            // userallAL = new EmployeeAllAccessLayer(false);
        }

        [TestMethod]
        [TestCategory(TestSuite.UI), TestCategory(Module.EmployeeModule)]
        public void AddUserPageUI()
        {
            try
            {
                Assert.IsTrue(addEmployeeAccessLayer.ValidateAddEmployeePageUI());
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to verify adduser page ui successfully");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        //[TestMethod]
        //[TestCategory(TestSuite.UI), TestCategory(Module.EmployeeModule)]
        //public void UserInformationUI()
        //{
        //    try
        //    {
        //        Assert.IsTrue(addEmployeeAccessLayer.ValidateUserInformationUI());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to verify user information section ui successfully");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //[TestCategory(TestSuite.UI), TestCategory(Module.EmployeeModule)]
        //public void ContactInformationUI()
        //{
        //    try
        //    {
        //        Assert.IsTrue(addEmployeeAccessLayer.ValidateContactInformationUI());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to verify contact information section ui successfully");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //[TestCategory(TestSuite.UI), TestCategory(Module.EmployeeModule)]
        //public void AccessControlUI()
        //{
        //    try
        //    {
        //        Assert.IsTrue(addEmployeeAccessLayer.ValidateAccessControlUI());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to verify access control information section ui successfully");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        [TestMethod]
        [TestCategory(TestSuite.Functional), TestCategory(Module.EmployeeModule)]
        public void AddUserWithMandatoryFields()
        {
            try
            {
                //Add user with mandatory fields
                addEmployeeAccessLayer.AddWithMandatoryFields();
                Logger.Info("User Added With Mandatory Fields", Module.EmployeeModule.ToString());

                //Verify success message in application logs window
                Assert.IsTrue(ixmUtils.VerifySuccessOnAppWindow());

                //Verify newly created user on userall's page
                // Assert.IsTrue(userallAL.isUserCreated(addEmployeeAccessLayer.userID));

                //verify newly created user in database
                var allUserids = dbInteraction.GetUserIDsFromDb();
                bool result = allUserids.Any(x => x.Equals(addEmployeeAccessLayer.userID));
                Assert.IsTrue(result, "Failed: DB verification " + addEmployeeAccessLayer.userID + " is not saved successfully in database");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to add user with mandatory fields successfully");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        //[TestMethod]
        //[TestCategory(TestSuite.Functional), TestCategory(Module.EmployeeModule)]
        //public void AddUserWithValidData()
        //{
        //    try
        //    {
        //        //Add user with valid data
        //        addEmployeeAccessLayer.AddWithValidData();
        //        Logger.Info("User Added with all valid fields", Module.EmployeeModule.ToString());

        //        //Verify success message in application logs window
        //        Assert.IsTrue(ixmUtils.VerifySuccessOnAppWindow());

        //        //Verify newly created user on userall's page
        //        Assert.IsTrue(userallAL.isUserCreated(addEmployeeAccessLayer.userID));

        //        //verify newly created user in database
        //        Assert.IsTrue(dbInteraction.DoUserExsistsInDB(dbInteraction.GetUserIDsFromDb(), addEmployeeAccessLayer.userID),
        //            "Failed: DB verification " + addEmployeeAccessLayer.userID + " is not saved successfully in database");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to add user with valid data successfully");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //[TestCategory(TestSuite.Functional), TestCategory(Module.EmployeeModule)]
        //public void AddUserWithPhoto()
        //{
        //    try
        //    {
        //        //Add user with photo
        //        addEmployeeAccessLayer.AddWithPhoto();
        //        Logger.Info("User Added with Photo", Module.EmployeeModule.ToString());

        //        //Verify success message in application logs window
        //        Assert.IsTrue(ixmUtils.VerifySuccessOnAppWindow());

        //        //Verify newly created user on userall's page
        //        //Assert.IsTrue(userallAL.isUserCreated(addEmployeeAccessLayer.userID));

        //        //verify newly created user in database
        //        Assert.IsTrue(dbInteraction.DoUserExsistsInDB(dbInteraction.GetUserIDsFromDb(), addEmployeeAccessLayer.userID), "Failed: DB verification " + addEmployeeAccessLayer.userID + " is not saved successfully in database");

        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to add user with photo successfully");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //[TestCategory(TestSuite.Functional), TestCategory(Module.EmployeeModule)]
        //public void AddUserWithBiometrics()
        //{
        //    try
        //    {
        //        //Add user along with biometric
        //        addEmployeeAccessLayer.AddWithBiometrics(FingerIndex.RightHandIndex);
        //        Logger.Info("User Added with Biometrics", Module.EmployeeModule.ToString());

        //        //Verify success message in application logs window
        //        Assert.IsTrue(ixmUtils.VerifySuccessOnAppWindow());

        //        //Verify newly created user on userall's page
        //        Assert.IsTrue(userallAL.isUserCreated(addEmployeeAccessLayer.userID));

        //        //verify newly created user in database
        //        Assert.IsTrue(dbInteraction.DoUserExsistsInDB(dbInteraction.GetUserIDsFromDb(), addEmployeeAccessLayer.userID),
        //            "Failed: DB verification " + addEmployeeAccessLayer.userID + " is not saved successfully in database");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to add user with biometrics successfully");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //[TestCategory(TestSuite.Functional), TestCategory(Module.EmployeeModule)]
        //public void AddUserWithOutFirstName()
        //{
        //    try
        //    {
        //        Assert.Equals(addEmployeeAccessLayer.AddWithOutFirstName(), "Enter First Name");
        //        Logger.Info("User Not added without firstname", Module.EmployeeModule.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Error(ex, "Unable to verify negative adduser test successfully");
        //        TestResult = TestResultType.Fail;
        //        Assert.Fail(ex.Message);
        //    }
        //}

        //[TestMethod]
        //[TestCategory(TestSuite.Functional), TestCategory(Module.EmployeeModule)]
        //public void AddEmployeeWithAllFields()
        //{
        //    try
        //    {
        //    }
        //    catch(Exception ex)
        //    {
        //    }

        //}

        [TestCleanup]
        public void Cleanup()
        {
            base.TearDown();
            //loginAccessLayer.GoToUrl(Urls.UsersPageURL);
        }

        [ClassCleanup]
        public static void Quit()
        {
            //loginAccessLayer.GoToHomePageUrl();
            loginAccessLayer.Quit();
        }
    }
}