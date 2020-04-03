using System;
using IXMWEBv2.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace IXMWEBv2.WebDriverFactory
{
    public class DriverManager
    {
        /// <summary>
        /// Method to get and set test context
        /// </summary>
        //public static TestContext TestContext { get; set; }

        private IWebDriver _driver;
        private WebDriverWait _wait;

        // Setting-up default values

        /// <summary>
        /// Declare variable browser
        /// </summary>
        public static string browser;

        /// <summary>
        /// Declare variable portal Url
        /// </summary>
        public static string ixmWebUrl;

        /// <summary>
        /// Declare variable for recordvideo;
        /// </summary>
        public static bool recordVideo;

        /// <summary>
        /// Declare variable ixm web username
        /// </summary>
        public static string ixmWebUsername;

        /// <summary>
        /// Declare variable ixm web password
        /// </summary>
        public static string ixmWebPassword;

        /// <summary>
        /// Declare variable for ixm web version
        /// </summary>
        public static string ixmWebVersion;

        /// <summary>
        /// Declare variable for online device
        /// </summary>
        public static string onlineDeviceIP;

        /// <summary>
        /// Declare variable for online device
        /// </summary>
        public static string onlineDevicePort;

        /// <summary>
        /// Variable for online devicename
        /// </summary>
        public static string onlineDeviceName;

        /// <summary>
        /// Declare variable for offline device name
        /// </summary>
        public static string offlineDeviceIP;

        /// <summary>
        /// Declare variable for offline device name
        /// </summary>
        public static string devicesOfTreeView;

        /// <summary>
        /// Declare variable for connection string
        /// </summary>
        public static string connectionString;

        /// <summary>
        /// Declare variable for register deviceIP
        /// </summary>
        public static string deviceToRegisterIP;

        /// <summary>
        /// Declare variable for register devicePort
        /// </summary>
        public static string deviceToRegisterPort;

        /// <summary>
        /// Declare variable instance
        /// </summary>
        public static DriverManager instance;

        private DriverManager()
        {
            InitializeDriver(browser);
        }

        private DriverManager(string browser)
        {
            InitializeDriver(browser);
        }

        /// <summary>
        /// Method to initialize driver
        /// </summary>
        /// <param name="browser"></param>
        public void InitializeDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("disable-infobars");
                    DesiredCapabilities dc = new DesiredCapabilities();
                    dc.SetCapability(ChromeOptions.Capability, options);

                    _driver = new ChromeDriver(options);
                    _driver.Manage().Window.Maximize();
                    break;

                case "firefox":
                    //Environment.SetEnvironmentVariable("webdriver.gecko.driver", CommonUtils.AssemblyPath + "\\geckodriver.exe");
                    //FirefoxOptions op = new FirefoxOptions();
                    //op.SetPreference("security.insecure_field_warning.contextual.enabled", false);
                    //_driver = new FirefoxDriver(op);

                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                    service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                    _driver = new FirefoxDriver(service);
                    _driver.Manage().Window.Maximize();

                    break;

                case "ie11":
                    _driver = new InternetExplorerDriver();
                    break;

                case "edge":
                    _driver = new EdgeDriver();
                    break;

                default:
                    _driver = new InternetExplorerDriver();
                    break;
            }
            if (recordVideo)
            {
                CommonUtils.StartVideoRecord();
            }
            Logger.Info(string.Format("Launching browser: '{0}'", browser), "");
            _driver.Navigate().GoToUrl(ixmWebUrl);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
        }

        /// <summary>
        /// Method to get instance
        /// </summary>
        /// <returns></returns>
        public static DriverManager GetInstance()
        {
            if (instance == null)
            {
                //LoadSettings(TestContext);
                instance = new DriverManager();
            }
            return instance;
        }

        /// <summary>
        /// Method to get instance using test context
        /// </summary>
        /// <param name="testContext"></param>
        /// <returns></returns>
        public static DriverManager GetInstance(TestContext testContext)
        {
            if (instance == null)
            {
                LoadSettings(testContext);
                //TestContext = testContext;
                //instance = new DriverManager();
            }
            return instance;
        }

        /// <summary>
        /// Getting instance
        /// </summary>
        /// <param name="browser"></param>
        /// <returns>DriverManager</returns>
        public static DriverManager GetInstance(string browser)
        {
            if (instance == null)
            {
                //LoadSettings(TestContext);
                instance = new DriverManager(browser);
            }
            return instance;
        }

        /// <summary>
        /// Method to set instance to null
        /// </summary>
        /// <returns></returns>
        public static DriverManager SetInstanceToNull()
        {
            instance = null;
            return instance;
        }

        /// <summary>
        /// Getting driver
        /// </summary>
        /// <returns>IWebDriver</returns>
        public IWebDriver GetDriver()
        {
            return _driver;
        }

        /// <summary>
        /// Getting wait
        /// </summary>
        /// <returns>WebDriverWait</returns>
        public WebDriverWait GetWait()
        {
            return _wait;
        }

        /// <summary>
        /// Quiting driver
        /// </summary>
        public void Quit()
        {
            _driver.Quit();
        }

        /// <summary>
        /// Method to load values from test.runsettings
        /// </summary>
        /// <param name="testContext"></param>
        public static void LoadSettings(TestContext testContext)
        {
            browser = testContext.Properties["browser"].ToString().ToLower();
            ixmWebUrl = testContext.Properties["ixmWebUrl"].ToString().ToLower();
            ixmWebUsername = testContext.Properties["ixmWebUserName"].ToString().ToLower();
            ixmWebPassword = testContext.Properties["ixmWebPassword"].ToString();
            ixmWebVersion = testContext.Properties["ixmWebVersion"].ToString().ToLower();
            onlineDeviceIP = testContext.Properties["onlineDeviceIP"].ToString();
            onlineDevicePort = testContext.Properties["onlineDevicePort"].ToString();
            offlineDeviceIP = testContext.Properties["offlineDeviceIP"].ToString();
            recordVideo = Convert.ToBoolean(testContext.Properties["recordVideo"].ToString());
            devicesOfTreeView = testContext.Properties["devicesOfTree"].ToString();
            connectionString = testContext.Properties["dbconnectionstring"].ToString();
            deviceToRegisterIP = testContext.Properties["deviceIp"].ToString();
            deviceToRegisterPort = testContext.Properties["devicePort"].ToString();

            Logger.Info("Parameters from test.runsettings Loaded successfully", "");
        }
    }
}