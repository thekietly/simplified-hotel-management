using Domain.Entities;
using Services.SqlDatabaseContextService;
namespace Application.Common.Interface
{
    public interface IHotelImageGalleryRepository : ISQLRepository<HotelImageGallery>
    {
    }
}
