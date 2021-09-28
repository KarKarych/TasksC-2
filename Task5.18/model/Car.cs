using Task5._18.model.enums;

namespace Task5._18.model
{
  public abstract class Car : IVehicle
  {
    protected Car()
    {
      CurrentFuelConsumption = 0;
      CurrentGear = GearType.Neutral;
      CurrentCarSpeed = 0;
      CurrentDirectionOfMovement = MovementType.StandStill;
    }

    public decimal CurrentFuelConsumption { get; private set; }
    public MovementType CurrentDirectionOfMovement { get; private set; }
    public GearType CurrentGear { get; private set; }
    public decimal CurrentCarSpeed { get; private set; }

    public void Accelerate(decimal deltaSpeed)
    {
      GoAhead();
      CurrentCarSpeed += deltaSpeed;
      CurrentFuelConsumption += deltaSpeed / 4;
    }

    public void ReduceSpeed(decimal deltaSpeed)
    {
      GoAhead();
      CurrentCarSpeed -= deltaSpeed;
      CurrentFuelConsumption -= deltaSpeed / 4;
    }

    public void Stop()
    {
      CurrentDirectionOfMovement = MovementType.StandStill;
      CurrentGear = GearType.Neutral;
    }

    public void GoAhead()
    {
      CurrentDirectionOfMovement = MovementType.Forward;
      CurrentGear = GearType.ForwardRunning;
    }

    public void GoBack()
    {
      CurrentDirectionOfMovement = MovementType.Backward;
      CurrentGear = GearType.ReverseGear;
    }

    public void TurnLeft()
    {
      CurrentDirectionOfMovement = MovementType.Left;
    }

    public void TurnRight()
    {
      CurrentDirectionOfMovement = MovementType.Left;
    }
  }
}