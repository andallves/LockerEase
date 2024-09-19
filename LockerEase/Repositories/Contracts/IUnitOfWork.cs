namespace LockerEase.Repositories.Contracts;

public interface IUnitOfWork
{
    Task<bool> Commit();
}