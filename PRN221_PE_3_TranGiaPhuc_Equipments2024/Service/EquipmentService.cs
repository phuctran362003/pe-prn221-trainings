using Repository;
using Repository.Entities;

namespace Service
{
    public class EquipmentService
    {
        private readonly EquipmentRepository _repository;
        public EquipmentService(Equipments2024DbContext context)
        {
            _repository = new EquipmentRepository(context);

        }


        public async Task<List<Equipment>> GetEquipments()
        {
            return await _repository.GetList();
        }

        public Task<EquipmentRepository.EquipmentResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            return _repository.GetList(searchTerm, pageIndex, pageSize);
        }

        public async Task<Equipment> GetEquipmentByIdAsync(int id)
        {
            return await _repository.GetEquipmentById(id);
        }

        public Task DeleteEquipment(int id)
        {
            return _repository.Delete(id);
        }

        public Task AddEquipment(Equipment eq)
        {
            return _repository.Add(eq);
        }

    }
}
