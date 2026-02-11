namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        IManufacturerRepository Manufacturers { get; }
        void BeginTransaction();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void Commit();
        void Rollback();
    }
}
