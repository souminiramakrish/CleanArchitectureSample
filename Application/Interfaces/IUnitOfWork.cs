namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IManufacturerRepository ManufacturerRepository { get; }
        void BeginTransaction();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void Commit();
        void Rollback();
    }
}
