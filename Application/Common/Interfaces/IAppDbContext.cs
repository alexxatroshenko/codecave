using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<TrainingDay> TrainingDays { get; }
    DbSet<TrainingInfo> TrainingInfos { get; }
    DbSet<TrainingStatus> TrainingStatuses { get; }
    DbSet<TrainingDayTrainingInfo> TrainingDayTrainingInfos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
