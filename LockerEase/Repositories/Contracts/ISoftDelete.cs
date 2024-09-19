namespace LockerEase.Repositories.Contracts;

public interface ISoftDelete
{
    public bool Active { get; set; }
}