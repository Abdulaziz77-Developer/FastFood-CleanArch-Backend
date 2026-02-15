using FastFoodApp.Core.Interfaces;
using FastFoodApp.Core.Security;
using FastFoodApp.Infrastructure.Configuration;
using FastFoodApp.Infrastructure.Data;
using FastFoodApp.Infrastructure.Repositories;
using FastFoodApp.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastFoodApp.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Добавляем DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("FastFoodApp.Infrastructure")
            ));

        // Регистрируем UnitOfWork
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Регистрируем Security Services
        var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
        if (jwtSettings != null)
        {
            services.AddSingleton(jwtSettings);
            services.AddScoped<Core.Security.ITokenService, TokenService>();
        }

        services.AddScoped<Core.Security.IPasswordHasher, PasswordHasher>();

        // Регистрируем OAuth Settings
        var oauthSettings = new OAuthSettings();
        configuration.GetSection("Google").Bind(oauthSettings.Google);
        configuration.GetSection("Facebook").Bind(oauthSettings.Facebook);
        services.AddSingleton(oauthSettings);

        return services;
    }
}

