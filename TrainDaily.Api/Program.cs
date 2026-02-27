using Application;
using Infrastructure;
using Scalar.AspNetCore;
using TrainDaily.Api.Endpoints.Common;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults().AddInfrastructureServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.Services.AddCors();
builder.Services.AddEndpoints();

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
else
{
    app.UseExceptionHandler();
}

app.UseHttpsRedirection();
app.UseCors(static builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.UseFileServer();

app.MapEndpoints();

await AppDbContextSeeder.SeedDbAsync(app);

app.Run();
