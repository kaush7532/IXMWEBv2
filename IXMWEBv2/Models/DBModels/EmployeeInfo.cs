using System;

namespace IXMWEBv2.Models.DBModels
{
    public class EmployeeInfo
    {
        public Guid EmployeeGuid { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public bool IsEmployeeSuspended { get; set; }
    }
}