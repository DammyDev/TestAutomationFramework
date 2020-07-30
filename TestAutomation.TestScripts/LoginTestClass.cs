// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TestAutomation.PageObjects;
using TestAutomation.PageObjects.manager_demo.agrocola;
using TestAutomation.TestScripts.Common.Utility;

namespace TestAutomation.TestScripts
{
    [TestFixture]
    public class LoginTestClass : BaseTest
    {
        [Test]
        public void TestMethod()
        {
            Assert.Ignore("Not part of Login Test");
            IWebDriver chromeDriver = null;
            ExtentTest test = null;

            try
            {
                test = extent.CreateTest("TestMethod").Info("Test Started");
                chromeDriver = BrowserUtility.GetDriver;
                
                test.Log(Status.Info, "Browser Launched!");
                chromeDriver.FindElement(By.XPath(".//*[@id='email']")).SendKeys("Damilola");
                test.Log(Status.Info, "Email textfield found!");               
                Thread.Sleep(2000);
                chromeDriver.Close();
                test.Log(Status.Pass, "Test Passed!");
            }
            catch (Exception e)
            {
                ITakesScreenshot ts = chromeDriver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();
                screenshot.SaveAsFile(@"C:\Users\Damilola\source\repos\TestAutomationFramework\Screenshots\TestReport.jpg");
                Console.WriteLine(e.StackTrace);
                test.Log(Status.Fail, e.ToString());
                throw;
            }
            finally
            {
                if (chromeDriver != null)                
                    chromeDriver.Quit();                
            }
        }

        [Test]
        public void LoginWithValidCredentials()
        {
            LoginHelper("LoginWithValidCredentials", "cola_admin@agrocola.com", "customer23");
        }

        [Test]
        public void LoginWithWrongEmail()
        {
            LoginHelper("LoginWithWrongEmail", "dooa_admin@agrocola.com", "customer23");
        }

        [Test]
        public void LoginWithWrongPassword()
        {
            LoginHelper("LoginWithWrongPassword", "cola_admin@agrocola.com", "rgrgrdgr");
        }

        [Test]
        public void LoginWithoutCredentials()
        {
            LoginHelper("LoginWithoutCredentials", "", "");
        }

        [Test]
        public void LoginWithoutPassword()
        {
            LoginHelper("LoginWithoutPassword", "cola_admin@agrocola.com", "");
        }

        [Test]
        public void LoginWithoutEmail()
        {
            LoginHelper("LoginWithoutEmail", "", "customer23");
        }

        [Test]

        public void LoginWithInvalidEmail()
        {
            LoginHelper("LoginWithInvalidEmail", "cola_admin%agrocola.com", "customer23");
        }

        public void LoginHelper(string methodName, string email, string password)
        {
            ExtentTest test = extent.CreateTest(methodName).Info("Test Started");
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            ITakesScreenshot ts = BrowserUtility.GetDriver as ITakesScreenshot;

            try
            {
                BrowserUtility.GotoURL();
                var loginPage = new LoginPage(BrowserUtility.GetDriver, test);
                Assert.IsTrue(loginPage.isAt(), "Is this the login page?");
                test.Pass($" Go to '{BrowserUtility.baseURL}'  on {BrowserUtility.browser} browser");
                bool loggedIn = loginPage.Login(email, password);
                Thread.Sleep(2000);

                switch (methodName)
                {
                    case "LoginWithValidCredentials":
                        Assert.IsTrue(loggedIn, "Is Login Successful?");
                        test.Log(Status.Info, "User is now logged in!");
                        break;
                    case "LoginWithInvalidEmail":
                        Assert.IsTrue(loginPage.GetEmailValidationMessage().Equals("Invalid email"), "Is Email format valid?");
                        test.Log(Status.Info, @"Email format is validated to be 'Invalid'!");
                        break;
                    case "LoginWithoutEmail":
                        Assert.IsTrue(loginPage.GetEmailValidationMessage().Equals("Required"), "Is Email Required?");
                        test.Log(Status.Info, @"Email Field is validated to be 'Required'!");
                        break;
                    case "LoginWithoutPassword":
                        Assert.IsTrue(loginPage.GetPasswordValidationMessage().Equals("Required"), "Is Password Required?");
                        test.Log(Status.Info, @"Password Field is validated to be 'Required'!");
                        break;                    
                    case "LoginWithoutCredentials":
                        Assert.IsTrue(loginPage.GetEmailValidationMessage().Equals("Required"), "Is Email Required?");
                        Assert.IsTrue(loginPage.GetPasswordValidationMessage().Equals("Required"), "Is Password Required?");
                        test.Log(Status.Info, @"Email & Password Fields validated to be 'Required'!");
                        break;                    
                    case "LoginWithWrongEmail":
                        Assert.IsTrue(loginPage.ErrorSpanText().Equals("Incorrect Login parameters"), "Is Email wrong?");
                        test.Log(Status.Info, @"'Incorrect Login parameters!' displayed");
                        break;
                    case "LoginWithWrongPassword":
                        Assert.IsTrue(loginPage.ErrorSpanText().Equals("Incorrect Login parameters"), "Is Password wrong?");
                        test.Log(Status.Info, @"'Incorrect Login parameters!' displayed");
                        break;
                }

                //string fileName = $@"C:\Users\USER01\source\repos\TestAutomationFramework\Screenshots\{methodName}_{timeStamp}.jpg";
                //ts.GetScreenshot().SaveAsFile(fileName);
                //test.Pass("Test Passed!", MediaEntityBuilder.CreateScreenCaptureFromPath($@"C:\Users\USER01\source\repos\TestAutomationFramework\Screenshots\{methodName}_{timeStamp}.jpg").Build());
                
                string base64String = ts.GetScreenshot().AsBase64EncodedString;
                test.Pass("Test Passed! ", MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64String).Build());
                //BrowserUtility.Close();
            }
            catch (Exception e)
            {
                //ts.GetScreenshot().SaveAsFile($@"C:\Users\USER01\source\repos\TestAutomationFramework\Screenshots\Error_{methodName}_{timeStamp}.jpg");
                //test.Fail(e.Message, MediaEntityBuilder.CreateScreenCaptureFromPath($@"C:\Users\USER01\source\repos\TestAutomationFramework\Screenshots\Error_{methodName}_{timeStamp}.jpg").Build());

                string base64String = ts.GetScreenshot().AsBase64EncodedString;
                test.Fail(e.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64String, "See Screenshot").Build());

                test.Log(Status.Fail, "Test Failed!");
                Console.WriteLine(e.StackTrace);                          
            }
            finally
            {
                //if (BrowserUtility.GetDriver != null)
                //    BrowserUtility.Close();
            }

        }
    }
}
