using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestAutomation.PageObjects.manager_demo.agrocola
{
    public class FarmerDashboardPage
    {
        IWebDriver driver;
        ExtentTest test;

        public FarmerDashboardPage(IWebDriver _driver, ExtentTest _test)
        {
            test = _test;
            driver = _driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#app>div>div.jss351.jss356.light-mode>header>div>div.jss470>a>span.MuiButton-label")]
        public IWebElement LogOutButton { get; set; }

        public bool IsLogOutBtnFound()
        {
            try
            {
                return LogOutButton.Displayed;
            }
            catch (System.Exception)
            {
                return false;
            }

        }
    }
}
