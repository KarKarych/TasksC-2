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

    public TractorTrailerAttachment SetTrailerAttachment(string newTrailerAttachment)
    {
      var result = Enum.TryParse(
        newTrailerAttachment,
        out TractorTrailerAttachment outTrailerAttachment
      );

      if (!(result && Enum.IsDefined(typeof(TractorTrailerAttachment), outTrailerAttachment)))
        return TractorTrailerAttachment.WithoutEquipment;

      _trailerAttachment = outTrailerAttachment;
      return _trailerAttachment;
    }
  }
}