using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    internal sealed class OwnerRepository : IOwnerRepository
    {
        private readonly RepositoryDbContext _dbContext;

        public OwnerRepository(RepositoryDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Owner>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Owners.Include(x => x.Accounts).ToListAsync(cancellationToken);

        public async Task<Owner> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default) =>
            await _dbContext.Owners.Include(x => x.Accounts).FirstOrDefaultAsync(x => x.Id == ownerId, cancellationToken);

        public void Insert(Owner owner) => _dbContext.Owners.Add(owner);

        public void Remove(Owner owner) => _dbContext.Owners.Remove(owner);
    }
}
