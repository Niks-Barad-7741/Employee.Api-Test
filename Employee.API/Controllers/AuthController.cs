using BCrypt.Net;
using Employee.Application.DTO;
using Employee.Application.Interfaces;
using Employee.Core.Entities;
using Employee.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Employee.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IRegisterRepository _reg;
        private readonly ILoginRepository _login;
        private readonly ILoginService _loginService;
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _config;
        
        public AuthController(IRegisterRepository reg, ILoginRepository login, ILoginService loginService, IJwtService jwtService, IConfiguration config)
        {
            _reg = reg;
            _login = login;
            _loginService = loginService;
            _jwtService = jwtService;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var existing = await _reg.GetEmployeeByPhone(dto.Phone);
            if (existing != null)
            {
                return StatusCode(StatusCodes.Status409Conflict);
            }

            var empployee = new Employe
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Phone = dto.Phone,
                Department = dto.Department,
                Salary = dto.Salary

            };

            await _reg.RegisterEmployeeAsync(empployee);

            var userrole = await _reg.GetRoleAsync(2);
            if (userrole != null)
            {
                await _reg.AssignRole(empployee.Id, userrole.Id);
            }

            return Ok("User Registerd Succesfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto) 
        {
            var emp = await _login.GetEmployeByIdAsync(dto.Email);
            if(emp == null)
            {
                return Unauthorized("Invalid email or password");
            }

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, emp.PasswordHash);
            if(!isPasswordValid)
            {
                return Unauthorized("Invalid email or password");
            }

            var role = await _login.GetEmployeeRole(emp.Id);
            var token = _jwtService.GenerateToken(emp, role);
            return Ok(new { Token = token, empid = emp.Id, Email = emp.Email,role = role.FirstOrDefault()});
        }



    }
}
