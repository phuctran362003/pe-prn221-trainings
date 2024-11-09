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

        public async Task<OilPaintingArt> GetOilPaintingArtById(int id)
        {
            return await _context.OilPaintingArts.Include(x => x.Supplier).FirstOrDefaultAsync(m => m.OilPaintingArtId == id);
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

        public async Task DeleteArt(int id)
        {
            try
            {
                var existArt = _context.OilPaintingArts.FirstOrDefault(m => m.OilPaintingArtId == id);
                if (existArt == null)
                {
                    throw new Exception("Art not found");
                }
                _context.OilPaintingArts.Remove(existArt);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public async Task Update(OilPaintingArt oilPaintingArt)
        {
            try
            {
                var existingArt = await GetOilPaintingArtById(oilPaintingArt.OilPaintingArtId);
                if (existingArt == null)
                {
                    throw new Exception("Does not exist");
                }

                existingArt.ArtTitle = oilPaintingArt.ArtTitle;
                existingArt.OilPaintingArtLocation = oilPaintingArt.OilPaintingArtLocation;
                existingArt.OilPaintingArtStyle = oilPaintingArt.OilPaintingArtStyle;
                existingArt.Artist = oilPaintingArt.Artist;
                existingArt.NotablFeatures = oilPaintingArt.NotablFeatures;
                existingArt.PriceOfOilPaintingArt = oilPaintingArt.PriceOfOilPaintingArt;
                existingArt.StoreQuantity = oilPaintingArt.StoreQuantity;
                existingArt.CreatedDate = oilPaintingArt.CreatedDate;

                var supplier = await _context.SupplierCompanies.FirstOrDefaultAsync(s => s.SupplierId == oilPaintingArt.SupplierId);
                if (supplier == null)
                {
                    throw new Exception("Supplier does not exist");
                }
                existingArt.SupplierId = oilPaintingArt.SupplierId;

                _context.OilPaintingArts.Update(existingArt);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
