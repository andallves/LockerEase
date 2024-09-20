
using LockerEase.Models.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;


namespace LockerEase.Settings;

public static class AuthenticationSettings
{
     public static void AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        var appSettingsSection = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(appSettingsSection);

        var appSettings = appSettingsSection.Get<JwtSettings>();
        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.IncludeErrorDetails = true; // <- great for debugging
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = appSettings?.Emissor ?? string.Empty,
                    ValidAudiences = appSettings?.Audiences()
                };
            })
            .AddCookie("Cookies", options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(1);

            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy(UserRole.Admin.ToString(), builder =>
            {
                builder
                    .RequireAuthenticatedUser()
                    .RequireClaim("UserRole", UserRole.Admin.ToString());
            });

            options.AddPolicy(UserRole.Default.ToString(), builder =>
            {
                builder
                    .RequireAuthenticatedUser()
                    .RequireClaim("UserRole", UserRole.Default.ToString());
            });
        });

        services
            .AddJwksManager()
            .UseJwtValidation();
        
        services.AddHttpContextAccessor();
    }

    public static void UseAuthenticationConfig(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}