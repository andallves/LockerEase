using LockerEase.Contracts.Services;
using LockerEase.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LockerEase.Controllers;

public class LockerController : Controller
{
    private readonly ILockerService _lockerService;

    public LockerController(ILockerService lockerService)
    {
        _lockerService = lockerService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var lockers = await _lockerService.GetAllLockers();

        if (lockers.Count == 0)
        {
            return NotFound();
        }
        
        return View(lockers);
    }

    public async Task<IActionResult> Register()
    {
        return View();
    }

    public async Task<IActionResult> Register(LockerModel locker)
    {
        if (locker == null)
        {
            return BadRequest();
        }

        await _lockerService.Register(locker);
        return Ok(locker);
    }

    public async Task<IActionResult> Update(int id)
    {
        return View();
    }

    public async Task<IActionResult> NotifyMaintanance()
    {
        return View();
    }

    // public async Task<IActionResult> NotifyMaintanance(LockerModel locker)
    // {
    //     
    // }

    public async Task<IActionResult> AddUserToLocker()
    {
        return View();
    }

    // public async Task<IActionResult> AddUserToLocker(UserModel user, int lockerId)
    // {
    //     
    // }
}