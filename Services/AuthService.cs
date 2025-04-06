// Services/AuthService.cs
using MabeApp.Models;
using System.Text.Json;

namespace MabeApp.Services;

public class AuthService
{
    private const string AuthKey = "auth_status";
    private const string UsersKey = "registered_users";
    private List<User> _users = new();

    public AuthService()
    {
        // Cargar usuarios registrados al iniciar
        var usersJson = Preferences.Get(UsersKey, "[]");
        _users = JsonSerializer.Deserialize<List<User>>(usersJson) ?? new List<User>();
    }

    public bool IsAuthenticated() => Preferences.Get(AuthKey, false);

    public bool Login(string username, string password)
    {
        var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            Preferences.Set(AuthKey, true);
            return true;
        }
        return false;
    }

    public void RegisterUser(User newUser)
    {
        _users.Add(newUser);
        Preferences.Set(UsersKey, JsonSerializer.Serialize(_users));
    }

    public void Logout() => Preferences.Remove(AuthKey);
}