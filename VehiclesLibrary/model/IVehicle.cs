using VehiclesLibrary.model.enums;

namespace VehiclesLibrary.model
{
  public interface IVehicle
  {
    public GearType CurrentGear { get; }
    public decimal CurrentCarSpeed { get; }

    public string Accelerate(decimal deltaSpeed);
    public string ReduceSpeed(decimal deltaSpeed);
  }
}