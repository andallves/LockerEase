using System.Reflection;
using LockerEase.Contracts.Services;
using LockerEase.Data;
using LockerEase.Models;
using LockerEase.Notifications;
using LockerEase.Repositories;
using LockerEase.Repositories.Contracts;
using LockerEase.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Security.Jwt.Core.Interfaces;
using ScottBrady91.AspNetCore.Identity;

namespace LockerEase.Services;

public static class DependencyInjection
{
    public static void SetupSettings(this IServiceCollection service, IConfiguration configuration)
    {
        service.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
    }
    
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
            .AddScoped<IUserAuthService, UserAuthService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<ILockerService, LockerService>()
            .AddScoped<ISessionService, SessionService>();

        services.AddSession(o =>
        {
            o.Cookie.HttpOnly = true;
            o.Cookie.IsEssential = true;
        });
    }


    private static void RepositoryInjection(this IServiceCollection services)
    {
        services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<ILockerRepository, LockerRepository>();
    }
    
    public static void UseMigrations(this IApplicationBuilder app, IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
    }
}