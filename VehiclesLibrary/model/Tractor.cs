using VehiclesLibrary.model.enums;

namespace VehiclesLibrary.model
{
  public class Tractor : Car
  {
    private TractorTrailerAttachment _trailerAttachment;

    public Tractor(decimal maxSpeed) : base(maxSpeed)
    {
      _trailerAttachment = TractorTrailerAttachment.WithoutEquipment;
    }

    public TractorTrailerAttachment GetTrailerAttachment()
    {
      return _trailerAttachment;
    }

    public string SetTrailerAttachment(TractorTrailerAttachment trailerAttachment)
    {
      if (trailerAttachment == (TractorTrailerAttachment)(-1))
      {
        return @"Данного оборудования не существует. Выберите существующее оборудование";
      }
      _trailerAttachment = trailerAttachment;
      return $"Оборудование {_trailerAttachment} поставлено";
    }
  }
}