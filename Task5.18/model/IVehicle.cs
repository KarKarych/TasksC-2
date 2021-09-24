using Task5._18.model.enums;

namespace Task5._18.model
{
  public interface IVehicle
  {
    public GearType CurrentGear { get; }
    public decimal CurrentCarSpeed { get; }

    public void Accelerate(decimal deltaSpeed);
    public void ReduceSpeed(decimal deltaSpeed);
  }
}