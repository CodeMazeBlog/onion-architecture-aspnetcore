using System;

namespace Contracts
{
    public class AccountDto
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }

        public DateTime DateCreated { get; set; }

        public string AccountType { get; set; }
    }
}
