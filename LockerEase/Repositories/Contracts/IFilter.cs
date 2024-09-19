using LockerEase.Entities.Contracts;

namespace LockerEase.Repositories.Contracts;

public interface IFilter<T> where T : IEntity
{
    void ApplyFilter(ref IQueryable<T> queryable);
}