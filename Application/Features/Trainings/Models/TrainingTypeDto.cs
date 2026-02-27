namespace Application.Features.Trainings.Models;

public class TrainingTypeDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int DurationTimeInMinutes { get; set; }
    public string Description { get; set; } = null!;
}
