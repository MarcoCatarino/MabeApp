// ViewModels/MainViewModel.cs
using Device = MabeApp.Models.Device;
using MabeApp.Services;
using MabeApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MabeApp.ViewModels;

public class MainViewModel : BaseViewModel
{    
    private readonly MockDataService _dataService;
    private Device _selectedDevice;

    public ObservableCollection<Device> Devices { get; }
    public Device SelectedDevice
    {
        get => _selectedDevice;
        set => SetProperty(ref _selectedDevice, value);
    }

    public ICommand GoToProductCommand { get; }

    public MainViewModel(MockDataService dataService)
    {
        _dataService = dataService;
        Devices = new ObservableCollection<Device>(_dataService.GetDevices());

        GoToProductCommand = new Command(async () => await GoToProductView());
    }

    private async Task GoToProductView()
    {
        if (SelectedDevice == null) return;

        var parameters = new Dictionary<string, object>
        {
            { "Device", SelectedDevice }
        };

        await Shell.Current.GoToAsync(nameof(ProductView), parameters);
        SelectedDevice = null;
    }

}