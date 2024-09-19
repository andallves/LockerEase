using LockerEase.Entities;
using LockerEase.Entities.Contracts;
using LockerEase.Models.Enums;

namespace LockerEase.Models;

public class LockerModel : Entity
{
    public int UserId { get; set; }
    public UserModel? User { get; set; }
    public int LockerNumber { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool Available { get; set; }
    public bool Maintanance { get; set; }
    public int BlocoId { get; set; }
    
}