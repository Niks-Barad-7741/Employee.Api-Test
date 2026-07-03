using Employee.Application.DTO;
using Employee.Application.Interfaces;
using Employee.Core.Entities;
using Employee.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRegisterRepository _register;

        public EmployeeController(IEmployeeService employeeService,IRegisterRepository register)
        {
            _employeeService = employeeService;
            _register = register;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GettAllAsync()
        {
            var emp = await _employeeService.GetAllEmployee();
            if (emp == null || emp.Count == 0)
            {
                return NotFound(new { Message = "No employees found" });
            }
            return Ok(new { Message = "Employees retrieved successfully", Data = emp });
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] RegisterDTO employee)
        {
            if (employee == null)
            {
                return BadRequest(new { Message = "Invalid employee data" });
            }
            var employeec = new Employe
            {
                Name = employee.Name,
                Email = employee.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(employee.Password),
                Phone = employee.Phone,
                Department = employee.Department,
                Salary = employee.Salary
            };

            var create = await _register.RegisterEmployeeAsync(employeec);
            if (!create)
            {
                return BadRequest(new { Message = "Failed to create employee" });
            }
            return Ok(new 
            { 
                Message = "Employee created successfully",
                Employee = new 
                {
                    employeec.Id,
                    employeec.Name,
                    employeec.Email,
                    employeec.Phone,
                    employeec.Department,
                    employeec.Salary
                }
            });
        }


        [Authorize(Roles ="Admin,User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var emp = await _employeeService.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound(new { Message = "Employee not found" });
            }
            return Ok(new { Message = "Employee retrieved successfully", Data = emp });
        }

        [Authorize(Roles ="Admin,User")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateEmployeeDTO employee)
        {
            if (employee == null)
            {
                return BadRequest(new { Message = "Invalid employee data" });
            }
            try
            {
                var emp = await _employeeService.UpdateEmployee(id, employee);
                if (!emp)
                {
                    return BadRequest(new { Message = "Failed to update employee" });
                }
                return Ok(new { Message = "Employee updated successfully" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            if (id <= 0)
            {
                return BadRequest(new { Message = "Invalid ID" });
            }
            var check = await _employeeService.GetEmployeeById(id);
            if (check == null)
            {
                return NotFound(new { Message = "Employee not found" });
            }

            var emp = await _employeeService.DeleteEmployee(id);

            
            if (!emp)
            {
                return BadRequest(new { Message = "Failed to delete employee" });
            }
            return Ok(new { Message = "Employee deleted successfully" });
        }
    }
}
