using GreenEnergy.Domain.Entities;

namespace GreenEnergy.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Station> Stations { get; }
    //DbSet<StationRelations> StationRelations { get; }
    //DbSet<Observer> Observers { get; }
    //DbSet<LossOfElectricity> LossOfElectricities { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
