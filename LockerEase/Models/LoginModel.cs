using System.ComponentModel.DataAnnotations;

namespace LockerEase.Models;

public class LoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}