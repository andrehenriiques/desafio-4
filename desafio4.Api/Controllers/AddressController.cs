using Desafio4.Domain.Interfaces.IRepository;
using Desafio4.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace desafio4.Controllers;

[Route("api/[controller]")]
[ApiController] 
public class AddressController(IViaCepRepository viacepRepository) : ControllerBase
{
    [HttpGet("AddressByIdUser")]
    public async Task<IActionResult> ListNames([FromQuery] int id)
    {
        try
        {
            var result = await viacepRepository.GetUserAddressByUserId(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}