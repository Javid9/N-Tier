using System.ComponentModel.DataAnnotations;

namespace ToDoAppNTier.Dtos.WorkDtos;

public class WorkCreateDto
{
    [Required(ErrorMessage = "Definition is required")]
    public string? Definition { get; set; }
    public bool IsCompleted { get; set; }
}