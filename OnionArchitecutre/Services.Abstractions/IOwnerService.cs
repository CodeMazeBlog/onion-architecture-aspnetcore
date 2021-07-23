using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contracts;

namespace Services.Abstractions
{
    public interface IOwnerService
    {
        Task<IEnumerable<OwnerDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<OwnerDto> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

        Task<OwnerDto> CreateAsync(OwnerForCreationDto ownerForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid ownerId, OwnerForUpdateDto ownerForUpdateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid ownerId, CancellationToken cancellationToken = default);
    }
}