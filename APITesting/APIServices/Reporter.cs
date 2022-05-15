using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public static class Reporter
    {
        public static ExtentReports _extentReports;
        public static ExtentHtmlReporter _htmlReporter;
        public static ExtentTest _testCase;

        public static void SetupExtentReport(string reportName, string documentTitle, dynamic path)
        {
            _htmlReporter = new ExtentHtmlReporter(path);
            _htmlReporter.Config.Theme = Theme.Standard;
            _htmlReporter.Config.DocumentTitle = documentTitle;
            _htmlReporter.Config.ReportName = reportName;

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(_htmlReporter);
        }

        public static void CreateTest(string testName)
        {
            _testCase = _extentReports.CreateTest(testName);
        }

        public static void LogToReport(Status status, string message)
        {
            message = RestSharp.Extensions.MonoHttp.HttpUtility.HtmlEncode(message);
            _testCase.Log(status, message);
        }

        public static void FlushReport()
        {
            _extentReports.Flush();
        }


        public static void TestStatus(string status)
        {
            if (status.Equals("Pass"))
            {
                _testCase.Pass("Test is passed");
            }
            else
            {
                _testCase.Fail("Test is failed");
            }
        }
    }
}
