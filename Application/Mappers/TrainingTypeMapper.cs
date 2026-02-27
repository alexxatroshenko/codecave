using Application.Features.Trainings.Models;
using Application.Mappers.Common;
using Domain.Entities;

namespace Application.Mappers;

public class TrainingTypeMapper : IMapper<TrainingInfo, TrainingTypeDto>
{
    public TrainingTypeDto Map(TrainingInfo source)
    {
        return new TrainingTypeDto
        {
            Id = source.Id,
            Description = source.Description,
            DurationTimeInMinutes = source.DurationTimeInMinutes,
            Title = source.Title,
        };
    }

    public IReadOnlyList<TrainingTypeDto> Map(IReadOnlyList<TrainingInfo> sources)
    {
        return [.. sources.Select(Map)];
    }
}
