using Domain.Entities;
using Services.SqlDatabaseContextService;

namespace Application.Common.Interface
{
    public interface IRoomAmenityRepository : ISQLRepository<RoomAmenity>
    {
    }
}
