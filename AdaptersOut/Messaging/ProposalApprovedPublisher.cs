using Ports.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptersOut.Messaging
{
    public class ProposalApprovedPublisher : IProposalApprovedPublisher
    {
        public Task PublishAsync(Guid proposalId, string customerName)
        {
            Console.WriteLine(
                $"Proposal approved | Id: {proposalId} | Customer: {customerName}"
            );

            return Task.CompletedTask;
        }
    }
}
