using MabeApp.ViewModels;

namespace MabeApp.Views;

public partial class MainView : ContentPage
{
    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; // Inyecta el ViewModel

        // Opcional: Personaliza la barra de navegaci�n (color corporativo Mabe)
        NavigationPage.SetHasNavigationBar(this, true);
        NavigationPage.SetBackButtonTitle(this, "Atr�s"); // Solo aplica en iOS
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Opcional: Resetear la selecci�n al volver a esta p�gina
        if (BindingContext is MainViewModel vm)
        {
            vm.SelectedDevice = null;
        }
    }
}