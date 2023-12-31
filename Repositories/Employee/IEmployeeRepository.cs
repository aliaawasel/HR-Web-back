﻿using HR_System.DTOs.EmployeeDto;

namespace HR_System.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        List<EmployeeViewDto> GetAll();
        Models.Employee GetbyId(int id);

        EmployeeDto GetEmpById(int id);

        void Insert(EmployeeDto NewEmpDto);
        void Update(EmployeeDto UpdateEmpDto);
        void Delete(int id);

        List<EmployeeDto> GetByDeptID(int deptid);

    }
}
