using AdapterOut.Persistence;
using Domain.Entities;
using Ports.Out;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterOut.Repositories
{
    public class ContractRepository : IContractRepository
    {
        private readonly ContractDbContext _context;

        public ContractRepository(ContractDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(Contract contract)
        {
            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();
        }
    }


}

