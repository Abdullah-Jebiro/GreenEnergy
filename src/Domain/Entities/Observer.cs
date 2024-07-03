namespace GreenEnergy.Domain.Entities;

public class Observer : BaseAuditableEntity
{
    public int StationId { get; set; }
    public int StationRelationsId { get; set; }
    public StationRelations StationRelations { get; set; } = null!;
    public Station Station { get; set; } = null!;
    public DateTime FirstDateTime { get; set; }
    public long Result { get; set; }
}
