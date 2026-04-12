using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger _logger;
        private IDbContextTransaction _transaction;

        public IManufacturerRepository ManufacturerRepository { get; private set; }

        public UnitOfWork(
        ApplicationDBContext context,
        ILoggerFactory loggerFactory
    )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            ManufacturerRepository = new ManufacturerRepository(_context);
        }

        public void BeginTransaction()
        {
            if(_transaction is null)
              _transaction = _context.Database.BeginTransaction();
            
        }
        public void Commit()
        {
            _transaction.Commit();
        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
