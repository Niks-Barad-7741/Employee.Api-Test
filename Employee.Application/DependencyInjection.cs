using Employee.Application.Interfaces;
using Employee.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddAutoMapper(cfg => cfg.AddProfile<Employee.Application.Mapper.Mapper>());
            return services;
        }
    }
}
