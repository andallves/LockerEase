using System.Linq.Expressions;
using LockerEase.Entities;

namespace LockerEase.Repositories.Contracts;

public interface IRepository<T> : IDisposable where T : BaseEntity
{
    IUnitOfWork UnitOfWork { get; }
    Task<List<T>> Buscar(IFilter<T> filtro, CancellationToken cancellationToken = default);
    Task<List<T>> Buscar(Expression<Func<T, bool>> expression, bool asNoTracking = true,
        CancellationToken cancellationToken = default);
    Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression);
    Task<bool> Any(Expression<Func<T, bool>> expression);
}