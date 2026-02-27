using Application.Features.Trainings.Commands;
using Application.Features.Trainings.Models;
using Application.Features.Trainings.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrainDaily.Api.Endpoints.Common;

namespace TrainDaily.Api.Endpoints;

public class Trainings : IEndpoint
{
    private const string TestGroupPrefix = "training";

    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapGet(
            $"{TestGroupPrefix}/get-trainings",
            async ([FromQuery] int month, [FromQuery] int year, ISender sender) =>
            {
                var response = await GetMonthTrainings(sender, new GetMonthQuery(month, year));
                return Results.Ok(response);
            }
        );

        app.MapPut($"{TestGroupPrefix}/update-status", UpdateTrainingStatus);

        app.MapGet($"{TestGroupPrefix}/getalltypes", GetAllTrainingTypes);

        app.MapPost($"{TestGroupPrefix}/add",AddTraining);
    }

    private async Task<IEnumerable<TrainingDayDto>> GetMonthTrainings(
        ISender sender,
        GetMonthQuery query
    )
    {
        return await sender.Send(query);
    }

    private async Task UpdateTrainingStatus(ISender sender, UpdateTrainingStatusCommand command)
    {
        await sender.Send(command);
    }

    private async Task<IEnumerable<TrainingTypeDto>> GetAllTrainingTypes(ISender sender)
    {
        return await sender.Send(new GetAllTrainingTypesQuery());
    }

    private async Task<TrainingDto> AddTraining(ISender sender, AddTrainingCommand command)
    {
        return await sender.Send(command);
    }
}
