using System;
using System.Collections;
using System.Collections.Generic;
using Task5._18.model;
using static System.Int32;

namespace Task5._18
{
  class Program
  {
    static void Main()
    {
      IList trucks = new ArrayList();
      MainMenu(trucks);
    }

    static void MainMenu(IList trucks)
    {
      var exit = false;

      do
      {
        Console.WriteLine("\n---------------------------------------\n" +
                          "Choose action:\n" +
                          "1. Add truck.\n" +
                          "2. Delete truck\n" +
                          "3. Drive truck\n" +
                          "4. Get information about truck\n" +
                          "5. Get information about all trucks\n" +
                          "6. Exit\n" +
                          "---------------------------------------\n");
        if (TryParse(Console.ReadLine(), out var choice))
          switch (choice)
          {
            case 1:
              trucks.Add(CreateTruck());
              break;
            case 2:
              var number = SelectTruck(trucks.Count);
              if (number == -1)
              {
                Console.WriteLine("There are no trucks in the list");
                break;
              }

              trucks.RemoveAt(number);
              Console.WriteLine($"Truck {number} was removed");
              break;
            case 3:
              number = SelectTruck(trucks.Count);
              if (number == -1)
              {
                Console.WriteLine("There are no trucks in the list");
                break;
              }

              DriveTruckMenu((Truck)trucks[number]);
              break;
            case 4:
              number = SelectTruck(trucks.Count);
              if (number == -1)
              {
                Console.WriteLine("There are no trucks in the list");
                break;
              }

              GetInformationAboutTruck((Truck)trucks[number]);
              break;
            case 5:
              foreach (var truck in trucks)
              {
                GetInformationAboutTruck((Truck)truck);
              }
              break;
            case 6:
              exit = true;
              break;
          }
      } while (!exit);
    }

    private static void DriveTruckMenu(Truck truck)
    {
      var exit = false;
      do
      {
        Console.WriteLine("\n---------------------------------------\n" +
                          "Choose action:\n" +
                          "1. Go ahead\n" +
                          "2. Go back\n" +
                          "3. Turn right\n" +
                          "4. Turn left\n" +
                          "5. Stop\n" +
                          "6. Add cargo\n" +
                          "7. Unload truck\n" +
                          "8. Accelerate\n" +
                          "9. Reduce speed\n" +
                          "10. Exit\n" +
                          "---------------------------------------\n");
        if (TryParse(Console.ReadLine(), out var choice))
          switch (choice)
          {
            case 1:
              truck.GoAhead();
              Console.WriteLine("Truck is going forward");
              break;
            case 2:
              truck.GoBack();
              Console.WriteLine("Truck is going back");
              break;
            case 3:
              truck.TurnRight();
              Console.WriteLine("Truck turns right");
              break;
            case 4:
              truck.TurnLeft();
              Console.WriteLine("Truck turns left");
              break;
            case 5:
              truck.Stop();
              Console.WriteLine("Truck stops");
              break;
            case 6:
              bool result;
              do
              {
                Console.WriteLine("Enter name and weight of cargo (line by line)");
                var name = Console.ReadLine();
                result = TryParse(Console.ReadLine(), out var weight);
                if (result)
                  truck.AddCargo(name, weight);
              } while (!result);

              Console.WriteLine("Cargo is loaded");
              break;
            case 7:
              var cargo = truck.UnloadTruck();
              ShowCargo(cargo);
              break;
            case 8:
              do
              {
                Console.WriteLine("Enter speed for accelerate");
                result = decimal.TryParse(Console.ReadLine(), out var speed);
                if (result)
                  truck.Accelerate(speed);
              } while (!result);
              break;
            case 9:
              do
              {
                Console.WriteLine("Enter reduce speed");
                result = decimal.TryParse(Console.ReadLine(), out var speed);
                if (result)
                  truck.ReduceSpeed(speed);
              } while (!result);
              break;
            case 10:
              exit = true;
              break;
          }
      } while (!exit);
    }

    private static Truck CreateTruck()
    {
      bool result;
      Truck truck = null;

      do
      {
        Console.WriteLine("Enter truck capacity");

        result = decimal.TryParse(Console.ReadLine(), out var truckCapacity);

        if (result)
          truck = new Truck(truckCapacity);
      } while (!result);

      return truck;
    }

    private static void GetInformationAboutTruck(Truck truck)
    {
      Console.WriteLine($"\nTruck capacity: {truck.TruckCapacity}");
      Console.WriteLine($"Truck load: {truck.GetTruckLoad()}");
      Console.WriteLine($"Truck direction: {truck.CurrentDirectionOfMovement}");
      Console.WriteLine($"Truck gear: {truck.CurrentGear}");
      Console.WriteLine($"Truck speed: {truck.CurrentCarSpeed}");
      Console.WriteLine($"Truck fuel consumption: {truck.CurrentFuelConsumption}");
      ShowCargo(truck.GetAllCargo());
    }

    private static void ShowCargo(Dictionary<string, int> cargo)
    {
      Console.WriteLine("Truck cargo:");

      foreach (var (key, value) in cargo)
      {
        Console.WriteLine($"{key} {value}");
      }

      Console.WriteLine();
    }

    private static int SelectTruck(int trucksCount)
    {
      switch (trucksCount)
      {
        case <= 0:
          return -1;
        case 1:
          return 0;
      }

      int number;
      bool result;
      do
      {
        Console.Write($"Choose truck (1 - {trucksCount}): ");
        result = TryParse(Console.ReadLine(), out number);
      } while (!result || !(number >= 1 && number <= trucksCount));

      return number - 1;
    }
  }
}