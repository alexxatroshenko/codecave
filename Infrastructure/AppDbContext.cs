using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options),
        IAppDbContext
{
    public DbSet<TrainingDay> TrainingDays => Set<TrainingDay>();
    public DbSet<TrainingInfo> TrainingInfos => Set<TrainingInfo>();
    public DbSet<TrainingStatus> TrainingStatuses => Set<TrainingStatus>();
    public DbSet<TrainingDayTrainingInfo> TrainingDayTrainingInfos =>
        Set<TrainingDayTrainingInfo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
