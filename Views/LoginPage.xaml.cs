// Views/LoginPage.xaml.cs
using MabeApp.ViewModels;

namespace MabeApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; // Inyección del ViewModel
    }
}