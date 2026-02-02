using AdapterIn.APIContract.DTOs;
using Core.Ports.Out;
using Ports.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AdapterOut.Repositories
{
    public class ProposalQueryService : IProposalQueryService
    {
        private readonly HttpClient _httpClient;

        public ProposalQueryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> IsApprovedAsync(Guid proposalId)
        {
            var response = await _httpClient.GetAsync($"/api/proposals/{proposalId}");

            if (!response.IsSuccessStatusCode)
                return false;

            var proposal = await response.Content.ReadFromJsonAsync<ProposalDTO>();

            return proposal.Status == "Approved";
        }
    }
}
