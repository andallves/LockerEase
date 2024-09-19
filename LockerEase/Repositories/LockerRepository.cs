using LockerEase.Contracts;
using LockerEase.Data;
using LockerEase.Models;
using LockerEase.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LockerEase.Repositories;

public class LockerRepository : Repository<LockerModel>, ILockerRepository
{
    public LockerRepository(ApplicationDbContext context) : base(context) {}
    
    public async Task<List<LockerModel>> GetAllLockers()
    {
        return await Context.Lockers.ToListAsync();
    }

    public void Register(LockerModel lockerModel)
    {
        Context.Lockers.Add(lockerModel);
    }

    public Task<LockerModel?> GetLockerById(int id)
    {
        return Context.Lockers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void UpdateLocker(LockerModel lockerModel)
    {
        Context.Lockers.Update(lockerModel);
    }

    public void Maintanance(LockerModel lockerModel)
    {
        Context.Lockers.Entry(lockerModel).Property(l => l.Maintanance).IsModified = true;
    }

    public void Available(LockerModel lockerModel)
    {
        Context.Lockers.Entry(lockerModel).Property(l => l.Available).IsModified = true;
    }
}