using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Commands
{

    public class UpdateManufacturerCommand : IRequest<bool>
    {
        public ManufacturerDTO _manufacturer { get; set; }
        public UpdateManufacturerCommand(ManufacturerDTO manufacturer)
        {
            _manufacturer = manufacturer;
        }
    }

    public class UpdateManufacturerCommandHandler : IRequestHandler<UpdateManufacturerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateManufacturerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturer = await _unitOfWork.Manufacturers.GetByIdAsync(request._manufacturer.Id);
            if (manufacturer == null)
            {
                return false;
            }

            manufacturer.Name = request._manufacturer.Name;
            _unitOfWork.Manufacturers.Update(manufacturer);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
