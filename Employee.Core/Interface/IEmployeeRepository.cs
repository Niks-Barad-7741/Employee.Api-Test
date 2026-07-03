using Employee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Interface
{
    public interface IEmployeeRepository
    {
        Task <List<Employe>> GetAllEmployee();
        Task<int> CreateEmployee(Employe employe);
        Task<Employe> GetEmployeeById(int id);
        Task<bool> UpdateEmployee(int id, Employe employe);
        Task<bool> DeleteEmployee(Employe employe);
        Task<bool> IsPhoneRegisteredAsync(string phone, int currentEmployeeId);

        
    }
}
