using Desafio4.Domain.Interfaces.IServices;
using Desafio4.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace desafio4.Controllers;

[Route("api/[controller]")]
[ApiController] 
public class NomeController(IPersonService personService) : ControllerBase
{
    [HttpGet]
    public IActionResult ListNames()
    {
        return Ok(personService.GetAll());
    }
}