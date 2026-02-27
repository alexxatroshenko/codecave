using Domain.Common;

namespace Domain.Entities;

public class TrainingInfo : Entity
{
    public string Title { get; set; } = null!;
    public int DurationTimeInMinutes { get; set; }
    public string Description { get; set; } = null!;

    public DateOnly TrainingDayDate { get; set; }
    public int TrainingStatusId { get; set; }

    public TrainingStatus? TrainingStatus { get; set; }
    public TrainingDay? TrainingDay { get; set; }
}
