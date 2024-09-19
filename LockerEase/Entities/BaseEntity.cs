using LockerEase.Entities.Contracts;

namespace LockerEase.Entities;

public class BaseEntity : IEntity
{
    public int Id { get; set; }
}