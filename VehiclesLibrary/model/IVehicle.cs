using VehiclesLibrary.model.enums;

namespace VehiclesLibrary.model
{
  public interface IVehicle
  {
    public GearType CurrentGear { get; }
    public decimal CurrentCarSpeed { get; }

    public void Accelerate(decimal deltaSpeed);
    public void ReduceSpeed(decimal deltaSpeed);
  }
}