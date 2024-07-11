using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ERP_Store.Application.Services;

public static class ServiceExtensions
{
    public static void AddConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}