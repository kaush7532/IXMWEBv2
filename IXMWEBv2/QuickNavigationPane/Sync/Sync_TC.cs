using IXMWEBv2.Constants;
using IXMWEBv2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IXMWEBv2.QuickNavigationPane.Sync
{
    [TestClass]
    public class Sync_TC : BaseTest
    {
        private Sync_AL syncAccessLayer;

        #region Initialization methods

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
        }

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();

            loginAccessLayer.LoginIXMWeb();
            ixmUtils.GoToTab(MainTabs.Sync);
            syncAccessLayer = new Sync_AL();
        }

        #endregion Initialization methods

        #region Testcase Methods

        #region Create SyncGroup Test Case

        [TestMethod]
        [TestCategory(Module.SyncModule), TestCategory(TestSuite.Regression), TestCategory(TestSuite.Functional)]

        public void CreateSyncGroup()
        {
            // Create Sync Group
            syncAccessLayer.CreateSyncGroup("Emp1, Emp2", "DG1, DG2");
            

        }

        #endregion Create SyncGroup Test Case



        #endregion Testcase Methods


        #region Test Cleanup procedure

        [TestCleanup]
        public void Cleanup()
        {
            base.TearDown();
        }

        [ClassCleanup]
        public static void Quit()
        {
            loginAccessLayer.Quit();
        }

        #endregion Test Cleanup procedure
    }
}