namespace Application.Features.Trainings.Models;

public class TrainingDayDto
{
    public DateOnly Date { get; set; }
    public List<TrainingDto> Trainings { get; set; }
}
