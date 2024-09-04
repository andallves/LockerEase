using LockerEase.Models;
using Microsoft.EntityFrameworkCore;

namespace LockerEase.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<UserModel> Users { get; set; }
}