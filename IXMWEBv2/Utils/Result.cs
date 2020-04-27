using IXMWEBv2.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace IXMWEBv2.Utils
{
    public class Result
    {
        private static int srno;
        private static int pass, fail;
        public static Stopwatch testStartTime = null;
        public static DateTime execStart;
        private static DateTime execStop;
        private StringBuilder str;

        public Result(TestContext context)
        {
            testStartTime = new Stopwatch();
            testStartTime.Start();
        }

        private static string ReadReportTemplate()
        {
            return File.ReadAllText(CommonUtils.AssemblyPath + "\\Results\\TestSummary.html");
        }

        public void WriteTestResult(TestResultType resulttype, string testName, string screenshotpath, string exception = "")
        {
            srno += 1;
            str = new StringBuilder();

            if (resulttype == TestResultType.Pass)
            {
                pass += 1;
                str.Insert(0, ReadReportTemplate());
                testStartTime.Stop();
                str = str.Replace("##body##", string.Format("<tr><td>{0}</td><td>{1}</td><td><font color='green'><b>Pass</b></font></td><td><a href='{2}'>{3}</a></td><td>{4}</td><td>{5}</td></tr> ##body##", srno, testName, screenshotpath, Path.GetFileName(screenshotpath), DateTime.Now.ToString("MM/dd/yy hh:mm:ss tt"), testStartTime.Elapsed.TotalSeconds));
            }
            else if (resulttype == TestResultType.Fail)
            {
                fail += 1;
                str.Insert(0, ReadReportTemplate());
                str = str.Replace("##body##", string.Format("<tr><td>{0}</td><td>{1}</td><td><font color='red'><b>Fail</b></font></td><td><a href='{2}'>{3}</a></td><td>{4}</td><td>{5}</td></tr> ##body##", srno, testName, screenshotpath, Path.GetFileName(screenshotpath), DateTime.Now.ToString("MM/dd/yy hh:mm:ss tt"), testStartTime.Elapsed.TotalSeconds));
            }

            WriteReport(str);
        }

        public static void WriteTimeDataSummary(bool isExecutionStart)
        {
            StringBuilder strsummary = new StringBuilder();
            if (isExecutionStart)
            {
                strsummary.Insert(0, ReadReportTemplate());
                strsummary.Replace("##st##", execStart.ToString("MM/dd/yy hh:mm:ss tt"));
            }
            else
            {
                strsummary.Insert(0, ReadReportTemplate());
                execStop = DateTime.Now;
                strsummary.Replace("##et##", execStop.ToString("MM/dd/yy hh:mm:ss tt"));
                strsummary.Replace("##duration##", execStop.Subtract(execStart).ToString(@"hh\:mm\:ss"));
                strsummary.Replace("##pass##", pass.ToString());
                strsummary.Replace("##fail##", fail.ToString());
                strsummary.Replace("##total##", (pass + fail).ToString());
                strsummary.Replace("##body##", "");
            }
            WriteReport(strsummary);
        }

        public static void WriteReport(StringBuilder result)
        {
            string final = result.ToString();
            StreamWriter sw = new StreamWriter(CommonUtils.AssemblyPath + "\\Results\\TestSummary.html");
            sw.Write(final);
            sw.Close();
            Logger.Info("Writing test result in testsummary.html file", "");
        }
    }
}