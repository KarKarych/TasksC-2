using System;
using static System.Int32;

namespace Task4._13
{
  internal class Program
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
          var flag = true;
          ComputerNetwork computerNetwork = null;

          do
          {
            Console.WriteLine(
              "Enter ComputerNetwork parameters: organizationName, numberOfWorkstations, avgStationsDistance " +
              "(line by line)");

            var organizationName = Console.ReadLine();
            flag &= TryParse(Console.ReadLine(), out var numberOfWorkstations);
            flag &= TryParse(Console.ReadLine(), out var avgStationsDistance);

            if (flag)
              computerNetwork = new ComputerNetwork(organizationName, numberOfWorkstations, avgStationsDistance);
          } while (!flag);

          Console.WriteLine(computerNetwork);
          Console.WriteLine("Quality: " + computerNetwork.GetQuality());
          break;
        case 2:
          flag = true;
          ChildComputerNetwork childComputerNetwork = null;

          do
          {
            Console.WriteLine(
              "Enter ComputerNetwork parameters: organizationName, numberOfWorkstations, avgStationsDistance, avgSpeed " +
              "(line by line)");

            var organizationName = Console.ReadLine();
            flag &= TryParse(Console.ReadLine(), out var numberOfWorkstations);
            flag &= TryParse(Console.ReadLine(), out var avgStationsDistance);
            flag &= TryParse(Console.ReadLine(), out var avgSpeed);

            if (flag)
              childComputerNetwork = new ChildComputerNetwork(organizationName,
                numberOfWorkstations,
                avgStationsDistance,
                avgSpeed);
          } while (!flag);

          Console.WriteLine(childComputerNetwork);
          Console.WriteLine("Quality: " + childComputerNetwork.GetQuality());
          break;
      }
    }
  }
}