namespace LockerEase.Models;

public class LockerModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserModel? User { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool Available { get; set; }
    public bool Maintence { get; set; }
    public string Bloco { get; set; }
}