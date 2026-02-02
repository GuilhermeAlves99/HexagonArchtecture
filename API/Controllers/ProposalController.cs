using API.DTOs.Proposals;
using Core.Application.UseCases.ApproveProposal;
using Core.Application.UseCases.CreateProposal;
using Core.Application.UseCases.RejectProposal;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/proposals")]
public class ProposalController : ControllerBase
{
    private readonly CreateProposalUseCase _createProposal;
    private readonly ApproveProposalUseCase _approveProposal;
    private readonly RejectProposalUseCase _rejectProposal;

    public ProposalController(
        CreateProposalUseCase createProposal,
        ApproveProposalUseCase approveProposal,
        RejectProposalUseCase rejectProposal)
    {
        _createProposal = createProposal;
        _approveProposal = approveProposal;
        _rejectProposal = rejectProposal;
    }

    // POST /api/proposals
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProposalRequest request)
    {
        var proposalId = await _createProposal.ExecuteAsync(request.CustomerName);

        return CreatedAtAction(
            nameof(GetById),
            new { id = proposalId },
            new { id = proposalId });
    }

    // PUT /api/proposals/{id}/approve
    [HttpPut("{id:guid}/approve")]
    public async Task<IActionResult> Approve(Guid id)
    {
        await _approveProposal.ExecuteAsync(id);
        return NoContent();
    }

    // PUT /api/proposals/{id}/reject
    [HttpPut("{id:guid}/reject")]
    public async Task<IActionResult> Reject(Guid id)
    {
        await _rejectProposal.ExecuteAsync(id);
        return NoContent();
    }

    // GET /api/proposals
    [HttpGet]
    public IActionResult GetAll()
    {
        // 🔜 ReadModel / QueryService
        // Aqui você pode depois usar Dapper ou EF somente leitura
        return Ok("GetAll proposals - to be implemented");
    }

    // GET /api/proposals/{id}
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        // 🔜 ReadModel / QueryService
        return Ok($"Get proposal {id} - to be implemented");
    }
}
