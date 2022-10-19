using System.ComponentModel.DataAnnotations;
using ToDoAppNTier.Dtos.Interfaces;

namespace ToDoAppNTier.Dtos.WorkDtos;

public class WorkCreateDto: IDto
{
    // [Required(ErrorMessage = "Definition is required")]
    public string? Definition { get; set; }
    public bool IsCompleted { get; set; }
}