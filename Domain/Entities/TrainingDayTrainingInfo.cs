namespace Domain.Entities;

public class TrainingDayTrainingInfo
{
    public DateOnly TrainingDayDate { get; set; }
    public int TrainingInfoId { get; set; }
    public int TrainingStatusId { get; set; }

    public TrainingDay? TrainingDay { get; set; }
    public TrainingInfo? TrainingInfo { get; set; }
    public TrainingStatus? TrainingStatus { get; set; }
}
