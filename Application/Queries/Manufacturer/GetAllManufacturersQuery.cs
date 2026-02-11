using Application.DTOs;
using MediatR;

namespace Application.Queries.Manufacturer
{
    public class GetAllManufacturersQuery : IRequest<IEnumerable<ManufacturerDTO>>
    {
    }
}
