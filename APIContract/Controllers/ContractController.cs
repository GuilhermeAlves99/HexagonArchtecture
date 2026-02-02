using APIContract.DTOs;
using Application.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace APIContract.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    public class ContractController : ControllerBase
    {
        private readonly CreateContractUseCase _createContract;

        public ContractController(CreateContractUseCase createContract)
        {
            _createContract = createContract;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContractRequest request)
        {
            var contractId = await _createContract.ExecuteAsync(request.ProposalId);

            return CreatedAtAction(nameof(Create), new { id = contractId }, null);
        }
    }
}
