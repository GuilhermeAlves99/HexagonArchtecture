using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
{
    public void Configure(EntityTypeBuilder<Proposal> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.CustomerName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Status)
            .IsRequired();
    }
}
