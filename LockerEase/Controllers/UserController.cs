using Microsoft.AspNetCore.Mvc;

namespace LockerEase.Controllers;

public class UsuarioController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}