using System;
using IXMWEBv2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IXMWEBv2.WebDriverFactory
{
    public class MainAssembly : BaseTest
    {
        #region Assembly Functions

        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            // Load all other settings based on above environment
            DriverManager.LoadSettings(context);
            //dbInteraction = new DBInteraction();
            CommonUtils.AssemblyPath = context.DeploymentDirectory;
            //if (DriverManager.recordVideo)
            //{
            //    screenVideo = new VideoRecord();
            //}

            Result.execStart = DateTime.Now;
        }

        [AssemblyCleanup()]
        public static void AssemblyClean()
        {
            Result.WriteTimeDataSummary(true);
            Result.WriteTimeDataSummary(false);
            if (DriverManager.recordVideo)
            {
                CommonUtils.StopVideoRecord();
            }
        }

        #endregion Assembly Functions
    }
}