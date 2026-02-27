using Application.Common.Interfaces;
using Application.Features.Trainings.Models;
using Application.Mappers.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Trainings.Commands;

public record AddTrainingCommand(
    int TrainingTypeId,
    DateOnly Date,
    int DurationTimeInMinutes,
    string Description
) : IRequest<TrainingDto>;

public class AddTrainingCommandHandler(IAppDbContext context, IMapper<TrainingInfo, TrainingDto> trainingInfoMapper)
    : IRequestHandler<AddTrainingCommand, TrainingDto>
{
    public async Task<TrainingDto> Handle(
        AddTrainingCommand request,
        CancellationToken cancellationToken
    )
    {
        var trainingInfo = await context.TrainingInfos.FirstOrDefaultAsync(
            x => x.Id == request.TrainingTypeId,
            cancellationToken
        );

        if (trainingInfo == null)
        {
            throw new InvalidOperationException(
                $"Training type with id {request.TrainingTypeId} not found"
            );
        }

        var trainingDay = await context
            .TrainingDays.Include(x => x.TrainingDayTrainingInfos)
            .FirstOrDefaultAsync(x => x.Date == request.Date, cancellationToken);

        if (trainingDay == null)
        {
            trainingDay = new TrainingDay
            {
                Date = request.Date,
                TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>(),
            };
            context.TrainingDays.Add(trainingDay);
        }

        var link = new TrainingDayTrainingInfo
        {
            TrainingDayDate = trainingDay.Date,
            TrainingInfoId = trainingInfo.Id,
            TrainingStatusId = 1,
        };

        trainingDay.TrainingDayTrainingInfos.Add(link);

        await context.SaveChangesAsync(cancellationToken);
        
        var response = trainingInfoMapper.Map(trainingInfo);
        response.Status = "Не выполнено";

        return response;
    }
}
