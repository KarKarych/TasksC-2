using Task2._2.model.enums;

namespace Task2._2.model
{
  public abstract class Car : IVehicle
  {
    protected Car(decimal maxSpeed)
    {
      CurrentFuelConsumption = 0;
      CurrentGear = GearType.Neutral;
      CurrentCarSpeed = 0;
      CurrentDirectionOfMovement = MovementType.StandStill;
      IsActive = false;
      MaxSpeed = maxSpeed;
    }

    public decimal CurrentFuelConsumption { get; private set; }
    public MovementType CurrentDirectionOfMovement { get; private set; }
    public decimal MaxSpeed { get; }
    private bool IsActive { get; set; }
    public GearType CurrentGear { get; private set; }
    public decimal CurrentCarSpeed { get; private set; }

    public string Accelerate(decimal deltaSpeed)
    {
      if (!IsActive || CurrentDirectionOfMovement == MovementType.StandStill)
        return @"The vehicle is not started or is in neutral gear";

      GoAhead();
      if (CurrentCarSpeed + deltaSpeed < MaxSpeed)
      {
        CurrentCarSpeed += deltaSpeed;
        CurrentFuelConsumption += deltaSpeed / 4;
      }
      else
      {
        CurrentFuelConsumption += (MaxSpeed - CurrentCarSpeed) / 4;
        CurrentCarSpeed = MaxSpeed;
      }

      return @"Speed increase completed successfully";
      ;
    }

    public string ReduceSpeed(decimal deltaSpeed)
    {
      if (!IsActive || CurrentGear == GearType.Neutral)
        return @"The vehicle is not started or is in neutral gear";

      GoAhead();
      if (CurrentCarSpeed - deltaSpeed > 0)
      {
        CurrentCarSpeed -= deltaSpeed;
        CurrentFuelConsumption -= deltaSpeed / 4;
      }
      else
      {
        CurrentCarSpeed = 0;
        CurrentFuelConsumption = 0;
      }


      return @"Braking successfully completed";
    }

    public bool StartEngine()
    {
      IsActive = true;
      return IsActive;
    }

    public bool StopEngine()
    {
      IsActive = false;
      return IsActive;
    }

    public MovementType Stop()
    {
      IsActive = true;
      CurrentDirectionOfMovement = MovementType.StandStill;
      CurrentGear = GearType.Neutral;

      return CurrentDirectionOfMovement;
    }

    public MovementType GoAhead()
    {
      IsActive = true;
      CurrentDirectionOfMovement = MovementType.Forward;
      CurrentGear = GearType.Drive;

      return CurrentDirectionOfMovement;
    }

    public MovementType GoBack()
    {
      IsActive = true;
      CurrentDirectionOfMovement = MovementType.Backward;
      CurrentGear = GearType.Reverse;

      return CurrentDirectionOfMovement;
    }

    public MovementType TurnLeft()
    {
      IsActive = true;
      CurrentDirectionOfMovement = MovementType.Left;

      return CurrentDirectionOfMovement;
    }

    public MovementType TurnRight()
    {
      IsActive = true;
      CurrentDirectionOfMovement = MovementType.Left;

      return CurrentDirectionOfMovement;
    }
  }
}