using Desafio4.Domain.Interfaces.IRepository;
using Desafio4.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace desafio4.Controllers;

[Route("api/[controller]")]
[ApiController] 
public class AddressController : ControllerBase
{
    private readonly IViaCepRepository _viacepRepository;

    public AddressController(IViaCepRepository viacepRepository)
    {
        _viacepRepository = viacepRepository;
    }

    [HttpGet("AddressByIdUser")]
    public Task<ViaCepDto> ListNames([FromQuery] int id)
    {
        return _viacepRepository.GetUserAddressByUserId(id);
    }
}