using Domain.Common;

namespace Domain.Entities;

public class TrainingStatus : Entity
{
    public string CodeName { get; set; } = null!;
    public string Name { get; set; } = null!;
}
