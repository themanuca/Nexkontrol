using Application.Interfaces;
using Contract.DTOs;
using Domain.Models.Enum;
using Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Dash
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> GetSummaryAsync(Guid userId)
        {
            var transactions = await _context.Transactions
                .Include(t => t.Category)
                .Include(t => t.Account)
                .Where(t => t.UserId == userId)
                .ToListAsync();

            var totalIncome = transactions
                .Where(t => t.Type == TransactionType.Income)
                .Sum(t => t.Amount);

            var totalExpenses = transactions
                .Where(t => t.Type == TransactionType.Expense)
                .Sum(t => t.Amount);

            var expensesByCategory = transactions
                .Where(t => t.Type == TransactionType.Expense)
                .GroupBy(t => t.Category.Name)
                .Select(g => new CategorySummaryDto
                {
                    CategoryName = g.Key,
                    TotalSpent = g.Sum(t => t.Amount)
                })
                .ToList();

            var pending = transactions
                .Where(t => t.Status == TransactionStatus.Pending)
                .Select(t => new PendingTransactionDto
                {
                    Description = t.Description,
                    Amount = t.Amount,
                    Date = t.Date,
                    AccountName = t.Account.Name
                })
                .OrderBy(t => t.Date)
                .ToList();

            return new DashboardDto
            {
                TotalIncome = totalIncome,
                TotalExpenses = totalExpenses,
                ExpensesByCategory = expensesByCategory,
                PendingTransactions = pending
            };
        }
    }

}
