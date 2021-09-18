namespace Task4._13
{
  public class ComputerNetwork
  {
    public ComputerNetwork(string organizationName, int numberOfWorkstations, int avgStationsDistance)
    {
      OrganizationName = organizationName;
      NumberOfWorkstations = numberOfWorkstations;
      AvgStationsDistance = avgStationsDistance;
    }

    public string OrganizationName { get; set; }

    public int NumberOfWorkstations { get; set; }

    public int AvgStationsDistance { get; set; }

    public virtual int GetQuality()
    {
      return NumberOfWorkstations * AvgStationsDistance;
    }

    public override string ToString()
    {
      return
        $"Organization name: {OrganizationName}\n" +
        $"Number of workstations: {NumberOfWorkstations}\n" +
        $"Average distance between stations {AvgStationsDistance}";
    }
  }
}