using Application.Common;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, CommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateManufacturerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CommandResponse> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse()
            {
                IsSuccess = false
            };
            if ( await _unitOfWork.ManufacturerRepository.CheckManufacturerExistsByNameAsync(request._manufacturer.Name))
            {
                response.Message = "Manufacturer with the same name already exists.";
                return response;
            }

            _unitOfWork.ManufacturerRepository.Add(new Manufacturer
            {
                Name = request._manufacturer.Name
            });
            await _unitOfWork.SaveChangesAsync();
            response.IsSuccess = true;
            response.Message = "Manufacturer created successfully.";

            return response;
        }
    }
}
