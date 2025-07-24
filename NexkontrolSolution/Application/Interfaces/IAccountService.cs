using Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<List<AccountReadDto>> GetAllbyId(Guid userid);
        Task<Guid> CreateAccount(AccountCreateDto accountCreateDto);
    }
}
