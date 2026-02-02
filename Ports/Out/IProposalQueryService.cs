using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ports.Out
{
    public interface IProposalQueryService
    {
        Task<bool> IsApprovedAsync(Guid proposalId);
    }
}
