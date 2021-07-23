using System;

namespace Domain.Exceptions
{
    public sealed class OwnerNotFoundException : NotFoundException
    {
        public OwnerNotFoundException(Guid ownerId)
            : base($"The owner with the identifier {ownerId} was not found.")
        {
        }
    }
}
