using Application.Features.Trainings.Models;
using Application.Mappers.Common;
using Domain.Entities;

namespace Application.Mappers;

public class TrainingMapper : IMapper<TrainingDay, TrainingDayDto>, IMapper<TrainingInfo, TrainingDto>
{
    public TrainingDayDto Map(TrainingDay source)
    {
        return new TrainingDayDto
        {
            Date = source.Date,
            Trainings = source
                .TrainingDayTrainingInfos.Select(x => new TrainingDto
                {
                    Id = x.TrainingInfo!.Id,
                    Description = x.TrainingInfo.Description,
                    DurationTimeInMinutes = x.TrainingInfo.DurationTimeInMinutes,
                    Status = x.TrainingStatus!.Name,
                    Title = x.TrainingInfo.Title,
                })
                .ToList(),
        };
    }

    public IReadOnlyList<TrainingDayDto> Map(IReadOnlyList<TrainingDay> sources)
    {
        return [.. sources.Select(Map)];
    }

    public TrainingDto Map(TrainingInfo source)
    {
        return new TrainingDto
        {
            Id = source.Id,
            Description = source.Description,
            DurationTimeInMinutes = source.DurationTimeInMinutes,
            Title = source.Title,
        };
    }

    public IReadOnlyList<TrainingDto> Map(IReadOnlyList<TrainingInfo> sources)
    {
        return [..sources.Select(Map)];
    }
}
