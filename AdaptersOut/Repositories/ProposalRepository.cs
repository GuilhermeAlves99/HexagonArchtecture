using AdaptersOut.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ports.Out;

namespace AdaptersOut.Repositories;

public class ProposalRepository : IProposalRepository
{
    private readonly AppDbContext _context;

    public ProposalRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(Proposal proposal)
    {
        var exists = await _context.Proposals
            .AnyAsync(p => p.Id == proposal.Id);

        if (!exists)
            await _context.Proposals.AddAsync(proposal);

        await _context.SaveChangesAsync();
    }

    public async Task<Proposal?> GetByIdAsync(Guid id)
    {
        return await _context.Proposals
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
