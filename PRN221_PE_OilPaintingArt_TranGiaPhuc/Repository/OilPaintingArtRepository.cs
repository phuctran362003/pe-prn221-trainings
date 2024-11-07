using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    public class OilPaintingArtRepository : DataAccessObject<OilPaintingArt>
    {
        public OilPaintingArtRepository(OilPaintingArt2024DbContext context) : base(context) { }

        public class OilPaintingArtResponse
        {
            public List<OilPaintingArt> OilPaintingArts { get; set; }
            public int TotalPages { get; set; }
            public int PageIndex { get; set; }
        }


        public async Task<OilPaintingArtResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            var query = _context.OilPaintingArts.Include(x => x.Supplier).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.OilPaintingArtStyle.ToString().Contains(searchTerm.ToLower()) || x.Artist.ToLower().Contains(searchTerm.ToLower()));
            }

            int count = await query.CountAsync(); //11
            int totalPages = (int)Math.Ceiling(count / (double)pageSize); //3

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new OilPaintingArtResponse
            {
                OilPaintingArts = await query.ToListAsync(),
                TotalPages = totalPages,
                PageIndex = pageIndex
            };
        }
        public async Task<List<OilPaintingArt>> GetList()
        {
            return await _context.OilPaintingArts.Include(x => x.Supplier).ToListAsync();
        }

        public async Task AddArt(OilPaintingArt art)
        {
            try
            {
                var exsistingTeam = await GetByIdAsync(art.OilPaintingArtId);
                if (exsistingTeam != null)
                {
                    throw new Exception("art is exsit");
                }

                _context.OilPaintingArts.Add(art);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
