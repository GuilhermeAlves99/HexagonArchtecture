using AdaptersOut.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ports.Out;

public class ContractRepository : IContractRepository
{
    private readonly AppDbContext _context;

    public ContractRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(Contract contract)
    {
        _context.Contracts.Add(contract);
        await _context.SaveChangesAsync();
    }

    public async Task<Contract?> GetByProposalIdAsync(Guid proposalId)
    {
        return await _context.Contracts
            .FirstOrDefaultAsync(c => c.ProposalId == proposalId);
    }
}
