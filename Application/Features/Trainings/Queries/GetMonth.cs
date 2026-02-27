using Application.Common.Interfaces;
using Application.Features.Trainings.Models;
using Application.Mappers.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Trainings.Queries;

public record GetMonthQuery(int Month, int Year) : IRequest<IEnumerable<TrainingDayDto>>;

public class GetMonthQueryHandler(
    IAppDbContext context,
    IMapper<TrainingDay, TrainingDayDto> trainingMapper
) : IRequestHandler<GetMonthQuery, IEnumerable<TrainingDayDto>>
{
    public async Task<IEnumerable<TrainingDayDto>> Handle(
        GetMonthQuery request,
        CancellationToken cancellationToken
    )
    {
        var days = await context
            .TrainingDays.Include(x => x.TrainingDayTrainingInfos)
                .ThenInclude(x => x.TrainingInfo)
            .Include(x => x.TrainingDayTrainingInfos)
                .ThenInclude(x => x.TrainingStatus)
            .Where(x => x.Date.Month == request.Month && x.Date.Year == request.Year)
            .OrderByDescending(x => x.Date)
            .ToListAsync(cancellationToken);

        return trainingMapper.Map(days);
    }
}
