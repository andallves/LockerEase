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

        // Verifica se o usuário foi encontrado
        if (userProfile == null)
        {
            return NotFound(); // Retorna uma resposta 404 se o usuário não for encontrado
        }

        // Retorna a View com o modelo de dados
        return View(userProfile);
       
    }

    public IActionResult Register()
    {
        return View();
    }
    
    public IActionResult Edit()
    {
        return View();
    }
    
    public IActionResult DeleteConfirm()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserModel user)
    {
        await _userService.Register(user);
        return RedirectToAction("Index", "Auth");
    }
}