using VehiclesLibrary.model.enums;

namespace VehiclesLibrary.model
{
  public interface IVehicle
  {
    public GearType CurrentGear { get; }
    public decimal CurrentCarSpeed { get; }

    public decimal Accelerate(decimal deltaSpeed);
    public decimal ReduceSpeed(decimal deltaSpeed);
  }
}