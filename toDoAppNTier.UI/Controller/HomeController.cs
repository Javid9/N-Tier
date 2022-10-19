using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoAppNTier.Business.Services;
using ToDoAppNTier.Dtos.WorkDtos;

namespace toDoAppNTier.UI.Controller;

public class HomeController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IWorkService _workService;
    private readonly IMapper _mapper;
    public HomeController(IWorkService workService, IMapper mapper)
    {
        _workService = workService;
        _mapper = mapper;
    }

    
    public async Task<IActionResult> Index()
    {
        var workList = await _workService.GetAll();
        return View(workList);
    }

    
    
    
    public async Task<IActionResult> Create()
    {
        return View(new WorkCreateDto());
    }
    


    [HttpPost]
    public async Task<IActionResult> Create(WorkCreateDto dto)
    {
        if (ModelState.IsValid)
        {
            await _workService.Create(dto);
            return RedirectToAction("Index");
        }
       
        return View(dto);
    }


    public async Task<IActionResult> Update(int id)
    {
        var dto = await _workService.GetById(id);
        return View(_mapper.Map<WorkUpdateDto>(dto));
    }

    
     [HttpPost]
    public async Task<IActionResult> Update(WorkUpdateDto dto)
    {
        if (ModelState.IsValid)
        {
            await _workService.Update(dto);
            return RedirectToAction("Index");
        }

        return View(dto);
        
    }


    public async Task<IActionResult> Remove(int id)
    {
        await _workService.Remove(id);
        return RedirectToAction("Index");
    }
    
    
    

}