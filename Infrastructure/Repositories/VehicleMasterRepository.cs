using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class VehicleMasterRepository : BaseRepository<VehicleMaster>, IVehicleMasterRepository
    {
        public VehicleMasterRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
