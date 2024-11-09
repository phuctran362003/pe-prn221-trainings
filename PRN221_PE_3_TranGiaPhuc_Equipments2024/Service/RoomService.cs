using Repository;
using Repository.Entities;

namespace Service
{


    public class RoomService
    {
        private readonly RoomRepository _repository;
        public RoomService(Equipments2024DbContext context)
        {
            _repository = new RoomRepository(context);

        }

        public async Task<List<Room>> GetRooms()
        {
            return await _repository.GetALl();
        }


    }

}
