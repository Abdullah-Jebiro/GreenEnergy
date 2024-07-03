namespace GreenEnergy.Domain.Entities;

public class Station: BaseEntity
{
    public required string Name { get; set; }
    public IList<StationRelations> StationRelations { get; set; } = null!;
    public IList<Observer> Observers { get; set; } = null!;
    public IList<LossOfElectricity> LossOfElectricities { get; set; } = null!;
}
