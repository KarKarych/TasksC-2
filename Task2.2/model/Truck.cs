using System.Collections.Generic;
using System.Text;

namespace Task2._2.model
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
      if (_cargoInTruck.Count == 0) return "The truck is empty";

      var stringBuilder = new StringBuilder();
      stringBuilder.Append("Loads in the back:\n");
      foreach (var pair in _cargoInTruck) stringBuilder.Append($"Cargo: {pair.Key}. Weight: {pair.Value}\n");

      return stringBuilder.ToString();
    }

    public string GetCargoWeightByName(string name)
    {
      return _cargoInTruck.ContainsKey(name)
        ? $"Cargo weight {name}: {_cargoInTruck[name]}"
        : "There is no cargo under this name";
    }

    public string AddCargo(string name, int weight)
    {
      if (!SetTruckLoad(weight) || _cargoInTruck.ContainsKey(name))
        return "Either this cargo is already loaded, choose a different name of the cargo, " +
               "or the weight of the cargo is greater than the maximum";

      _cargoInTruck.Add(name, weight);
      return "The cargo has been successfully loaded";
    }

    public string UnloadTruck()
    {
      var pallet = new Dictionary<string, int>(_cargoInTruck);
      _cargoInTruck.Clear();

      if (pallet.Count == 0) return "The truck is empty";

      var stringBuilder = new StringBuilder();
      stringBuilder.Append("Unloaded cargo:\n");
      foreach (var (key, value) in pallet) stringBuilder.Append($"Cargo: {key}. Weight: {value}\n");

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