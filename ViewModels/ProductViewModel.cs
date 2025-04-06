// ViewModels/ProductViewModel.cs
using MabeApp.Views;
using System.Windows.Input;
using Device = MabeApp.Models.Device;

namespace MabeApp.ViewModels;

public class ProductViewModel : BaseViewModel
{
    private Device _device;
    public Device Device
    {
        get => _device;
        set => SetProperty(ref _device, value);
    }

    public ICommand ShowDetailsCommand { get; }

    public ProductViewModel()
    {
        ShowDetailsCommand = new Command(async () => await ShowDetails());
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("Device"))
        {
            Device = query["Device"] as Device;
        }
    }

    private async Task ShowDetails()
    {
        if (Device == null) return;
        await Shell.Current.GoToAsync(nameof(DetailsView), new Dictionary<string, object>
        {
            { "Device", Device }
        });
    }
}