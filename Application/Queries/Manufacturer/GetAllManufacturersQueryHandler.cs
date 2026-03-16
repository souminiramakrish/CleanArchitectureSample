using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Manufacturer
{
    
    public class GetAllManufacturersQueryHandler : IRequestHandler<GetAllManufacturersQuery, IEnumerable<ManufacturerDTO>>
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IMapper _mapper;


        public GetAllManufacturersQueryHandler(IManufacturerRepository manufacturerRepository, IMapper mapper)
        {
            _manufacturerRepository = manufacturerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ManufacturerDTO>> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken)
        {
            var manufacturers = await _manufacturerRepository.GetAllAsync();
            var manufacturerDTOs = _mapper.Map<IEnumerable<ManufacturerDTO>>(manufacturers);

            return manufacturerDTOs;
        }
    }
}
