using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/rentals")]
[ApiController]
public class RentalsController : ControllerBase
{
    private readonly IRentalService _rentalService;

    public RentalsController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _rentalService.GetAll();
        if (result.Success)
        {
            return Ok(result.Data);
        }

        return BadRequest(result.Message);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var result = _rentalService.GetById(id);
        if (result.Success)
        {
            return Ok(result.Data);
        }

        return BadRequest(result.Message);
    }

    [HttpPost]
    public IActionResult RentCar([FromBody] Rental rental)
    {
        if (rental == null || rental.CarId == Guid.Empty || rental.CustomerId == Guid.Empty)
        {
            return BadRequest("Invalid rental details.");
        }

        var result = _rentalService.RentCar(rental.CarId, rental.CustomerId);
        if (result.Success)
        {
            return Ok(result.Message);
        }

        return BadRequest(result.Message);
    }

    [HttpPut("return/{rentalId}")]
    public IActionResult ReturnCar(Guid rentalId)
    {
        var result = _rentalService.ReturnCar(rentalId);
        if (result.Success)
        {
            return Ok(result.Message);
        }

        return BadRequest(result.Message);
    }
}