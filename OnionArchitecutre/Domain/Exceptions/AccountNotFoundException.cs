using System;

namespace Domain.Exceptions
{
    public sealed class AccountNotFoundException : NotFoundException
    {
        public AccountNotFoundException(Guid accountId)
            : base($"The account with the identifier {accountId} was not found.")    
        {
        }
    }
}
