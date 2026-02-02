using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdaptersOut.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Proposal> Proposals { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
