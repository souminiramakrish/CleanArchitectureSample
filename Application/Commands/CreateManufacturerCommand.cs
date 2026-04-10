using Application.DTOs;
using MediatR;

namespace Application.Commands
{
    public class CreateManufacturerCommand : IRequest<bool>
    {
        public ManufacturerDTO _manufacturer { get; set; }
        public CreateManufacturerCommand(ManufacturerDTO manufacturer)
        {
            _manufacturer = manufacturer;
        }
    }
}
