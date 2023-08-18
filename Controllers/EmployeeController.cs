using HR_System.DTOs.EmployeeDto;
using HR_System.Repositories.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository EmpRepo) => this._employeeRepository = EmpRepo;

        [HttpGet("all")]
        public IActionResult GetAll()
        {
           var employees=_employeeRepository.GetAll();
            if (employees != null)
            {
                return Ok(employees);
            }
            return BadRequest();
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetByID(int id) { 
        var employee=_employeeRepository.GetEmpById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return BadRequest();
        }
        [HttpPost("Insert")]
        public IActionResult Insert(EmployeeDto Emp)
        {
            _employeeRepository.Insert(Emp);
            if(ModelState.IsValid==true)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut("Update")]
        public IActionResult Update(EmployeeDto Employee) { 
            _employeeRepository.Update(Employee);
            if(ModelState.IsValid==true)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{EmpId}")]
        public IActionResult Delete(int EmpId) {
            try
            {
                _employeeRepository.Delete(EmpId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ByDepartment/{DeptID}")]
        public IActionResult GetByDeptID(int DeptID)
        {
            var employees = _employeeRepository.GetByDeptID(DeptID);
            if (employees != null)
            {
                return Ok(employees);
            }
            return BadRequest();
        }


    }
}
