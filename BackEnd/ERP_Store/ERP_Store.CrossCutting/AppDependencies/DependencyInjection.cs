using ERP_Store.Domain.Abstractions;
using ERP_Store.Infra.Context;
using ERP_Store.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERP_Store.CrossCutting.AppDependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
                                                            IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<ISaleRepository, SaleRepository>();
        services.AddScoped<IMoveStockRepository, MoveStockRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var myHandlers = AppDomain.CurrentDomain.Load("ERP_Store.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));

        return services;
    }
    
}