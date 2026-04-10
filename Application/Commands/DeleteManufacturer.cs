using Application.Interfaces;
using MediatR;

namespace Application.Commands
{
    public class DeleteManufacturerCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public DeleteManufacturerCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteManufacturerCommandHandler : IRequestHandler<DeleteManufacturerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteManufacturerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturer = await _unitOfWork.Manufacturers.GetByIdAsync(request.Id);
            if (manufacturer == null)
            {
                return false;
            }

            _unitOfWork.Manufacturers.Delete(manufacturer);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
