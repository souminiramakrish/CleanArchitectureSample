using Application.Common;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IManufacturerRepository : IBaseRepository<Manufacturer>
    {
        // Manufacturer specific methods 
        Task<PagedResponse<ManufacturerDTO>> GetAllWithPagination(QueryFilter filter, CancellationToken cancellationToken = default);
        Task<bool> CheckManufacturerExistsByNameAsync(string name, int id = 0);
    }
}
