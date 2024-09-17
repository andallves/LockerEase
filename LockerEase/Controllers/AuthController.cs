using LockerEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace LockerEase.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    
}