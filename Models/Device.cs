// Models/Device.cs
namespace MabeApp.Models;

public class Device
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public string Description { get; set; }
    public string Model { get; set; }
    public DateTime LastMaintenance { get; set; }
}