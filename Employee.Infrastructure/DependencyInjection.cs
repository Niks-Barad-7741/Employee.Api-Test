using Employee.Application.Interfaces;
using Employee.Core.Interface;
using Employee.Infrastructure.Data;
using Employee.Infrastructure.Repositories;
using Employee.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IRegisterRepository,RegisterRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IJwtService, JwtService>();
            //services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Employee"),
            //    b => b.MigrationsAssembly("Employee.Api")));

            return services;
        }
    }
}
