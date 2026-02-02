using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterOut.Persistence
{
    public class ContractDbContext : DbContext
    {
        public DbSet<Contract> Contracts => Set<Contract>();

        public ContractDbContext(DbContextOptions<ContractDbContext> options)
            : base(options)
        {
        }
    }
}
