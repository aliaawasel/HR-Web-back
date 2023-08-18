using HR_System.DTOs.DepartmentDto;
using HR_System.DTOs.GroupDto;
using HR_System.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Repositories.Group
{
    public class GroupRepository:IGroupRepository
    {
        private readonly HREntity hREntity;
        public GroupRepository(HREntity hREntity)
        {
            this.hREntity = hREntity;
        }
        //    public GroupDto GetAll() {
        //        var Group=hREntity.GroupPermissions.Include(g=>g.Group).Include(g=>g.Permissions).ToList();
        //        var groupDto=Group.Where(g=>new GroupDto()
        //        {
        //            Id=g.Group.Id,
        //            GroupName=g.Group.Name,
        //            GeneralSettingsPage=g.Permissions.GeneralSettingsPage,
        //            UserPage=g.Permissions.UserPage,
        //            AttendancePage=g.Permissions.AttendancePage,
        //            EmployeePage=g.Permissions.EmployeePage,
        //            DepartmentPage=g.Permissions.DepartmentPage,
        //            SalaryReportPage=g.Permissions.SalaryReportPage,
        //            =g.Add

        //        }).ToList();
        //        return groupDto;
        //    }
        public List<Models.Group>? GetAll()
        {
            var groups = hREntity.Groups.Where(D => D.IsDeleted != true).ToList();
            return (groups);
            
        }
    }
}
