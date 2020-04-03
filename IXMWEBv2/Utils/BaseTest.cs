using IXMWEBv2.AccessLayer;
using IXMWEBv2.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IXMWEBv2.Utils
{
    [TestClass]
    [DeploymentItem(@"chromedriver.exe")]
    [DeploymentItem(@"geckodriver.exe")]
    [DeploymentItem(@"IEDriverServer.exe")]
    [DeploymentItem(@"Resources\")]
    public abstract class BaseTest
    {
        #region Declaration

        protected string ClassName;
        protected string TestMethodName;
        protected static DBInteraction dbInteraction;

        public TestContext TestContext { get; set; }

        public static LoginAccessLayer loginAccessLayer;

        public static IXMWebUtils ixmUtils;

        public Result result;
        public static TestResultType TestResult;

        #endregion Declaration

        #region Test Setup

        public virtual void Setup()
        {
            // Get class and method names and assign it
            TestMethodName = TestContext.TestName;
            ClassName = TestContext.FullyQualifiedTestClassName;
            ClassName = ClassName.Substring(ClassName.LastIndexOf('.') + 1);
            Logger.TestStartInfo(TestMethodName, ClassName);

            TestResult = TestResultType.Pass;
            result = new Result(TestContext);

            loginAccessLayer = new LoginAccessLayer();
            ixmUtils = new IXMWebUtils();
            dbInteraction = new DBInteraction();
        }

        #endregion Test Setup

        #region Test TearDown

        public virtual void TearDown()
        {
            CommonUtils.SaveTestStatus(TestContext, TestResult, result);
            Logger.TestCompleteInfo(TestMethodName, TestResult.ToString());
        }

        #endregion Test TearDown
    }
}