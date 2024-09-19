using LockerEase.Models;

namespace LockerEase.Contracts.Services;

public interface ILockerService
{
    Task<List<LockerModel>> GetAllLockers();
    Task<LockerModel?> Register(LockerModel lockerModel);
    Task<LockerModel?> UpdateLocker(int id, LockerModel lockerModel);
    Task<LockerModel?> GetLockerById(int id);
    Task Maintanance(int id);
    Task Available(int id);
   
}