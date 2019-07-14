using System;
using Microsoft.EntityFrameworkCore;
using SearchAccountsWithGraphQL.Api.Model;

namespace SearchAccountsWithGraphQL.Api.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :
            base(options)
        { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(p => p.Id);
        }
    }
}
