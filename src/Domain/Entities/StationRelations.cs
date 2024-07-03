namespace GreenEnergy.Domain.Entities;

public class StationRelations : BaseEntity
{
    public int StationSourceId { get; set; }
    public int StationDestinationId { get; set; }
    public Station StationDestination { get; set; } = null!;
    public Station StationSource { get; set; } = null!;
    public ElectricLineTypes LineTypes { get; set; }
    public IList<Observer> Observers { get; set; } = null!;
    public IList<LossOfElectricity> LossOfElectricities { get; set; } = null!;
}
