namespace IXMWEBv2.Dashboard.EnrollmentStatus
{
    public class EnrollmentStatusLocators
    {
        public static string completed = ".//*[@id='enrollmentChart']//*[name()='svg']//*[@fill='#3090ff']";
        public static string BtnEnrollmentStatusFullView = "enrollmentChartFsButton";
        public static string BtnExportEnrollmentStatusImage = ".//*[@id='divenrollmentChart']//a[@title='Export as Image']";
        public static string GetChartData = "$('#qualityChart').data('kendoChart').dataSource._data";
    }
}