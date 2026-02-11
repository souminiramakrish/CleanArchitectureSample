using MediatR;

namespace Application.Commands
{
    public class CreateManufacturerCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
