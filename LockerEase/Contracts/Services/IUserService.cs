using LockerEase.Models;

namespace LockerEase.Contracts.Services;

public interface IUserService
{
    Task<UserModel> Register(UserModel user);
    Task<UserModel> Edit(string id, UserModel user);
    UserModel GetUserById(string id);
    UserModel GetUserByEmail(string email);
    Task<List<UserModel>> GetUsers();
    Task<UserModel> Enable(string id);
    Task<UserModel> Disable(string id);
}