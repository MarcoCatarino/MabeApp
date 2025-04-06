// Models/User.cs
namespace MabeApp.Models;

public class User
{
    // Propiedades básicas para autenticación
    public string Username { get; set; }
    public string Password { get; set; }  // En producción, usaría SecureStorage o hashing
    public string Email { get; set; }
    public string FullName { get; set; }

    // Propiedades adicionales (opcionales)
    public DateTime RegistrationDate { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;

    // Método para validar credenciales (opcional)
    public bool ValidateCredentials(string inputPassword)
    {
        return Password == inputPassword; // Comparación básica (no seguro para producción)
    }
}