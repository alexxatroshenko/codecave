using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddInfrastructureServices(
        this IHostApplicationBuilder builder
    )
    {
        var services = builder.Services;

        builder.AddNpgsqlDbContext<AppDbContext>(
            "db",
            settings =>
            {
                settings.DisableRetry = false;
                settings.CommandTimeout = 30;
            }
        );

        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());

        return builder;
    }
}
