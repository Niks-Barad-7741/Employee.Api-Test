using Employee.Core.Entities;
using Employee.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllEmployee();
        Task<int> CreateEmployee(RegisterDTO dto);
        Task<EmployeeDTO> GetEmployeeById(int id);
        Task<bool> UpdateEmployee(int id, UpdateEmployeeDTO dto);
        Task<bool> DeleteEmployee(int id);
    }
}
