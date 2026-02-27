using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TrainingDayConfiguration : IEntityTypeConfiguration<TrainingDay>
{
    public void Configure(EntityTypeBuilder<TrainingDay> builder)
    {
        builder.HasKey(t => t.Date);

        builder.Property(t => t.Date).IsRequired().HasColumnType("date");

        builder
            .HasMany(t => t.TrainingDayTrainingInfos)
            .WithOne(t => t.TrainingDay)
            .HasForeignKey(t => t.TrainingDayDate)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
