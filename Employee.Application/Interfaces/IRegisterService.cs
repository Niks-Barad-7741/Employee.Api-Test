using Employee.Application.DTO;
using Employee.Core.Entities;

namespace Employee.Application.Interfaces
{
    public interface IRegisterService
    {
        Task<EmployeeDTO> GetEmployeeByPhone(string phone);
        Task<bool> RegisterEmployeeAsync(RegisterDTO dto);
        Task<Role> GetRoleAsync(int roleId);


        Task AssignRole(int employeeId, int roleId);
    }
}
