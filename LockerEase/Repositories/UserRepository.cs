using LockerEase.Contracts.Repositories;
using LockerEase.Data;
using LockerEase.Models;
using Microsoft.EntityFrameworkCore;

namespace LockerEase.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public UserModel Register(UserModel user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        
        return user;
    }

    public async Task<UserModel?> GetUserById(int id)
    {
       return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
}