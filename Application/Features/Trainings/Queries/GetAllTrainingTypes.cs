using Application.Common.Interfaces;
using Application.Features.Trainings.Models;
using Application.Mappers.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Trainings.Queries;

public record GetAllTrainingTypesQuery : IRequest<IEnumerable<TrainingTypeDto>>;

public class GetAllTrainingTypesQueryHandler(
    IAppDbContext context,
    IMapper<TrainingInfo, TrainingTypeDto> typeMapper
) : IRequestHandler<GetAllTrainingTypesQuery, IEnumerable<TrainingTypeDto>>
{
    public async Task<IEnumerable<TrainingTypeDto>> Handle(
        GetAllTrainingTypesQuery request,
        CancellationToken cancellationToken
    )
    {
        var allTrainingInfos = await context.TrainingInfos.ToListAsync(cancellationToken);

        return typeMapper.Map(allTrainingInfos);
    }
}
