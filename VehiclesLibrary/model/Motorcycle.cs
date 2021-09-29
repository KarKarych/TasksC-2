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

    public MotorcycleTrick SetMotorcycleTrick(string motorcycleTrick)
    {
      var result = Enum.TryParse(motorcycleTrick, out MotorcycleTrick outMotorcycleTrick);

      if (!(result && Enum.IsDefined(typeof(MotorcycleTrick), outMotorcycleTrick)))
        return MotorcycleTrick.NoTrick;

      _motorcycleTrick = outMotorcycleTrick;
      return _motorcycleTrick;
    }
  }
}