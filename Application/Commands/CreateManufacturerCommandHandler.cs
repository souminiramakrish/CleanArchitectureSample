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
        public Task<bool> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.Manufacturers.Add(new Manufacturer
            {
                Name = request.Name
            });
            _unitOfWork.SaveChangesAsync();
            return Task.FromResult(true);
        }
    }
}
