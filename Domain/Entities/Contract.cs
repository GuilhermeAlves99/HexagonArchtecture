using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contract
    {
        public Guid Id { get; private set; }
        public Guid ProposalId { get; private set; }
        public DateTime ContractedAt { get; private set; }

        protected Contract() { }

        public Contract(Guid proposalId)
        {
            Id = Guid.NewGuid();
            ProposalId = proposalId;
            ContractedAt = DateTime.UtcNow;
        }
    }

}
