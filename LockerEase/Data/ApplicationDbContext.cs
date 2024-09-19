using FluentValidation.Results;
using LockerEase.Data.Extensions;
using LockerEase.Models;
using LockerEase.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LockerEase.Data;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

    public DbSet<UserModel> Users { get; set; } = null!;
    public DbSet<LockerModel> Lockers { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ApplyConfigurations(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
    
    public async Task<bool> Commit() => await SaveChangesAsync() > 0;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        ApplyTrackingChanges();
        return base.SaveChangesAsync(cancellationToken);
    }
    
    private void ApplyTrackingChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is ITracking && e.State is EntityState.Added or EntityState.Modified);
    
        foreach (var entityEntry in entries)
        {
            ((ITracking)entityEntry.Entity).AtualizadoEm = DateTime.Now;
            // ((ITracking)entityEntry.Entity).AtualizadoPor = _authenticatedUser.ObterIdentificador();
            
            if (entityEntry.State != EntityState.Added)
                continue;
    
            ((ITracking)entityEntry.Entity).CriadoEm = DateTime.Now;
            // ((ITracking)entityEntry.Entity).CriadoPor = _authenticatedUser.ObterIdentificador();
        }
    }
    
    private static void ApplyConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        
        modelBuilder.ApplyEntityConfiguration();
        modelBuilder.ApplyTrackingConfiguration();
        modelBuilder.ApplySoftDeleteConfiguration();
    }
}