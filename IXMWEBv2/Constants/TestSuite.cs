namespace IXMWEBv2.Constants
{
    public class TestSuite
    {
        #region Test type in Suite

        public const string Smoke = "Smoke";
        public const string Regression = "Regression";
        public const string Negative = "Negative";
        public const string UI = "UI";
        public const string Functional = "Functional";
        public const string UseCases = "UseCase";

        #endregion Test type in Suite
    }

    public class Module
    {
        #region Module name in Suite

        public const string Home = "Home";
        public const string EmployeeModule = "Employee";
        public const string AddEmployeeModule = "AddEmployee";
        public const string EnrollmentModule = "Enrollment";
        public const string LoginModule = "Login";
        public const string DeviceModule = "Device";
        public const string DeviceConfiguration = "DeviceConfiguration";
        public const string DTMFModule = "DTMFSettings";
        public const string VOIP = "VOIP";
        public const string USBAuxPortModule = "USBAuxiliaryPortSettings";
        public const string BluetoothModule = "BluetoothSettings";
        public const string HomeModule = "Home";
        public const string UserGroupModule = "UserGroup";
        public const string SmartCard = "SmartCard";
        public const string DeviceLogModule = "DeviceLog";

        //public const string LogsModule = "Log";
        public const string TransactionLogModule = "TransactionLog";
        public const string ApplicationLogModule = "ApplicationLog";
        public const string SyncModule = "Sync";
        public const string EmailConfigurationModule = "EmailConfiguartion";
        public const string ConfigModule = "Config";
        public const string WiegandModule = "Wiegand";
        public const string HolidayScheduleModule = "HolidaySchedule";
        public const string AntiShockModule = "Antishock";

        #endregion Module name in Suite
    }

    public enum MainTabs
    {
        Login, Home, Employee, Devices, Logs, Sync, Tools, SmartCard, Link, Convert, License, Config, Translate, Report
    }

    public enum DeviceConfigurationTabs
    {
        Communication, Security
    }

    public enum AppLogFilterOnColums
    {
        EventStatus
    }
}