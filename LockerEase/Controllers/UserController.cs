using LockerEase.Contracts.Services;
using LockerEase.Models;
using Microsoft.AspNetCore.Mvc;

namespace LockerEase.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<IActionResult> Index()
    {

        var userProfile = await _userService.GetUserById(1);
        
        if (userProfile == null)
        {
            return NotFound();
        }
        
        return View(userProfile);
       
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserModel user)
    {
        await _userService.Register(user);
        return RedirectToAction("Index", "Auth");
    }
    
    public IActionResult Edit()
    {
        return View();
    }
    
    public IActionResult DeleteConfirm()
    {
        return View();
    }
}