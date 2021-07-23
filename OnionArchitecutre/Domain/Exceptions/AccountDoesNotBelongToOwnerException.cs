using System;

namespace Domain.Exceptions
{
    public sealed class AccountDoesNotBelongToOwnerException : BadRequestException
    {
        public AccountDoesNotBelongToOwnerException(Guid ownerId, Guid accountId)
            : base($"The account with the identifier {accountId} does not belong to the owner with the identifier {ownerId}")
        {
        }
    }
}
