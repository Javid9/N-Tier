using ToDoAppNTier.Dtos.Interfaces;
using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Business.Services;

public interface IWorkService
{
    Task<List<WorkListDto>> GetAll();
    Task<IDto> GetById<IDto>(int id);
    Task Create(WorkCreateDto dto);
    Task Update(WorkUpdateDto dto);
    Task Remove(int id);
} 