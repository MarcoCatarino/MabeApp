using MabeApp.Services;

namespace MabeApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
    }

    public AppShell(AuthService authService)
    {
        InitializeComponent();

        if (!authService.IsAuthenticated())
            Shell.Current.GoToAsync("//Login"); // Sin await para simplificar
    }
}