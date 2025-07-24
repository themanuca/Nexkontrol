using Application.Interfaces;
using Contract.DTOs;
using Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext appDbContext) {
            _context = appDbContext;
        }

        public async Task<Guid> CreateAccount(AccountCreateDto accountCreateDto)
        {

            var entity = new Domain.Models.Account
            {
                Id = Guid.NewGuid(),
                Name = accountCreateDto.Name,
                InitialBalance = accountCreateDto.InitialBalance,
                Type = accountCreateDto.Type,
                UserId = accountCreateDto.UserId,
            };
            _context.Accounts.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<List<AccountReadDto>>GetAllbyId(Guid userid)
        {
            return await _context.Accounts
                .Where(x=>x.UserId == userid)
                .Select(x=> new AccountReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    InitialBalance = x.InitialBalance,
                    Type = x.Type,
                    UserId = x.UserId,
                })
                .ToListAsync();
        }

    }
}
