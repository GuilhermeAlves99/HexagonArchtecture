using API.DTOs.Contracts;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/contracts")]
public class ContractController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] ContractProposalResquest request)
    {
        // UseCase CreateContract (futuro)
        return Created("", null);
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }


    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        return Ok();
    }
}