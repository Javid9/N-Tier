using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoAppNTier.Business.Interfaces;
using ToDoAppNTier.Business.Services;
using ToDoAppNTier.Dtos.WorkDtos;

namespace toDoAppNTier.UI.Controller;

public class HomeController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IWorkService _workService;
    public HomeController(IWorkService workService)
    {
        _workService = workService;
    }

    
    public async Task<IActionResult> Index()
    {
     
        return View( await _workService.GetAll());
    }

    

        public async Task<IActionResult> Create()
    {
        return View(new WorkCreateDto());
    }
    


    [HttpPost]
    public async Task<IActionResult> Create(WorkCreateDto dto)
    {
            await _workService.Create(dto);
            return RedirectToAction("Index");
    }
    
    
    public async Task<IActionResult> Update(int id)
    {
        return View(await _workService.GetById<WorkUpdateDto>(id));
    }
 
    
     [HttpPost]
    public async Task<IActionResult> Update(WorkUpdateDto dto)
    {
            await _workService.Update(dto);
            return RedirectToAction("Index");
    }


    
    public async Task<IActionResult> Remove(int id)
    {
        await _workService.Remove(id);
        return RedirectToAction("Index");
    }

    


}