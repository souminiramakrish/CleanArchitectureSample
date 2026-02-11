using Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Manufacturer : BaseAuditableEntity
    {
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
    }
}
