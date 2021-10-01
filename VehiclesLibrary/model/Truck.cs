using System.Collections.Generic;
using System.Text;

namespace VehiclesLibrary.model
{
  public class Truck : Car
  {
    private readonly Dictionary<string, int> _cargoInTruck;

    public Truck(decimal truckCapacity, decimal maxSpeed) : base(maxSpeed)
    {
      TruckCapacity = truckCapacity;
      TruckLoad = 0;
      _cargoInTruck = new Dictionary<string, int>();
    }

    public int TruckLoad { get; private set; }
    public decimal TruckCapacity { get; }

    public string GetAllCargo()
    {
      var stringBuilder = new StringBuilder();
      foreach (var pair in _cargoInTruck) stringBuilder.Append($"{pair.Key} – {pair.Value}\n");

      return stringBuilder.ToString();
    }

    public int GetCargoWeightByName(string name)
    {
      return _cargoInTruck.ContainsKey(name) ? _cargoInTruck[name] : 0;
    }

    public bool AddCargo(string name, int weight)
    {
      if (!SetTruckLoad(weight) || _cargoInTruck.ContainsKey(name))
        return false;

      _cargoInTruck.Add(name, weight);
      return true;
    }

    public string UnloadTruck()
    {
      var pallet = new Dictionary<string, int>(_cargoInTruck);
      _cargoInTruck.Clear();

      var stringBuilder = new StringBuilder();
      foreach (var pair in pallet) stringBuilder.Append($"{pair.Key} – {pair.Value}\n");

      return stringBuilder.ToString();
    }

    private bool SetTruckLoad(int cargoWeight)
    {
      if (TruckLoad + cargoWeight > TruckCapacity) return false;

      TruckLoad += cargoWeight;
      return true;
    }
  }
}