using LockerEase.Models;

namespace LockerEase.Contracts.Repositories;

public interface IUserRepository
{
    UserModel Register(UserModel user);
    Task<UserModel?> GetUserById(int id);
}