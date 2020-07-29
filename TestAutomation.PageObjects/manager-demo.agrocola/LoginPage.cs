using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace TestAutomation.PageObjects.manager_demo.agrocola
{
    public class LoginPage
    {
        IWebDriver driver;
        ExtentTest test;

        public LoginPage(IWebDriver _driver, ExtentTest _test)
        {
            test = _test;
            driver = _driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement EmailField { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#app>div>div.jss5>div>div>div>section>form>div.jss118>button")]
        public IWebElement ContinueButton { get; set; }       
        
        [FindsBy(How = How.Id, Using = "client-snackbar")]
        public IWebElement ErrorSpan { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#app>div>div.jss5>div>div>div>section>form>div:nth-child(1)>div>div>p")]
        public IWebElement EmailValidatorParagraph { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#app>div>div.jss5>div>div>div>section>form>div:nth-child(2)>div>div>p")]
        public IWebElement PasswordValidatorParagraph { get; set; }

        public bool isAt()
        {
            return BrowserUtility.Title.Contains("AgroCola Admin - Login");
        }

        public bool Login(string email, string password)
        {           
            EmailField.SendKeys(email);
            test.Log(Status.Pass, $"Enter '{email}' in the Email field ");

            PasswordField.SendKeys(password);
            test.Log(Status.Pass, $"Enter '{password}' in the Password field");

            ContinueButton.Click();
            test.Log(Status.Pass, "Click the 'Continue' Button");

            Thread.Sleep(3000);
          
            if (new FarmerDashboardPage(driver, test).IsLogOutBtnFound())      
                return true;

            return false;      
        }

        public string GetEmailValidationMessage()
        {
            try
            {
                return EmailValidatorParagraph.Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }

        public string GetPasswordValidationMessage()
        {
            try
            {
                return PasswordValidatorParagraph.Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }

        public string ErrorSpanText()
        {
            try
            {
                return ErrorSpan.Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
    }
}
