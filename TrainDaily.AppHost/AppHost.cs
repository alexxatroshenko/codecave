var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddPostgres("postgres").WithDataVolume().WithPgAdmin().AddDatabase("db");

var weatherApi = builder
    .AddProject<Projects.TrainDaily_Api>("backend")
    .WithExternalHttpEndpoints()
    .WithReference(db)
    .WaitFor(db);

builder
    .AddJavaScriptApp("angular", "../TrainDaily.Client", runScriptName: "start")
    .WithReference(weatherApi)
    .WaitFor(weatherApi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
