// ViewModels/SignUpViewModel.cs
using MabeApp.Models;
using MabeApp.Services;
using System.Windows.Input;

namespace MabeApp.ViewModels;

public class SignUpViewModel : BaseViewModel
{
    private readonly AuthService _authService;

    // Propiedades bindeables
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    // Comandos
    public ICommand SignUpCommand { get; }
    public ICommand NavigateToLoginCommand { get; }

    public SignUpViewModel(AuthService authService)
    {
        _authService = authService;

        SignUpCommand = new Command(async () => await SignUp());
        NavigateToLoginCommand = new Command(async () => await GoToLogin());
    }

    private async Task SignUp()
    {
        // Validaciones básicas
        if (string.IsNullOrWhiteSpace(Username))
        {
            await Shell.Current.DisplayAlert("Error", "El usuario es obligatorio", "OK");
            return;
        }

        if (Password != ConfirmPassword)
        {
            await Shell.Current.DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
            return;
        }

        // Crear el nuevo usuario
        var newUser = new User
        {
            FullName = FullName,
            Username = Username,
            Email = Email,
            Password = Password // ¡En producción usaríamos hashing aquí!
        };

        // Registrar al usuario (AuthService ya inyectado)
        _authService.RegisterUser(newUser);

        await Shell.Current.DisplayAlert("Éxito", "Registro completado", "OK");
        await Shell.Current.GoToAsync("//Login");
    }

    private async Task GoToLogin() => await Shell.Current.GoToAsync("//Login");
}