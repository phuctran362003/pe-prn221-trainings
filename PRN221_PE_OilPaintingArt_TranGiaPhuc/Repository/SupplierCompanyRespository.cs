using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    public class SupplierCompanyRespository : DataAccessObject<SupplierCompany>
    {
        public SupplierCompanyRespository(OilPaintingArt2024DbContext context) : base(context) { }

        public async Task<List<SupplierCompany>> GetSupplierCompanies()
        {
            return await _context.SupplierCompanies.ToListAsync();
        }

    }
}
