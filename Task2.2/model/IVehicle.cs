using Task2._2.model.enums;

namespace Task2._2.model
{
  public interface IVehicle
  {
    public GearType CurrentGear { get; }
    public decimal CurrentCarSpeed { get; }

    public void Accelerate(decimal deltaSpeed);
    public void ReduceSpeed(decimal deltaSpeed);
  }
}