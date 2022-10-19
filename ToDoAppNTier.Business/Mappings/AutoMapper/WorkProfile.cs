using AutoMapper;
using ToDoAppNTier.Dtos.WorkDtos;
using ToDoAppNTier.Entities.Domains;

namespace ToDoAppNTier.Business.Mappings.AutoMapper;

public class WorkProfile: Profile
{
    public WorkProfile()
    {
        CreateMap<Work, WorkListDto>().ReverseMap();
        CreateMap<Work, WorkCreateDto>().ReverseMap();
        CreateMap<Work, WorkUpdateDto>().ReverseMap();
        CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();
    }
}