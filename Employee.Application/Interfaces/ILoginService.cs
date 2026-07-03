using Employee.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Interfaces
{
    public interface ILoginService
    {
        Task<EmployeeDTO> GetEmployeByIdAsync(string email);
        Task<List<string>> GetEmployeeRole(int employeeid);
        Task<List<string>> GetEmployeeRoles(int employeeId);


    }
}
