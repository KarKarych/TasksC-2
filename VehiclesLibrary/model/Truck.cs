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
      if (_cargoInTruck.Count == 0) return "Грузовик пуст";
      
      var stringBuilder = new StringBuilder();
      stringBuilder.Append("Грузы, находящиеся в кузове:\n");
      foreach (var pair in _cargoInTruck) stringBuilder.Append($"Груз: {pair.Key}. Вес: {pair.Value}\n");

      return stringBuilder.ToString();
    }

    public string GetCargoWeightByName(string name)
    {
      return _cargoInTruck.ContainsKey(name)
        ? $"Вес груза {name}: {_cargoInTruck[name]}"
        : "Груз под данным именем отсутствует";
    }

    public string AddCargo(string name, int weight)
    {
      if (!SetTruckLoad(weight) || _cargoInTruck.ContainsKey(name))
        return "Либо данный груз уже загружен, выберите другое название груза, либо вес груза больше максимального";

      _cargoInTruck.Add(name, weight);
      return "Груз успешно загружен";
    }

    public string UnloadTruck()
    {
      var pallet = new Dictionary<string, int>(_cargoInTruck);
      _cargoInTruck.Clear();
      
      if (pallet.Count == 0) return "Грузовик пуст";

      var stringBuilder = new StringBuilder();
      stringBuilder.Append("Выгруженные грузы:\n");
      foreach (var pair in pallet) stringBuilder.Append($"Груз: {pair.Key}. Вес: {pair.Value}\n");

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