using Employee.Core.Entities;
using Employee.Core.Interface;
using Employee.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly EmployeeDbContext _context;
        public RegisterRepository(EmployeeDbContext context) 
        {
            _context = context;
        }

        public async Task AssignRole(int employeeId, int roleId)
        {
            var studentroles = new EmployeeRoles
            {
                EmployeeId = employeeId,
                RoleId = roleId
            };
            await _context.EmployeeRoles.AddAsync(studentroles);
            await _context.SaveChangesAsync();

        }

        public async Task<Employe> GetEmployeeByPhone(string phone)
        {
            return await _context.Employee.Where(e => e.Phone.Equals(phone) && !e.IsDeleted)
                .FirstOrDefaultAsync() ;
        }

        public async Task<Employe> GetEmployeByMail(string email) 
        {
            return await _context.Employee.Where(n => n.Email.ToLower().Equals(email.ToLower()) && !n.IsDeleted)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> RegisterEmployeeAsync(Employe employe)
        {
            await _context.Employee.AddAsync(employe);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Role> GetRoleAsync(int roleId)
        {
            return await _context.Role
                           .FirstOrDefaultAsync(n => n.Id == roleId && !n.IsDeleted);
        }
    }
}
