using LockerEase.Contracts.Services;
using LockerEase.Models;
using LockerEase.Notifications;
using LockerEase.Repositories.Contracts;

namespace LockerEase.Services;

public class LockerService : BaseService, ILockerService
{
    private readonly ILockerRepository _lockerRepository;

    public LockerService(INotificator notificator, ILockerRepository lockerRepository) : base(notificator)
    {
        _lockerRepository = lockerRepository;
    }
    
    public async Task<List<LockerModel>> GetAllLockers()
    {
        throw new NotImplementedException();
    }

    public async Task<LockerModel?> Register(LockerModel lockerModel)
    {
         _lockerRepository.Register(lockerModel);

         if (await _lockerRepository.UnitOfWork.Commit())
         {
             return lockerModel;
         }
         
         Notificator.Handle("Ocorreu um erro ao cadastrar novo usuário.");
         return null;
    }

    public Task<LockerModel?> UpdateLocker(int id, LockerModel lockerModel)
    {
        throw new NotImplementedException();
    }

    public Task<LockerModel?> GetLockerById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Maintanance(int id)
    {
        throw new NotImplementedException();
    }

    public Task Available(int id)
    {
        throw new NotImplementedException();
    }
}