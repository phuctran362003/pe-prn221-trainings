using Repository;
using Repository.Entities;

namespace Service
{
    public class SupplierCompanyService
    {
        private readonly SupplierCompanyRespository _respository;

        public SupplierCompanyService(OilPaintingArt2024DbContext context)
        {
            _respository = new SupplierCompanyRespository(context);
        }

        public async Task<List<SupplierCompany>> GetList()
        {
            return await _respository.GetSupplierCompanies();
        }


    }
}
