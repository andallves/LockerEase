using LockerEase.Models;
using Microsoft.EntityFrameworkCore;

namespace LockerEase.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>
        options) : base(options){}
    
    public DbSet<UserModel> Users { get; set; }
}