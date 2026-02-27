using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class TrainingStatusConfiguration : IEntityTypeConfiguration<TrainingStatus>
{
    public void Configure(EntityTypeBuilder<TrainingStatus> builder)
    {
        throw new NotImplementedException(); //todo !!
    }
}
