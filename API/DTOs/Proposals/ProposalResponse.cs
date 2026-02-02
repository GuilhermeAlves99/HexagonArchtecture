namespace API.DTOs.Proposals
{
    public class ProposalResponse
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
