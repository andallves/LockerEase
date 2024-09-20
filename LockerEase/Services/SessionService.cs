using System.Text.Json;
using LockerEase.Contracts.Services;
using LockerEase.Models;

namespace LockerEase.Services;

public class SessionService : ISessionService
{
    private readonly IHttpContextAccessor _httpContext;

    public SessionService(IHttpContextAccessor httpContext)
    {
        _httpContext = httpContext;
    }

    public void CreateSession(UserModel user)
    {
       _httpContext.HttpContext?.Session.SetString("SessionUserLogged", JsonSerializer.Serialize(user));
    }

    public void RemoveSession()
    {
        _httpContext.HttpContext?.Session.Remove("sessionUserLogged");
    }

    public UserModel? GetSession()
    {
        string? sessionUser = _httpContext.HttpContext?.Session.GetString("SessionUserLogged");
        
        if (string.IsNullOrEmpty(sessionUser)) return null;
        return JsonSerializer.Deserialize<UserModel>(sessionUser);
    }
}