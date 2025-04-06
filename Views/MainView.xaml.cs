using MabeApp.ViewModels;

namespace MabeApp.Views;

public partial class MainView : ContentPage
{
    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; // Inyecta el ViewModel

        // Opcional: Personaliza la barra de navegación (color corporativo Mabe)
        NavigationPage.SetHasNavigationBar(this, true);
        NavigationPage.SetBackButtonTitle(this, "Atrás"); // Solo aplica en iOS
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Opcional: Resetear la selección al volver a esta página
        if (BindingContext is MainViewModel vm)
        {
            vm.SelectedDevice = null;
        }
    }
}