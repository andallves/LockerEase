using LockerEase.Models;

namespace LockerEase.Repositories.Contracts;

public interface ILockerRepository : IRepository<LockerModel>
{
    Task<List<LockerModel>> GetAllLockers();
    void Register(LockerModel lockerModel);
    Task<LockerModel?> GetLockerById(int id);
    void UpdateLocker(LockerModel lockerModel);
    void Maintanance(LockerModel lockerModel);
    void Available(LockerModel lockerModel);
}