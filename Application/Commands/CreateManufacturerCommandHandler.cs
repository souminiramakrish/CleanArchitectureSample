using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Commands
{
    public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateManufacturerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.Manufacturers.Add(new Manufacturer
            {
                Name = request._manufacturer.Name
            });
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
