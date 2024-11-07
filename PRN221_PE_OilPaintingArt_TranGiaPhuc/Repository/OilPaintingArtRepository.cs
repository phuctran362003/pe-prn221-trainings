using Repository.Entities;

namespace Repository
{
    public class OilPaintingArtRepository : DataAccessObject<OilPaintingArt>
    {
        public OilPaintingArtRepository(OilPaintingArt2024DbContext context) : base(context) { }


    }
}
