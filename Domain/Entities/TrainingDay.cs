namespace Domain.Entities;

public class TrainingDay
{
    public DateOnly Date { get; set; }
    public ICollection<TrainingDayTrainingInfo> TrainingDayTrainingInfos { get; set; } =
        new List<TrainingDayTrainingInfo>();
}
