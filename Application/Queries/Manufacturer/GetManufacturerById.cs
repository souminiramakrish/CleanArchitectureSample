using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Queries.Manufacturer
{
    public class GetManufacturerByIdQuery : IRequest<ManufacturerDTO>
    {
        public int Id { get; set; }
        public GetManufacturerByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetManufacturerByIdQueryHandler : IRequestHandler<GetManufacturerByIdQuery, ManufacturerDTO>
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;
        public GetManufacturerByIdQueryHandler(IManufacturerRepository manufacturerRepository, IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public async Task<ManufacturerDTO> Handle(GetManufacturerByIdQuery request, CancellationToken cancellationToken)
        {
            var manufacturer = await _manufacturerRepository.GetByIdAsync(request.Id);
            var manufacturerDTO = _mapper.Map<ManufacturerDTO>(manufacturer);
            return manufacturerDTO;
        }
    }
}
