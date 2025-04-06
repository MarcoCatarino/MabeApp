// ViewModels/DetailsViewModel.cs
using Device = MabeApp.Models.Device;
using System.Windows.Input;

namespace MabeApp.ViewModels;

public class DetailsViewModel : BaseViewModel
{
    private Device _device;
    public Device Device
    {
        get => _device;
        set => SetProperty(ref _device, value);
    }

    public ICommand CloseCommand { get; }

    public DetailsViewModel()
    {
        CloseCommand = new Command(async () => await Shell.Current.Navigation.PopModalAsync());
    }

    // Método para recibir parámetros (opcional pero recomendado)
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("Device"))
        {
            Device = query["Device"] as Device;
        }
    }
}