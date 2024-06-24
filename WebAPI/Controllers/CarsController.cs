using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/cars")]
[ApiController]
public class CarsController:ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _carService.GetAllCarsDetails();
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var result = _carService.GetCarDetailsByCarId(id);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }
    
    [HttpPost]
    public IActionResult Add(CarDetailDto car)
    {
        var result = _carService.Add(car);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    
    [HttpPut]
    public IActionResult Update(CarDetailDto car)
    {
        var result = _carService.Update(car);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Remove(Guid id)
    {
        var result = _carService.RemoveById(id);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
}