namespace Domain.Entities;

public class TrainingDay
{
    public DateOnly Date { get; set; }
    public ICollection<TrainingInfo> TrainingInfo { get; set; } = new List<TrainingInfo>();
}
