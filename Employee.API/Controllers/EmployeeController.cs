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
            if (emp == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            return Ok(emp);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] RegisterDTO employee)
        {
            if (employee == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
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
            if (create == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            return Ok(create);
        }


        [Authorize(Roles ="Admin,User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var emp = await _employeeService.GetEmployeeById(id);
            if (emp == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(emp);
        }

        [Authorize(Roles ="Admin,User")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateEmployeeDTO employee)
        {
            if (employee == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            var emp = await _employeeService.UpdateEmployee(id, employee);
            if (!emp)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            return Ok(emp);
        }

        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var emp = await _employeeService.DeleteEmployee(id);
            if (!emp)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            return Ok(emp);
        }
    }
}
