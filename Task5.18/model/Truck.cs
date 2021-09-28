using System.Collections.Generic;

namespace Task5._18.model
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

    public Dictionary<string, int> GetAllCargo()
    {
      return _cargoInTruck;
    }

    public int GetCargoWeightByName(string name)
    {
      return _cargoInTruck[name];
    }

    public bool AddCargo(string name, int weight)
    {
      if (!SetTruckLoad(weight)) return false;

      _cargoInTruck.Add(name, weight);
      return true;
    }

    public Dictionary<string, int> UnloadTruck()
    {
      var pallet = new Dictionary<string, int>(_cargoInTruck);
      _cargoInTruck.Clear();
      return pallet;
    }

    private bool SetTruckLoad(int cargoWeight)
    {
      if (_truckLoad + cargoWeight > TruckCapacity) return false;

      _truckLoad += cargoWeight;
      return true;
    }
  }
}