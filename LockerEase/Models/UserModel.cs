using LockerEase.Entities;

namespace LockerEase.Models;

public class UserModel : Entity
{
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Curso { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = String.Empty;
    public bool IsActive { get; set; } = true;
    public string? ProfilePictureUrl { get; set; } = null;
}