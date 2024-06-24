using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/brands")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;
    
    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _brandService.GetAll();
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var result = _brandService.GetById(id);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }
    
    [HttpPost]
    public IActionResult Add(Brand brand)
    {
        var result = _brandService.Add(brand);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    
    [HttpPut]
    public IActionResult Update(Brand brand)
    {
        var result = _brandService.Update(brand);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Remove(Guid id)
    {
        var result = _brandService.RemoveById(id);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
}