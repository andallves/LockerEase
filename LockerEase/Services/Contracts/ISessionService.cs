using LockerEase.Models;

namespace LockerEase.Contracts.Services;

public interface ISessionService
{
    void CreateSession(UserModel user);
    void RemoveSession();
    UserModel? GetSession();
    
}