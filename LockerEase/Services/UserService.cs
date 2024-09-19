using LockerEase.Contracts.Services;
using LockerEase.Models;
using LockerEase.Notifications;
using LockerEase.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;

namespace LockerEase.Services;

public class UserService : BaseService, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<UserModel> _passwordHasher;

    public UserService(INotificator notificator, IPasswordHasher<UserModel> passwordHasher, IUserRepository userRepository) : base(notificator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }
    
    
    public async Task<UserModel> Register(UserModel user)
    {
        
        user.Password = _passwordHasher.HashPassword(user, user.Password);
        
        _userRepository.Register(user);
        if (await _userRepository.UnitOfWork.Commit())
        {
            return user;
        }
        return null;

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

    public Task<UserModel> GetLocker(string id, LockerModel locker)
    {
        throw new NotImplementedException();
    }
}