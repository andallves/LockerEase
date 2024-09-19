using AutoMapper;
using LockerEase.Notifications;

namespace LockerEase.Services;

public class BaseService
{
    protected readonly INotificator Notificator;

    protected BaseService(INotificator notificator)
    {
        Notificator = notificator;
    }
}