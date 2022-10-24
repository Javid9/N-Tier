using AutoMapper;
using Common.ResponseObjects;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryDemo.Results;
using ToDoAppNTier.Business.Interfaces;
using ToDoAppNTier.Business.ValidationRules;
using ToDoAppNTier.DataAccess.UnitofWork;
using ToDoAppNTier.Dtos.Interfaces;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.Entities.Domains;

namespace ToDoAppNTier.Business.Services;

public class WorkService: IWorkService
{
    private readonly IUow _uow;
    private readonly IMapper _mapper;
    private readonly IValidator<WorkCreateDto> _createDtoValidator;
    private readonly IValidator<WorkUpdateDto> _updateDtoValidator;
    public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator, IValidator<WorkUpdateDto> updateDtoValidator)
    {
        _uow = uow;
        _mapper = mapper;
        _createDtoValidator = createDtoValidator;
        _updateDtoValidator = updateDtoValidator;
    }
    
    
    // Get All
    public async Task<List<WorkListDto>> GetAll()
    {
       return _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
    }
    
    
    
    
    // GetById
    public async Task<IDto> GetById<IDto>(int id)
    {
        return _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
    }



    // Create
    public async Task Create(WorkCreateDto dto)
    {
        var validationResult = _createDtoValidator.Validate(dto);
        if (validationResult.IsValid)
        {
             await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
            await _uow.SaveChanges();
        }

    }

  


    //Update
    public async Task Update(WorkUpdateDto dto)
    {
        var validationResult = _updateDtoValidator.Validate(dto);
        if (validationResult.IsValid)
        {
            var updateEntity = await _uow.GetRepository<Work>().Find(dto.Id);
            if (updateEntity != null)
            {
                _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto),updateEntity);
                await _uow.SaveChanges();
            }
        }

    }
    
    
    
    // Remove
    public async Task Remove(int id)
    {
      var removeEntity = await _uow.GetRepository<Work>().GetByFilter(x=>x.Id==id);
      if (removeEntity != null)
      {
         _uow.GetRepository<Work>().Remove(removeEntity);
          await _uow.SaveChanges();
      }
    }
    
    
    
    
}