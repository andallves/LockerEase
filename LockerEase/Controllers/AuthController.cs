using System.Security.Claims;
using LockerEase.Contracts.Services;
using LockerEase.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LockerEase.Controllers;

public class AuthController : Controller
{
    private readonly IUserAuthService _userAuthService;
    private readonly ISessionService _sessionService;

    public AuthController(IUserAuthService userAuthService, ISessionService sessionService)
    {
        _userAuthService = userAuthService;
        _sessionService = sessionService;
    }
    
    [AllowAnonymous]
    public IActionResult Index()
    {
        if (_sessionService.GetSession() != null) return RedirectToAction("Index", "Home");
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(LoginModel login)
    {
        var authenticated = await _userAuthService.Login(login);
        if (authenticated)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, login.Email)
            };
            
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Home");
        }
        
        ModelState.AddModelError("", "Login failed. Please try again.");
        return RedirectToAction("Index", "Auth");
    
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Auth");
    }
}