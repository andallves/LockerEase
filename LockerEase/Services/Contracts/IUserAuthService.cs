using LockerEase.Models;

namespace LockerEase.Contracts.Services;

public interface IUserAuthService
{
    Task<bool> Login(LoginModel login);
}