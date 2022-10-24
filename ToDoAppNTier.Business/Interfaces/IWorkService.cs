using Common.ResponseObjects;
using RepositoryDemo.Results;
using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Business.Interfaces;

public interface IWorkService
{
    Task<List<WorkListDto>> GetAll();
    Task<IDto> GetById<IDto>(int id);
    Task Create(WorkCreateDto dto);
    Task Update(WorkUpdateDto dto);
    Task Remove(int id);
} 