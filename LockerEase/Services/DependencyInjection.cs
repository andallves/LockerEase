using System.Reflection;
using LockerEase.Contracts.Services;
using LockerEase.Data;
using LockerEase.Models;
using LockerEase.Notifications;
using LockerEase.Repositories;
using LockerEase.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScottBrady91.AspNetCore.Identity;

namespace LockerEase.Services;

public static class DependencyInjection
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddControllersWithViews();
        services.ConfigureDbContext(configuration);
        services.RepositoryInjection();
    }
    
    private static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"), 
                new MySqlServerVersion(new Version(8, 0, 39)));
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });
    }

    public static void AddServices(this IServiceCollection services)
    {
        services
            .AddScoped<IPasswordHasher<UserModel>, Argon2PasswordHasher<UserModel>>();
        
        services
            .AddScoped<INotificator, Notificator>();

        services
            .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services
            .AddScoped<IUserService, UserService>()
            .AddScoped<ILockerService, LockerService>();
    }


    private static void RepositoryInjection(this IServiceCollection services)
    {
        services
            .AddScoped<IUserRepository, UserRepository>();
        
        services
            .AddScoped<ILockerRepository, LockerRepository>();
    }
    
    public static void UseMigrations(this IApplicationBuilder app, IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
    }
}