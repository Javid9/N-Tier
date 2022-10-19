using AutoMapper;
using ToDoAppNTier.DataAccess.UnitofWork;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.Entities.Domains;

namespace ToDoAppNTier.Business.Services;

public class WorkService: IWorkService
{
    private readonly IUow _uow;
    private readonly IMapper _mapper;
    public WorkService(IUow uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }
    
    // Get All
    public async Task<List<WorkListDto>> GetAll()
    {
        return _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
    }
    
    
    // GetById
    public async Task<WorkListDto> GetById(int id)
    {
       return _mapper.Map<WorkListDto>(await _uow.GetRepository<Work>().GetByFilter(x=>x.Id==id));
    }
    
    
    
   // Create
    public async Task Create(WorkCreateDto dto)
    {
        await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));

       await _uow.SaveChanges();
    }

    
    
    //Update
    public async Task Update(WorkUpdateDto dto)
    {
        _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto));
        await _uow.SaveChanges();

    }
    
    
    
    // Remove
    public async Task Remove(int id)
    {
        _uow.GetRepository<Work>().Remove(id);
        await _uow.SaveChanges();
    }
    
    
    
}