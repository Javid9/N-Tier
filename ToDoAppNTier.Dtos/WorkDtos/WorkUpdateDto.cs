using System.ComponentModel.DataAnnotations;
using ToDoAppNTier.Dtos.Interfaces;

namespace ToDoAppNTier.Dtos.WorkDtos;

public class WorkUpdateDto: IDto
{
    // [Range(1,int.MaxValue, ErrorMessage = "Id id required")]
    public int Id { get; set; }
    // [Required(ErrorMessage = "Definition is Required")]
    public string? Definition { get; set; }
    public bool IsCompleted { get; set; }
}