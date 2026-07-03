using Employee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Interface
{
    public interface ILoginRepository
    {
        Task<Employe> GetEmployeByIdAsync(string email);
        Task<List<string>> GetEmployeeRole(int studentId);
        Task<List<string>> GetEmployeeRoles(int employeeId);
    }
}
