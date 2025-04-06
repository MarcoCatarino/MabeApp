// Views/ProductView.xaml.cs
using MabeApp.ViewModels;

namespace MabeApp.Views;

public partial class ProductView : ContentPage
{
    public ProductView(ProductViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; // ViewModel inyectado
    }
}