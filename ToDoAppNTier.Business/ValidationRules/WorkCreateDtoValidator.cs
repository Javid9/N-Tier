using FluentValidation;
using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Business.ValidationRules;

public class WorkCreateDtoValidator: AbstractValidator<WorkCreateDto>
{
    public WorkCreateDtoValidator()
    {
        RuleFor(x => x.Definition).NotEmpty();
    }

  
}