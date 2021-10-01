using System;
using static System.Int32;

namespace Task2._1
{
  internal static class Program
  {
    private static void Main()
    {
      int number;
      bool result;

      do
      {
        Console.WriteLine("Choose class:" +
                          "\n1. ComputerNetwork" +
                          "\n2. ChildComputerNetwork");
        result = TryParse(Console.ReadLine(), out number);
      } while (!result || number != 1 && number != 2);

      switch (number)
      {
        case 1:
          ComputerNetwork computerNetwork = null;

          do
          {
            Console.WriteLine(
              "Enter ComputerNetwork parameters: organizationName, numberOfWorkstations, avgStationsDistance " +
              "(line by line)");

            var organizationName = Console.ReadLine();
            result = TryParse(Console.ReadLine(), out var numberOfWorkstations);
            result &= TryParse(Console.ReadLine(), out var avgStationsDistance);

            if (result)
              computerNetwork = new ComputerNetwork(organizationName, numberOfWorkstations, avgStationsDistance);
          } while (!result);

          Console.WriteLine(computerNetwork);
          Console.WriteLine("Quality: " + computerNetwork.GetQuality());
          break;
        case 2:
          ChildComputerNetwork childComputerNetwork = null;

          do
          {
            Console.WriteLine(
              "Enter ComputerNetwork parameters: organizationName, numberOfWorkstations, avgStationsDistance, avgSpeed " +
              "(line by line)");

            var organizationName = Console.ReadLine();
            result = TryParse(Console.ReadLine(), out var numberOfWorkstations);
            result &= TryParse(Console.ReadLine(), out var avgStationsDistance);
            result &= TryParse(Console.ReadLine(), out var avgSpeed);

            if (result)
              childComputerNetwork = new ChildComputerNetwork(organizationName,
                numberOfWorkstations,
                avgStationsDistance,
                avgSpeed);
          } while (!result);

          Console.WriteLine(childComputerNetwork);
          Console.WriteLine("Quality: " + childComputerNetwork.GetQuality());
          break;
      }
    }
  }
}