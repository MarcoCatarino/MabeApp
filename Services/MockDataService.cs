// Services/MockDataService.cs
using Device = MabeApp.Models.Device;


namespace MabeApp.Services;

public class MockDataService
{
    public List<Device> GetDevices()
    {
        return new List<Device>
        {
            new Device
            {
                Id = "1",
                Name = "Horno Mabe",
                ImageUrl = "horno.png",
                IsActive = true,
                Description = "Horno de convección con 5 funciones",
                Model = "MABE-H2023",
                LastMaintenance = DateTime.Now.AddMonths(-1)
            },
            new Device
            {
                Id = "2",
                Name = "Lavadora Mabe",
                ImageUrl = "lavadora.png",
                IsActive = false,
                Description = "Lavadora de 15 kg con sistema ahorrador",
                Model = "MABE-L1522",
                LastMaintenance = DateTime.Now.AddMonths(-3)
            }
            // Agrega más dispositivos según necesites
        };
    }
}