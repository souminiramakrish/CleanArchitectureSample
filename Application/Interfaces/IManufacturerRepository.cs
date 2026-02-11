using Domain.Entities;

namespace Application.Interfaces
{
    public interface IManufacturerRepository : IBaseRepository<Manufacturer>
    {
        // We can add manufacturer specific methods if needed
    }
}
