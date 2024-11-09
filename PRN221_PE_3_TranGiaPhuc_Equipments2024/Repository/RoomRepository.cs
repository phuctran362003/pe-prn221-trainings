using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{

    public class RoomRepository : DataAccessObject<Room>
    {
        public RoomRepository(Equipments2024DbContext context) : base(context) { }

        public async Task<List<Room>> GetALl()
        {
            return await _context.Rooms.ToListAsync();
        }

    }
}
