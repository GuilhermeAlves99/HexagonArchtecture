namespace API.DTOs.Contracts
{
    public class ContractResponse
    {
        public Guid Id { get; set; }
        public Guid ProposalId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
