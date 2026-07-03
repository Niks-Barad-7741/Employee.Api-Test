using AutoMapper;
using Employee.Application.DTO;
using Employee.Application.Interfaces;
using Employee.Core.Entities;
using Employee.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employerepo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employerepo, IMapper mapper) 
        {
            _employerepo = employerepo;
            _mapper = mapper;
        }
        public async Task<int> CreateEmployee(RegisterDTO dto)
        {
            var emp = _mapper.Map<Employe>(dto);

            emp.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            return await _employerepo.CreateEmployee(emp);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var emp = await _employerepo.GetEmployeeById(id);
            if (emp == null) 
            {
                return false;
            }
            return await _employerepo.DeleteEmployee(emp);
        }

        public async Task<List<EmployeeDTO>> GetAllEmployee()
        {
            var employes = await _employerepo.GetAllEmployee();
            return _mapper.Map<List<EmployeeDTO>>(employes);
        }

        public async Task<EmployeeDTO> GetEmployeeById(int id)
        {
            var emp = await _employerepo.GetEmployeeById(id);
            return _mapper.Map<EmployeeDTO>(emp);
        }

        public async Task<bool> UpdateEmployee(int id, UpdateEmployeeDTO dto)
        {
            var existingEmp = await _employerepo.GetEmployeeById(id);
            if (existingEmp == null) 
            {
                return false;
            }

            var phoneExists = await _employerepo.IsPhoneRegisteredAsync(dto.Phone, id);
            if (phoneExists)
            {
                throw new InvalidOperationException("Phone number is already registered by another employee.");
            }

            existingEmp.Name = dto.Name;
            existingEmp.Email = dto.Email;
            existingEmp.Phone = dto.Phone;
            existingEmp.Department = dto.Department;
            existingEmp.Salary = dto.Salary;

            return await _employerepo.UpdateEmployee(id,existingEmp);
        }
    }
}
