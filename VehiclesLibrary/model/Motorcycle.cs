using System;
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
      _motorcycleTrick = motorcycleTrick;
      return @"Трюк успешно совершён";
    }
  }
}