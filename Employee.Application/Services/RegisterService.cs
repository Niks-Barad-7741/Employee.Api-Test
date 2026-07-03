using AutoMapper;
using BCrypt.Net;
using Employee.Application.DTO;
using Employee.Application.Interfaces;
using Employee.Core.Entities;
using Employee.Core.Interface;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Services
{
    public class RegisterService : IRegisterService
    {

        private readonly IRegisterRepository _repository;
        private readonly IMapper _mapper;
        public RegisterService(IRegisterRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AssignRole(int employeeId, int roleId)
        {
            await _repository.AssignRole(employeeId, roleId);
        }

        public async Task<EmployeeDTO> GetEmployeeByPhone(string phone)
        {
            var emp = await _repository.GetEmployeeByPhone(phone);
            return _mapper.Map<EmployeeDTO>(emp);
        }

        public async Task<bool> RegisterEmployeeAsync(RegisterDTO dto)
        {
            var emp = _mapper.Map<Employe>(dto);

            emp.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            return await _repository.RegisterEmployeeAsync(emp);
        }

        public async Task<Role> GetRoleAsync(int roleId)
        {
            return await _repository.GetRoleAsync(roleId);
        }
    }
}
