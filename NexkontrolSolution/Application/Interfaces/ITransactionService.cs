using Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITransactionService
    {
        Task<List<TransactionReadDto>> GetAllAsync(Guid userId);
        Task<TransactionReadDto> GetByIdAsync(Guid userId, Guid id);
        Task<Guid> CreateAsync(Guid userId, TransactionCreateDto dto);
        Task UpdateAsync(Guid userId, TransactionUpdateDto dto);
        Task DeleteAsync(Guid userId, Guid id);
    }

}
