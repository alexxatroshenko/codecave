using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Trainings.Commands;

public record UpdateTrainingStatusCommand(int TrainingId, int StatusId, DateOnly Date)
    : IRequest<Unit>;

public class UpdateTrainingStatusCommandHandler(IAppDbContext context)
    : IRequestHandler<UpdateTrainingStatusCommand, Unit>
{
    public async Task<Unit> Handle(
        UpdateTrainingStatusCommand request,
        CancellationToken cancellationToken
    )
    {
        var link = await context.TrainingDayTrainingInfos.FirstOrDefaultAsync(
            x => x.TrainingInfoId == request.TrainingId && x.TrainingDayDate == request.Date,
            cancellationToken
        );

        if (link == null)
        {
            throw new InvalidOperationException(
                $"Training with id {request.TrainingId} not found for date {request.Date}"
            );
        }

        link.TrainingStatusId = request.StatusId;

        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
