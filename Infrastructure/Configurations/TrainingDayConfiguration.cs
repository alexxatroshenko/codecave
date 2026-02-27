using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TrainingDayConfiguration : IEntityTypeConfiguration<TrainingDay>
{
    public void Configure(EntityTypeBuilder<TrainingDay> builder)
    {
        throw new NotImplementedException(); //todo !!
    }
}
