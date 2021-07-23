using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;
using Services.Abstractions;

namespace Services
{
    internal sealed class AccountService : IAccountService
    {
        private readonly IRepositoryManager _repositoryManager;

        public AccountService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<AccountDto>> GetAllByOwnerIdAsync(Guid ownerId, CancellationToken cancellationToken = default)
        {
            var accounts = await _repositoryManager.AccountRepository.GetAllByOwnerIdAsync(ownerId, cancellationToken);

            var accountsDto = accounts.Adapt<IEnumerable<AccountDto>>();

            return accountsDto;
        }

        public async Task<AccountDto> GetByIdAsync(Guid ownerId, Guid accountId, CancellationToken cancellationToken)
        {
            var owner = await _repositoryManager.OwnerRepository.GetByIdAsync(ownerId, cancellationToken);

            if (owner is null)
            {
                throw new OwnerNotFoundException(ownerId);
            }

            var account = await _repositoryManager.AccountRepository.GetByIdAsync(accountId, cancellationToken);

            if (account is null)
            {
                throw new AccountNotFoundException(accountId);
            }

            if (account.OwnerId != owner.Id)
            {
                throw new AccountDoesNotBelongToOwnerException(owner.Id, account.Id);
            }

            var accountDto = account.Adapt<AccountDto>();

            return accountDto;
        }

        public async Task<AccountDto> CreateAsync(Guid ownerId, AccountForCreationDto accountForCreationDto, CancellationToken cancellationToken = default)
        {
            var owner = await _repositoryManager.OwnerRepository.GetByIdAsync(ownerId, cancellationToken);

            if (owner is null)
            {
                throw new OwnerNotFoundException(ownerId);
            }

            var account = accountForCreationDto.Adapt<Account>();

            account.OwnerId = owner.Id;

            _repositoryManager.AccountRepository.Insert(account);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return account.Adapt<AccountDto>();
        }

        public async Task DeleteAsync(Guid ownerId, Guid accountId, CancellationToken cancellationToken = default)
        {
            var owner = await _repositoryManager.OwnerRepository.GetByIdAsync(ownerId, cancellationToken);

            if (owner is null)
            {
                throw new OwnerNotFoundException(ownerId);
            }

            var account = await _repositoryManager.AccountRepository.GetByIdAsync(accountId, cancellationToken);

            if (account is null)
            {
                throw new AccountNotFoundException(accountId);
            }

            if (account.OwnerId != owner.Id)
            {
                throw new AccountDoesNotBelongToOwnerException(owner.Id, account.Id);
            }

            _repositoryManager.AccountRepository.Remove(account);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
