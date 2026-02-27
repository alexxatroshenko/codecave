using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TrainingInfoConfiguration : IEntityTypeConfiguration<TrainingInfo>
{
    public void Configure(EntityTypeBuilder<TrainingInfo> builder)
    {
        builder.ToTable("TrainingInfos");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id).ValueGeneratedOnAdd();

        builder.Property(t => t.Title).IsRequired().HasMaxLength(200).HasColumnType("varchar(200)");

        builder.Property(t => t.DurationTimeInMinutes).IsRequired().HasColumnType("int");

        builder
            .Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(1000)
            .HasColumnType("varchar(1000)");

        builder
            .HasMany(t => t.TrainingDayTrainingInfos)
            .WithOne(t => t.TrainingInfo)
            .HasForeignKey(t => t.TrainingInfoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
