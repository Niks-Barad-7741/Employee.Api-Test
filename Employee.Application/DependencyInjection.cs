using Employee.Application.DTO;
using Employee.Application.Interfaces;
using Employee.Application.Services;
using Employee.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
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

            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<LoginDTO>, LoginValidator>();
            services.AddScoped<IValidator<RegisterDTO>, RegisterValidator>();
            services.AddScoped<IValidator<EmployeeDTO>, EmployeeValidator>();
            services.AddScoped<IValidator<UpdateEmployeeDTO>, UpdateEmployeeValidator>();

            services.AddAutoMapper(cfg => cfg.AddProfile<Employee.Application.Mapper.Mapper>());
            return services;
        }
    }
}
