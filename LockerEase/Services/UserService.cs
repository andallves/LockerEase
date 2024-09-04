using LockerEase.Contracts.Repositories;
using LockerEase.Contracts.Services;
using LockerEase.Data;
using LockerEase.Models;
using LockerEase.Notifications;

namespace LockerEase.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserModel> Register(UserModel user)
    {
        return _userRepository.Register(user);
    }

    public Task<UserModel> Edit(string id, UserModel user)
    {
        throw new NotImplementedException();
    }

    public async Task<UserModel?> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public UserModel GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserModel>> GetUsers()
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> Enable(string id)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> Disable(string id)
    {
        throw new NotImplementedException();
    }
}