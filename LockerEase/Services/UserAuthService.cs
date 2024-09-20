using System.Security.Claims;
using LockerEase.Contracts.Services;
using LockerEase.Models;
using LockerEase.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using NetDevPack.Security.Jwt.Core.Interfaces;
using LockerEase.Notifications;
using LockerEase.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;


namespace LockerEase.Services;

public class UserAuthService : BaseService, IUserAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<UserModel> _passwordHasher;
    private readonly IJwtService _jwtService;
    private readonly JwtSettings _jwtSettings;
    private readonly ISessionService _sessionService;

    public UserAuthService(
        INotificator notificator, 
        IUserRepository userRepository,
        IPasswordHasher<UserModel> passwordHasher,
        IOptions<JwtSettings> jwtSettings,
        IJwtService jwtService,
        ISessionService sessionService) : base(notificator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
        _jwtSettings = jwtSettings.Value;
        _sessionService = sessionService;
        
    }

    public async Task<bool> Login(LoginModel login)
    {
        if (string.IsNullOrEmpty(login.Password))
        {
            Notificator.Handle("Não foi possível fazer o login, senha inválida.");
            return false;
        }

        if (string.IsNullOrEmpty(login.Email))
        {
            Notificator.Handle("Não foi possível fazer o login, email inválido.");
            return false;
        }
        
        var user = await _userRepository.GetUserByEmail(login.Email);
        if (user == null || !user.IsActive)
        {
            Notificator.HandleNotFoundResource();
            return false;
        }

        if (_passwordHasher.VerifyHashedPassword(user, user.Password, login.Password) !=
            PasswordVerificationResult.Failed)
        {
            _sessionService.CreateSession(user);
            return true;
        }
        
        Notificator.Handle("Não foi possível fazer o login");
        return false;
    }
}