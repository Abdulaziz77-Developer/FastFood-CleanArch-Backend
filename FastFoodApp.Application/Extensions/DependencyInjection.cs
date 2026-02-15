using AutoMapper;
using FastFoodApp.Application.Interfaces;
using FastFoodApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

namespace FastFoodApp.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Регистрируем AutoMapper с профилем маппинга
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Регистрируем HttpClient и AuthService
        services.AddHttpClient<IAuthService, AuthService>();

        // Регистрируем остальные сервисы приложения
        services.AddScoped<IFoodService, FoodService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IOrderService, OrderService>();

        return services;
    }
}

