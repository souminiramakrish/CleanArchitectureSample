using Application.Common;
using Application.DTOs;
using Application.Interfaces;
using MediatR;

namespace Application.Commands
{

    public class UpdateManufacturerCommand : IRequest<CommandResponse>
    {
        public ManufacturerDTO _manufacturer { get; set; }
        public UpdateManufacturerCommand(ManufacturerDTO manufacturer)
        {
            _manufacturer = manufacturer;
        }
    }

    public class UpdateManufacturerCommandHandler : IRequestHandler<UpdateManufacturerCommand, CommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateManufacturerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CommandResponse> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse()
            {
                IsSuccess = false
            };
            if (await _unitOfWork.ManufacturerRepository.CheckManufacturerExistsByNameAsync(request._manufacturer.Name, request._manufacturer.Id))
            {
                response.Message = "Manufacturer with the same name already exists.";
                return response;
            }
            var manufacturer = await _unitOfWork.ManufacturerRepository.GetByIdAsync(request._manufacturer.Id);
            if (manufacturer == null)
            {
                response.Message = "Manufacturer not found.";
                return response;
            }
           
            manufacturer.Name = request._manufacturer.Name;
            await _unitOfWork.SaveChangesAsync();
            response.IsSuccess = true;
            response.Message = "Manufacturer updated successfully.";
            return response;
        }
    }
}
