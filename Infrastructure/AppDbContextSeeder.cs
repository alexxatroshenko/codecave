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

        if (!await db.TrainingStatuses.AnyAsync())
        {
            db.TrainingStatuses.AddRange(
                new TrainingStatus { CodeName = "Completed", Name = "Выполнено" },
                new TrainingStatus { CodeName = "NotCompleted", Name = "Не выполнено" }
            );
            await db.SaveChangesAsync();
        }

        if (!await db.TrainingInfos.AnyAsync())
        {
            // Создаём типы тренировок (шаблоны)
            var trainingTypes = new List<TrainingInfo>
            {
                new()
                {
                    Title = "Бег",
                    DurationTimeInMinutes = 30,
                    Description = "Утренний бег",
                },
                new()
                {
                    Title = "Йога",
                    DurationTimeInMinutes = 45,
                    Description = "Практика йоги",
                },
                new()
                {
                    Title = "Силовая",
                    DurationTimeInMinutes = 50,
                    Description = "Силовая тренировка",
                },
                new()
                {
                    Title = "Плавание",
                    DurationTimeInMinutes = 40,
                    Description = "Тренировка в бассейне",
                },
                new()
                {
                    Title = "Растяжка",
                    DurationTimeInMinutes = 15,
                    Description = "Растяжка мышц",
                },
                new()
                {
                    Title = "Кроссфит",
                    DurationTimeInMinutes = 60,
                    Description = "Интенсивная тренировка",
                },
                new()
                {
                    Title = "Вело",
                    DurationTimeInMinutes = 90,
                    Description = "Велопрогулка",
                },
                new()
                {
                    Title = "Пилатес",
                    DurationTimeInMinutes = 55,
                    Description = "Пилатес",
                },
            };

            await db.TrainingInfos.AddRangeAsync(trainingTypes);
            await db.SaveChangesAsync();
        }

        if (!await db.TrainingDays.AnyAsync())
        {
            // Создаём дни и связи с тренировками
            var trainingDays = new List<TrainingDay>
            {
                new()
                {
                    Date = new DateOnly(2026, 2, 1),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 1, TrainingStatusId = 2 }, // Бег - не выполнено
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 2, 3),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 2, TrainingStatusId = 1 }, // Йога - выполнено
                        new() { TrainingInfoId = 5, TrainingStatusId = 1 }, // Растяжка - выполнено
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 2, 5),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 3, TrainingStatusId = 1 }, // Силовая - выполнено
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 2, 8),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 4, TrainingStatusId = 1 }, // Плавание - выполнено
                        new() { TrainingInfoId = 2, TrainingStatusId = 1 }, // Плавание - выполнено
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 2, 10),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 4, TrainingStatusId = 1 },
                        new() { TrainingInfoId = 3, TrainingStatusId = 1 },
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 2, 12),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 3, TrainingStatusId = 1 },
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 2, 15),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 3, TrainingStatusId = 1 },
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 2, 18),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 4, TrainingStatusId = 1 },
                        new() { TrainingInfoId = 3, TrainingStatusId = 1 },
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 2, 22),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 3, TrainingStatusId = 1 },
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 2, 25),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 1, TrainingStatusId = 1 },
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 3, 2),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 1, TrainingStatusId = 1 },
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 3, 5),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 1, TrainingStatusId = 1 },
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 3, 9),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 1, TrainingStatusId = 1 },
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 3, 12),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 1, TrainingStatusId = 1 },
                    },
                },
                new()
                {
                    Date = new DateOnly(2026, 3, 15),
                    TrainingDayTrainingInfos = new List<TrainingDayTrainingInfo>
                    {
                        new() { TrainingInfoId = 1, TrainingStatusId = 1 },
                    },
                },
            };

            await db.TrainingDays.AddRangeAsync(trainingDays);
            await db.SaveChangesAsync();
        }
    }
}
