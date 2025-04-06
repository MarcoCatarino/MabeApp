// Views/SignUpPage.xaml.cs
using MabeApp.ViewModels;

namespace MabeApp.Views;

public partial class SignUpPage : ContentPage
{
    public SignUpPage(SignUpViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}