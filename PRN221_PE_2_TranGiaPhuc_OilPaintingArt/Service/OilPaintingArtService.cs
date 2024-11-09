using Repository;
using Repository.Entities;

namespace Service
{
    public class OilPaintingArtService
    {
        private readonly OilPaintingArtRepository _repository;
        public OilPaintingArtService(OilPaintingArt2024DbContext context)
        {
            _repository = new OilPaintingArtRepository(context);

        }

        public Task AddOilPaintingArt(OilPaintingArt art)
        {
            return _repository.AddArt(art);
        }

        public async Task<List<OilPaintingArt>> GetArts()
        {
            return await _repository.GetList();
        }

        public Task<OilPaintingArtRepository.OilPaintingArtResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            return _repository.GetList(searchTerm, pageIndex, pageSize);
        }

        public async Task<OilPaintingArt> GetArtByIdAsync(int id)
        {
            return await _repository.GetOilPaintingArtById(id);
        }

        //public Task UpdateArt(OilPaintingArt art)
        //{
        //    return _repository.UpdateArt(art);
        //}

        public Task DeletePainting(int id)
        {
            return _repository.DeleteArt(id);
        }

    }
}
