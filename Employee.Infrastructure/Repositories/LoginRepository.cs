using Employee.Core.Entities;
using Employee.Core.Interface;
using Employee.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly EmployeeDbContext _context;

        public LoginRepository(EmployeeDbContext context) 
        {
            _context = context;
        }

        public async Task<Employe> GetEmployeByIdAsync(string email)
        {
            return await _context.Employee.Where(n => n.Email.ToLower().Equals(email.ToLower()) && !n.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<List<string>> GetEmployeeRole(int studentId)
        {
            return await _context.EmployeeRoles.Where(er => er.EmployeeId == studentId)
                .Select(er => er.Role.Name)
                .ToListAsync();
        }

        public async Task<List<string>> GetEmployeeRoles(int employeeId)
        {
            //return await _context.EmployeeRoles.Where(er => er.EmployeeId == employeeId && !er.Role.IsDeleted)
            //    .Select(nb => nb.RoleId)
            //    .ToListAsync();

            return await _context.EmployeeRoles.Where(er => er.EmployeeId == employeeId && !er.Role.IsDeleted)
                .Select(nb => nb.Role.Name)
                .ToListAsync();


        }
    }
}
