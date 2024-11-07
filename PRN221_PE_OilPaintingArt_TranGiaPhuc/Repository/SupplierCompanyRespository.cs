using Repository.Entities;

namespace Repository
{
    public class SupplierCompanyRespository : DataAccessObject<SupplierCompany>
    {
        public SupplierCompanyRespository(OilPaintingArt2024DbContext context) : base(context) { }

    }
}
