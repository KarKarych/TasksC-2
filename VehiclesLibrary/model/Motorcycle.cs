using VehiclesLibrary.model.enums;

namespace VehiclesLibrary.model
{
  public class Motorcycle : Car
  {
    private MotorcycleTrick _motorcycleTrick;

    public Motorcycle(decimal maxSpeed) : base(maxSpeed)
    {
      _motorcycleTrick = MotorcycleTrick.NoTrick;
    }

    public MotorcycleTrick GetMotorcycleTrick()
    {
      return _motorcycleTrick;
    }

    public string SetMotorcycleTrick(MotorcycleTrick motorcycleTrick)
    {
      if (motorcycleTrick == (MotorcycleTrick)(-1))
      {
        return @"Данного трюка не существует. Выберите существующий";
      }
      
      _motorcycleTrick = motorcycleTrick;
      return @"Трюк успешно совершён";
    }
  }
}