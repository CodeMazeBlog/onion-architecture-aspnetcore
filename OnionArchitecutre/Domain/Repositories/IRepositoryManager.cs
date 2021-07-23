namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IOwnerRepository OwnerRepository { get; }

        IAccountRepository AccountRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
