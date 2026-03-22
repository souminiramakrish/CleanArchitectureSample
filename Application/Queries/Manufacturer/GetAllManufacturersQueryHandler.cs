using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Queries.Manufacturer
{

    public class GetAllManufacturersQueryHandler : IRequestHandler<GetAllManufacturersQuery, PagedResponse<ManufacturerDTO>>
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public GetAllManufacturersQueryHandler(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public async Task<PagedResponse<ManufacturerDTO>> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken)
        {
            var pagedResponse = await _manufacturerRepository.GetAllWithPagination(request.Filter);
            return pagedResponse;
        }
    }
}
