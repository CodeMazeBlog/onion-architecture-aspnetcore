using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

        Task<Account> GetByIdAsync(Guid accountId, CancellationToken cancellationToken = default);

        void Insert(Account account);

        void Remove(Account account);
    }
}
