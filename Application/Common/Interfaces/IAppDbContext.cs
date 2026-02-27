using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<TrainingDay> TrainingDays { get; }
    DbSet<TrainingInfo> TrainingInfos { get; }
    DbSet<TrainingStatus> TrainingStatuses { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
