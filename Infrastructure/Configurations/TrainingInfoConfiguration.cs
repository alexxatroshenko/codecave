using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TrainingInfoConfiguration : IEntityTypeConfiguration<TrainingInfo>
{
    public void Configure(EntityTypeBuilder<TrainingInfo> builder)
    {
        throw new NotImplementedException(); //todo !!
    }
}
