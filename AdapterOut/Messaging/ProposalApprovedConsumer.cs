using Application.UseCase;
using IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterOut.Messaging
{
    public class ProposalApprovedConsumer
    {
        private readonly CreateContractUseCase _useCase;

        public ProposalApprovedConsumer(CreateContractUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task HandleAsync(ProposalApprovedEvent @event)
        {
            await _useCase.ExecuteAsync(@event.ProposalId);
        }
    }
}
