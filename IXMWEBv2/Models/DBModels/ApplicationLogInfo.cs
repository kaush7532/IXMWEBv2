namespace IXMWEBv2.Models.DBModels
{
    public class ApplicationLogInfo
    {
        public int TotalCount { get; set; }
        public int OlderthanPastDayLogCount { get; set; }
        public int OlderthanPastHourLogCount { get; set; }
        public int OlderthanPastWeekLogCount { get; set; }
        public int Olderthan4PastWeekLogCount { get; set; }
    }
}