using System;
using VehiclesLibrary.model.enums;

namespace VehiclesLibrary.model
{
  public class Tractor : Car
  {
    public Tractor(decimal maxSpeed) : base(maxSpeed)
    {
      _trailerAttachment = TractorTrailerAttachment.WithoutEquipment;
    }

    private TractorTrailerAttachment _trailerAttachment;

    public TractorTrailerAttachment GetTrailerAttachment()
    {
      return _trailerAttachment;
    }

    public string SetTrailerAttachment(TractorTrailerAttachment trailerAttachment)
    {
      _trailerAttachment = trailerAttachment;
      return $"Оборудование {_trailerAttachment} поставлено";
    }
  }
}