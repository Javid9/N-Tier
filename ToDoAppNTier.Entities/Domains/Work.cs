namespace ToDoAppNTier.Entities.Domains;

public class Work: BaseEntity
{
    public string? Definition { get; set; }
    public bool IsCompleted { get; set; }
    
}