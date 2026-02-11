using Domain.Common;

namespace Domain.Entities
{
    public class Owner : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
    }
}
