using LockerEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace LockerEase.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        
        var userProfile = new UserModel()
        {
            Id = "1",
            Name = "John Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "123-456-7890",
            Password = "Tes@2024",
            ProfilePictureUrl = "../Data/perfil.png"
        };
    
        return View(userProfile);
       
    }

    public IActionResult Register()
    {
        return View();
    }
}