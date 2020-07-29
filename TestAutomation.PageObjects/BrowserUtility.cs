using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Configuration;

namespace TestAutomation.PageObjects
{
    public class BrowserUtility
    {
        public static IWebDriver GetDriver { get; private set; }

        public static string baseURL = ConfigurationManager.AppSettings["url"];
        public static string browser = ConfigurationManager.AppSettings["browser"];

        public static void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    GetDriver = new ChromeDriver();
                    break;
                case "IE":
                    GetDriver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    GetDriver = new FirefoxDriver();
                    break;
            }

            GetDriver.Manage().Window.Maximize();
            //Goto(baseURL);
        }

        public static string Title
        {
            get { return GetDriver.Title; }
        }

        public static void GotoURL()
        {
            try
            {
                GetDriver.Url = baseURL;
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
        public static void Close()
        {
            GetDriver.Quit();

        }
    }
}
