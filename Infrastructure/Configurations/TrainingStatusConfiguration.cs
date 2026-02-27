using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TrainingStatusConfiguration : IEntityTypeConfiguration<TrainingStatus>
{
    public void Configure(EntityTypeBuilder<TrainingStatus> builder)
    {
        builder.ToTable("TrainingStatuses");

        builder.HasKey(ts => ts.Id);

        builder.Property(ts => ts.Id).ValueGeneratedOnAdd();

        builder
            .Property(ts => ts.CodeName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");

        builder
            .HasIndex(ts => ts.CodeName)
            .IsUnique()
            .HasDatabaseName("IX_TrainingStatuses_CodeName");

        builder
            .Property(ts => ts.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnType("varchar(100)");
    }
}
