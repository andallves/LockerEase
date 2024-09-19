using LockerEase.Models;

namespace LockerEase.Repositories.Contracts;

public interface IUserRepository : IRepository<UserModel>
{
    void Register(UserModel user);
    Task<UserModel?> GetUserById(int id);
}