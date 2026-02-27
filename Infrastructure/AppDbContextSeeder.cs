using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class AppDbContextSeeder
{
    public static async Task SeedDbAsync(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await db.Database.MigrateAsync();

        if (!await db.TrainingDays.AnyAsync())
        {
            db.TrainingDays.Add(
                new TrainingDay
                {
                    Date = DateOnly.FromDateTime(DateTime.Today),
                    TrainingInfo = new List<TrainingInfo>(),
                }
            );
            await db.SaveChangesAsync();
        }
    }
}
