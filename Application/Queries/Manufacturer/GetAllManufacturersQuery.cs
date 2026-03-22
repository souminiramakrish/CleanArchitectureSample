using Application.Common;
using Application.DTOs;
using MediatR;

namespace Application.Queries.Manufacturer
{
    public class GetAllManufacturersQuery : IRequest<PagedResponse<ManufacturerDTO>>
    {
        public QueryFilter Filter { get; set; }
        public GetAllManufacturersQuery(QueryFilter filter)
        {
            Filter = filter;
        }
    }
}
