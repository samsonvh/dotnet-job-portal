using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Infrastructure.Persistence
{
    public class JobPortalDbContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Company> Companies => Set<Company>();

        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobPortalDbContext).Assembly);
        }
    }
}
