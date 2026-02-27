using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TrainingDayTrainingInfoConfiguration
    : IEntityTypeConfiguration<TrainingDayTrainingInfo>
{
    public void Configure(EntityTypeBuilder<TrainingDayTrainingInfo> builder)
    {
        builder.ToTable("TrainingDayTrainingInfos");

        builder.HasKey(x => new { x.TrainingDayDate, x.TrainingInfoId });

        builder
            .HasOne(x => x.TrainingDay)
            .WithMany(x => x.TrainingDayTrainingInfos)
            .HasForeignKey(x => x.TrainingDayDate)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.TrainingInfo)
            .WithMany(x => x.TrainingDayTrainingInfos)
            .HasForeignKey(x => x.TrainingInfoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.TrainingStatus)
            .WithMany()
            .HasForeignKey(x => x.TrainingStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
