using Application.Features.Test.Queries;
using MediatR;
using TrainDaily.Api.Endpoints.Common;

namespace TrainDaily.Api.Endpoints;

public class Test : IEndpoint
{
    private const string TestGroupPrefix = "test";

    public void MapEndPoint(IEndpointRouteBuilder app)
    {
        app.MapGet($"{TestGroupPrefix}/get-test", GetTest);
    }

    private async Task<IResult> GetTest(ISender sender)
    {
        var response = await sender.Send(new GetTestQuery());
        return TypedResults.Ok(response);
    }
}
