using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/colors")]
[ApiController]
public class ColorsController:ControllerBase
{
    private readonly IColorService _colorService;

    public ColorsController(IColorService colorService)
    {
        _colorService = colorService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _colorService.GetAll();
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var result = _colorService.GetById(id);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }
    
    [HttpPost]
    public IActionResult Add(Color color)
    {
        var result = _colorService.Add(color);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    
    [HttpPut]
    public IActionResult Update(Color color)
    {
        var result = _colorService.Update(color);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var result = _colorService.RemoveById(id);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    
    [HttpDelete]
    public IActionResult Delete([FromQuery] string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest("'name' must be provided.");
        }

        var result = _colorService.RemoveByName(name);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
}