using HR_System.Models;

namespace HR_System.DTOs.GroupDto
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public bool UserPage { get; set; }
        public bool EmployeePage { get; set; }
        public bool DepartmentPage { get; set; }
        public bool GeneralSettingsPage { get; set; }
        public bool SalaryReportPage { get; set; }
        public bool AttendancePage { get; set; }
    }
}
