using ToDoAppNTier.DataAccess.UnitofWork;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.Entities.Domains;

namespace ToDoAppNTier.Business.Services;

public class WorkService: IWorkService
{
    private readonly IUow _uow;

    public WorkService(IUow uow)
    {
        _uow = uow;
    }
    

    public async Task<List<WorkListDto>> GetAll()
    {
        var list = await _uow.GetRepository<Work>().GetAll();
        var workList = new List<WorkListDto>();

        if (list != null && list.Count > 0) 
        {
            foreach (var work in list)
            {
                workList.Add(new ()
                {
                    Definition = work.Definition,
                    Id = work.Id,
                    IsCompleted = work.IsCompleted
                });
            }
        }

        return workList;
    }
    
    
   
    public async Task Create(WorkCreateDto dto)
    {
       await _uow.GetRepository<Work>().Create(new()
        {
            IsCompleted = dto.IsCompleted,
            Definition = dto.Definition
        });

       await _uow.SaveChanges();
    }

    
   
    public async Task<WorkListDto> GetById(object id)
    {
        var work = await _uow.GetRepository<Work>().GetById(id);
        return new()
        {
            Definition = work.Definition,
            IsCompleted = work.IsCompleted
        };
        
    }

    public async Task Remove(object id)
    {
        var deleteWork = await _uow.GetRepository<Work>().GetById(id);
        _uow.GetRepository<Work>().Remove(deleteWork);
        await _uow.SaveChanges();
    }
    
    

    public async Task Update(WorkUpdateDto dto)
    {
        _uow.GetRepository<Work>().Update(new()
        {
            Id = dto.Id,
            Definition = dto.Definition,
            IsCompleted = dto.IsCompleted
        });

        await _uow.SaveChanges();
        
    }
    
    
}