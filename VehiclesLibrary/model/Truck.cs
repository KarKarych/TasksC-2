using System.Collections.Generic;
using System.Text;

namespace VehiclesLibrary.model
{
  public class Truck : Car
  {
    private readonly Dictionary<string, int> _cargoInTruck;
    private int _truckLoad;

    public Truck(decimal truckCapacity)
    {
      TruckCapacity = truckCapacity;
      _cargoInTruck = new Dictionary<string, int>();
      _truckLoad = 0;
    }

    public decimal TruckCapacity { get; }

    public int GetTruckLoad()
    {
      return _truckLoad;
    }

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
      if (_truckLoad + cargoWeight > TruckCapacity) return false;

      _truckLoad += cargoWeight;
      return true;
    }
  }
}