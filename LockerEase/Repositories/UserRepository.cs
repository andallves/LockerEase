using LockerEase.Contracts;
using LockerEase.Data;
using LockerEase.Models;
using LockerEase.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LockerEase.Repositories;

public class UserRepository : Repository<UserModel>, IUserRepository
{   
    public UserRepository(ApplicationDbContext context) : base(context) {}
    
    public void Register(UserModel user)
    {
        Context.Users.Add(user);
    }

    public async Task<UserModel?> GetUserById(int id)
    {
       return await Context.Users.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<UserModel?> GetUserByEmail(string email)
    {
        return await Context.Users.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(u => u.Email == email);
    }
}