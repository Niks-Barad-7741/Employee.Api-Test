using Employee.Core.Entities;

namespace Employee.Core.Interface
{
    public interface IRegisterRepository
    {

        Task<Employe> GetEmployeeByPhone(string phone);
        Task<bool> RegisterEmployeeAsync(Employe employe);
        Task<Role> GetRoleAsync(int roleId);
        Task<Employe> GetEmployeByMail(string email);


        Task AssignRole(int employeeId, int roleId);


    }
}
