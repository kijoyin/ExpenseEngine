using ExpenseEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseEngine.Domain
{
    // Comment constructor
    // Uncomment Onconfiguring
    // dotnet ef migrations add "description-unique"
    // dotnet ef database update
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
        {
        }
        public DbSet<ExpenseEntity> Expenses { get; set; }
        public DbSet<TagRuleEntity> TagRules { get; set; }
        //public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseEntity>()
                .Property(b => b.Created)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ExpenseEntity>()
                   .HasIndex(u => u.Description)
                   .IsUnique();
            modelBuilder.Entity<TagRuleEntity>()
                .Property(b => b.Created)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<TagRuleEntity>()
                   .HasIndex(u => u.Tag)
                   .IsUnique();
            modelBuilder.Entity<TagRuleEntity>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Server=192.168.1.55;Port=5432;Database=ExpenseManager;Username=expenseworker;Password=expenseworker");
    }
}
