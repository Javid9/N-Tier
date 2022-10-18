using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Business.Services;

public interface IWorkService
{
    Task<List<WorkListDto>> GetAll();
    Task Create(WorkCreateDto dto);
    Task<WorkListDto> GetById(object id);
    Task Remove(object id);
    Task Update(WorkUpdateDto dto);
} 