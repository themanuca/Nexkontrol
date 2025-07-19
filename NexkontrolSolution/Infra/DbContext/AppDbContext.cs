using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DBContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<Budget> Budgets => Set<Budget>();
        public DbSet<Goal> Goals => Set<Goal>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict); // <== aqui

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // <== aqui também

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Account)
                .WithMany()
                .HasForeignKey(t => t.AccountId)
                .OnDelete(DeleteBehavior.Restrict); // opcional
        }

    }
}
