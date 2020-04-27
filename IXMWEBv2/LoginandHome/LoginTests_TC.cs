using IXMWEBv2.Constants;
using IXMWEBv2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IXMWEBv2.Tests.Home
{
    [TestClass]
    public class LoginTests_TC : BaseTest
    {
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        /// <summary>
        /// Method to verify login page UI elements
        /// </summary>
        [TestMethod]
        [TestCategory(TestSuite.UI), TestCategory(Module.LoginModule)]
        public void LoginPageUI()
        {
            try
            {
                loginAccessLayer.Logout();
                Assert.IsTrue(loginAccessLayer.IsForgotorEmailLinkDisplayed(), "Fail: Forgot Password link or Configure Email link not shown");

                loginAccessLayer.IsSignedInDisplayed();
                Assert.IsTrue(loginAccessLayer.ValidateWebElementsLoginPage(), "Fail: Unable to validate web elements on login page.");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to verify login page ui successfully");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Method to test Login
        /// </summary>
        [TestMethod]
        [TestCategory(TestSuite.Smoke), TestCategory(Module.LoginModule), TestCategory("Smoke")]
        public void AdminLogIn()
        {
            try
            {
                Logger.Info("Logging In", Module.LoginModule);
                loginAccessLayer.LoginIXMWeb();
                Assert.IsTrue(loginAccessLayer._home.IsUserLoggedIn(), "Fail: User is not logged in");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to login successfully");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// Method to test LogOut
        /// </summary>
        [TestMethod]
        [TestCategory(TestSuite.Smoke), TestCategory(Module.LoginModule)]
        public void LogOut()
        {
            try
            {
                loginAccessLayer.LoginIXMWeb();
                loginAccessLayer.Logout();
                Assert.IsTrue(loginAccessLayer.ValidateWebElementsLoginPage(), "Fail: After logout action this is not login page");
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unable to logout successfully");
                TestResult = TestResultType.Fail;
                Assert.Fail(ex.Message);
            }
        }

        //[TestMethod] // place only on the list--not the individuals
        //public void OrderedStepsTest()
        //{
        //    OrderedTest.Run(TestContext, new List<OrderedTest>
        //    {
        //        new OrderedTest ( LoginPageUI, false ),
        //        new OrderedTest ( AdminLogIn, false ),
        //        new OrderedTest ( LogOut, true ) // continue on failure
        //        // ...
        //    });
        //}

        [TestCleanup]
        public void Cleanup()
        {
            base.TearDown();
            //loginAccessLayer.GoToHomePageUrl();
        }

        [ClassCleanup]
        public static void Quit()
        {
            loginAccessLayer.Quit();
        }
    }
}