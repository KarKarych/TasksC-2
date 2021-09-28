using System;
using VehiclesLibrary.model.enums;

namespace VehiclesLibrary.model
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

    public MovementType Stop()
    {
      CurrentDirectionOfMovement = MovementType.StandStill;
      CurrentGear = GearType.Neutral;

      return CurrentDirectionOfMovement;
    }

    public MovementType GoAhead()
    {
      CurrentDirectionOfMovement = MovementType.Forward;
      CurrentGear = GearType.ForwardRunning;

      return CurrentDirectionOfMovement;
    }

    public MovementType GoBack()
    {
      CurrentDirectionOfMovement = MovementType.Backward;
      CurrentGear = GearType.ReverseGear;

      return CurrentDirectionOfMovement;
    }

    public MovementType TurnLeft()
    {
      CurrentDirectionOfMovement = MovementType.Left;

      return CurrentDirectionOfMovement;
    }

    public MovementType TurnRight()
    {
      CurrentDirectionOfMovement = MovementType.Left;

      return CurrentDirectionOfMovement;
    }
  }
}