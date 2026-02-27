using Domain.Common;

namespace Domain.Entities;

public class TrainingInfo : Entity
{
    public string Title { get; set; } = null!;
    public int DurationTimeInMinutes { get; set; }
    public string Description { get; set; } = null!;

    public ICollection<TrainingDayTrainingInfo> TrainingDayTrainingInfos { get; set; } =
        new List<TrainingDayTrainingInfo>();
}
