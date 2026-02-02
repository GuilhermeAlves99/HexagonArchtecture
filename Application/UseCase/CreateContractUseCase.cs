using Core.Ports.Out;
using Domain.Entities;
using Ports.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class CreateContractUseCase
    {
        private readonly IProposalQueryService _proposalQuery;
        private readonly IContractRepository _contractRepository;

        public CreateContractUseCase(
            IProposalQueryService proposalQuery,
            IContractRepository contractRepository)
        {
            _proposalQuery = proposalQuery;
            _contractRepository = contractRepository;
        }

        public async Task<Guid> ExecuteAsync(Guid proposalId)
        {
            var isApproved = await _proposalQuery.IsApprovedAsync(proposalId);

            if (!isApproved)
                throw new InvalidOperationException("A proposta não foi aprovada");

            var contract = new Contract(proposalId);

            await _contractRepository.SaveAsync(contract);

            return contract.Id;
        }
    }
}
