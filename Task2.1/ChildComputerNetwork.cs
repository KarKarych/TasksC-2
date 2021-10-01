namespace Task2._1
{
  public class ChildComputerNetwork : ComputerNetwork
  {
    public ChildComputerNetwork(string organizationName, int numberOfWorkstations, int avgStationsDistance,
      int avgSpeed) :
      base(organizationName, numberOfWorkstations, avgStationsDistance)
    {
      AvgSpeed = avgSpeed;
    }

    public int AvgSpeed { get; set; }

    public override int GetQuality()
    {
      return base.GetQuality() * AvgSpeed;
    }

    public override string ToString()
    {
      return base.ToString() +
             $"\nAverage speed: {AvgSpeed}";
    }
  }
}