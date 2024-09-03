using LockerEase.Contracts.Services;
using LockerEase.Data;
using LockerEase.Models;

namespace LockerEase.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<UserModel> Register(UserModel user)
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> Edit(string id, UserModel user)
    {
        throw new NotImplementedException();
    }

    public UserModel GetUserById(string id)
    {
        throw new NotImplementedException();
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