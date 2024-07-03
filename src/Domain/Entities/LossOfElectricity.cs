namespace GreenEnergy.Domain.Entities;

public class LossOfElectricity : BaseEntity
{
    public int? StationId { get; set; }
    public int? StationRelationsId { get; set; }
    public DateTime FirstDateTime { get; set; }
    public int LossResult { get; set; }
    public StationRelations StationRelations { get; set; } = null!;
    public Station Station { get; set; } = null!;
}
