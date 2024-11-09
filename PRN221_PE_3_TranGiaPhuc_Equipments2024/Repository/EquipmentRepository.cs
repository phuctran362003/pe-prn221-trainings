using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    public class EquipmentRepository : DataAccessObject<Equipment>
    {
        public EquipmentRepository(Equipments2024DbContext context) : base(context) { }

        public class EquipmentResponse
        {
            public List<Equipment> Equipments { get; set; }
            public int TotalPages { get; set; }
            public int PageIndex { get; set; }
        }

        public async Task<EquipmentResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            var query = _context.Equipments.Include(x => x.Room).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.EqName.ToString().Contains(searchTerm.ToLower()) || x.Quantity.ToString().Contains(searchTerm.ToLower()));
            }

            int count = await query.CountAsync(); //11
            int totalPages = (int)Math.Ceiling(count / (double)pageSize); //3

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new EquipmentResponse
            {
                Equipments = await query.ToListAsync(),
                TotalPages = totalPages,
                PageIndex = pageIndex
            };
        }
        public async Task<List<Equipment>> GetList()
        {
            return await _context.Equipments.Include(x => x.Room).ToListAsync();
        }
        public async Task<Equipment> GetEquipmentById(int id)
        {
            return await _context.Equipments.Include(x => x.Room).FirstOrDefaultAsync(m => m.EqId == id);
        }

        public async Task Delete(int id)
        {
            try
            {
                var eq = _context.Equipments.FirstOrDefault(m => m.EqId == id);
                if (eq == null)
                {
                    throw new Exception("eq not found");
                }
                _context.Equipments.Remove(eq);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Add(Equipment eq)
        {
            try
            {
                var exsistingTeam = await GetByIdAsync(eq.EqId);
                if (exsistingTeam != null)
                {
                    throw new Exception("eq is exsit");
                }

                _context.Equipments.Add(eq);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw e;
            }
        }

    }
}
