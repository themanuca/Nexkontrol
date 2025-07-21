using Contract.DTOs;
using Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Application.Services.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TransactionReadDto>> GetAllAsync(Guid userId)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId)
                .Include(t => t.Account)
                .Include(t => t.Category)
                .OrderByDescending(t => t.Date)
                .Select(t => new TransactionReadDto
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    Date = t.Date,
                    Description = t.Description,
                    Notes = t.Notes,
                    Type = t.Type,
                    Status = t.Status,
                    AccountName = t.Account.Name,
                    CategoryName = t.Category.Name,
                    IsRecurring = t.IsRecurring,
                    RecurrenceInterval = t.RecurrenceInterval
                })
                .ToListAsync();
        }

        public async Task<TransactionReadDto> GetByIdAsync(Guid userId, Guid id)
        {
            var t = await _context.Transactions
                .Include(x => x.Account)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId)
                ?? throw new Exception("Transação não encontrada.");

            return new TransactionReadDto
            {
                Id = t.Id,
                Amount = t.Amount,
                Date = t.Date,
                Description = t.Description,
                Notes = t.Notes,
                Type = t.Type,
                Status = t.Status,
                AccountName = t.Account.Name,
                CategoryName = t.Category.Name,
                IsRecurring = t.IsRecurring,
                RecurrenceInterval = t.RecurrenceInterval
            };
        }

        public async Task<Guid> CreateAsync(Guid userId, TransactionCreateDto dto)
        {
            var entity = new Domain.Models.Transaction
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Amount = dto.Amount,
                Date = dto.Date,
                Description = dto.Description,
                Notes = dto.Notes,
                Type = dto.Type,
                Status = dto.Status,
                AccountId = dto.AccountId,
                CategoryId = dto.CategoryId,
                IsRecurring = dto.IsRecurring,
                RecurrenceInterval = dto.RecurrenceInterval
            };

            _context.Transactions.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(Guid userId, TransactionUpdateDto dto)
        {
            var t = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == dto.Id && t.UserId == userId)
                ?? throw new Exception("Transação não encontrada.");

            t.Amount = dto.Amount;
            t.Date = dto.Date;
            t.Description = dto.Description;
            t.Notes = dto.Notes;
            t.Type = dto.Type;
            t.Status = dto.Status;
            t.AccountId = dto.AccountId;
            t.CategoryId = dto.CategoryId;
            t.IsRecurring = dto.IsRecurring;
            t.RecurrenceInterval = dto.RecurrenceInterval;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid userId, Guid id)
        {
            var t = await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId)
                ?? throw new Exception("Transação não encontrada.");

            _context.Transactions.Remove(t);
            await _context.SaveChangesAsync();
        }
    }
}
