using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomersController:ControllerBase
{
    private readonly ICustomerService _customerService;
    
    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _customerService.GetAll();
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var result = _customerService.GetById(id);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }
    
    [HttpPost]
    public IActionResult Add(Customer customer)
    {
        var result = _customerService.Add(customer);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    
    [HttpPut]
    public IActionResult Update(Customer customer)
    {
        var result = _customerService.Update(customer);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Remove(Guid id)
    {
        var result = _customerService.RemoveById(id);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
}