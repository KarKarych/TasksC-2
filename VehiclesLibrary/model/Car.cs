using System;
using VehiclesLibrary.model.enums;

namespace VehiclesLibrary.model
{
  public abstract class Car : IVehicle
  {
    public GearType CurrentGear { get; private set; }
    public decimal CurrentCarSpeed { get; private set; }
    public decimal CurrentFuelConsumption { get; private set; }
    public MovementType CurrentDirectionOfMovement { get; private set; }

    protected Car()
    {
      CurrentFuelConsumption = 0;
      CurrentGear = GearType.Neutral;
      CurrentCarSpeed = 0;
      CurrentDirectionOfMovement = MovementType.StandStill;
    }

    public decimal Accelerate(decimal deltaSpeed)
    {
      GoAhead();
      CurrentCarSpeed += Math.Abs(deltaSpeed);
      CurrentFuelConsumption += Math.Abs(deltaSpeed) / 4;

      return CurrentCarSpeed;
    }

    public decimal ReduceSpeed(decimal deltaSpeed)
    {
      GoAhead();
      CurrentCarSpeed -= Math.Abs(deltaSpeed);
      CurrentFuelConsumption -= Math.Abs(deltaSpeed) / 4;
      
      return CurrentCarSpeed;
    }

    public GearType Stop()
    {
      CurrentDirectionOfMovement = MovementType.StandStill;
      CurrentGear = GearType.Neutral;

      return CurrentGear;
    }

    public GearType GoAhead()
    {
      CurrentDirectionOfMovement = MovementType.Forward;
      CurrentGear = GearType.ForwardRunning;
      
      return CurrentGear;
    }

    public GearType GoBack()
    {
      CurrentDirectionOfMovement = MovementType.Backward;
      CurrentGear = GearType.ReverseGear;
      
      return CurrentGear;
    }

    public GearType TurnLeft()
    {
      CurrentDirectionOfMovement = MovementType.Left;
      
      return CurrentGear;
    }

    public GearType TurnRight()
    {
      CurrentDirectionOfMovement = MovementType.Left;
      
      return CurrentGear;
    }
  }
}