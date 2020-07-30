using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using TestAutomation.PageObjects;

namespace TestAutomation.TestScripts.Common.Utility
{
    public class BaseTest
    {
        public ExtentReports extent = null;

        [OneTimeSetUp]
        public void Start()
        {
            BrowserUtility.Init();
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Damilola\source\repos\TestAutomationFramework\Extent_Reports\Report.html");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void Close()
        {
            extent.Flush();
            BrowserUtility.Close();
        }
    }
}