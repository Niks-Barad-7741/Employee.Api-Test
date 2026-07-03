    using Employee.Core.Entities;
    using Employee.Core.Interface;
    using Employee.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    namespace Employee.Infrastructure.Repositories
    {
        public class EmployeeRepository : IEmployeeRepository
        {
            private readonly EmployeeDbContext _context;
            public EmployeeRepository(EmployeeDbContext context) 
            {
                _context = context;
            }

            public async Task<int> CreateEmployee(Employe employe)
            {
                await _context.Employee.AddAsync(employe);
                await _context.SaveChangesAsync();
                return employe.Id;
            }

            public async Task<bool> DeleteEmployee(Employe employe)
            {
                employe.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;

            }

            public async Task<List<Employe>> GetAllEmployee()
            {
                return await _context.Employee.Where(e => !e.IsDeleted)
                    .ToListAsync();
            }

            public async Task<Employe> GetEmployeeById(int id)
            {
                return await _context.Employee.Where(emp => emp.Id == id && !emp.IsDeleted).FirstOrDefaultAsync();
            }

            public async Task<bool> UpdateEmployee(int id, Employe employe)
            {
                _context.Employee.Update(employe);
                await _context.SaveChangesAsync();
                return employe.Id == id;
            }
        }
    }
