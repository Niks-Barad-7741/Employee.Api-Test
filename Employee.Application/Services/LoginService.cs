using AutoMapper;
using Employee.Application.DTO;
using Employee.Application.Interfaces;
using Employee.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;
        private readonly IMapper _mapper;

        public LoginService(ILoginRepository repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> GetEmployeByIdAsync(string email)
        {
            var employee = await _repository.GetEmployeByIdAsync(email);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<List<string>> GetEmployeeRole(int employeeid)
        {
            return await _repository.GetEmployeeRole(employeeid);
        }

        public Task<List<string>> GetEmployeeRoles(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
