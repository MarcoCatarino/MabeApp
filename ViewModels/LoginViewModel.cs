// ViewModels/LoginViewModel.cs
using MabeApp.Services;
using System.Windows.Input;

namespace MabeApp.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private readonly AuthService _authService;

    public string Username { get; set; }
    public string Password { get; set; }

    public ICommand LoginCommand { get; }
    public ICommand NavigateToSignUpCommand { get; }

    public LoginViewModel(AuthService authService)
    {
        _authService = authService;

        LoginCommand = new Command(async () => await Login());
        NavigateToSignUpCommand = new Command(async () => await GoToSignUp());
    }

    private async Task Login()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            await Shell.Current.DisplayAlert("Error", "Usuario y contraseña son obligatorios", "OK");
            return;
        }

        bool isAuthenticated = _authService.Login(Username, Password);

        if (isAuthenticated)
            await Shell.Current.GoToAsync("//MainView");
        else
            await Shell.Current.DisplayAlert("Error", "Credenciales incorrectas", "OK");
    }

    private async Task GoToSignUp() => await Shell.Current.GoToAsync("//SignUp");
}