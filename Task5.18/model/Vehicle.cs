namespace Task5._18.model
{
  public interface IVehicle
  {
    public decimal FuelConsumptionLevel { get; set; }
    public void Accelerate();
    public void TirePressureAdjustment(decimal pressure);
  }
}