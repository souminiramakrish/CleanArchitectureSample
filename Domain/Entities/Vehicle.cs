using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Vehicle: BaseAuditableEntity
    {
        public int VehicleId { get; set; }
        public int OwnerId { get; set; }
        public int ManufacturingYear  { get; set; }
        public Color Color { get; set; }
        public decimal ExpectedPrice {  get; set; }
    }
}
