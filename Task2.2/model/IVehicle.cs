using Task2._2.model.enums;

namespace Task2._2.model
{
  public interface IVehicle
  {
    public GearType CurrentGear { get; }
    public decimal CurrentCarSpeed { get; }

    public string Accelerate(decimal deltaSpeed);
    public string ReduceSpeed(decimal deltaSpeed);
  }
}