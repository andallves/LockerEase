using LockerEase.Repositories.Contracts;

namespace LockerEase.Entities;

public class Entity : BaseEntity, ITracking
{
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
    public int CriadoPor { get; set; }
    public int AtualizadoPor { get; set; }
}