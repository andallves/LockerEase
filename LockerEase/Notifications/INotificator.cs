using FluentValidation.Results;

namespace LockerEase.Notifications;

public interface INotificator
{
    void Handle(string mensagem);
    void HandleNotFoundResource();
    IEnumerable<string> GetNotifications();
    bool HasNotification { get; }
    bool IsNotFoundResource { get; }

}