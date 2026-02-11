using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class VehicleMaster : BaseAuditableEntity
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        public VehicleType VehicleType { get; set; }
        public int ManufacturerId { get; set; }
    }
}
