using Domain.Entities;


namespace Application.Common.Interface
{
    public interface IHotelRoomRepository : IRepository<HotelRoom>
    {
        // Check if a hotel room with the same room id and hotel id already exists
        bool Exists(HotelRoom entity);
    }
}
