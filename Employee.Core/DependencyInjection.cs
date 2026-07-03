using Microsoft.Extensions.DependencyInjection;

namespace Employee.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection service) 
        {
            return service;
        }
    }
}
