using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Service;

namespace OilPaintingArt_TranGiaPhuc.Pages.OilPainting
{
    public class IndexModel : PageModel
    {
        private readonly OilPaintingArtService _service;
        public IndexModel(OilPaintingArtService service)
        {
            _service = service;
        }


        //search
        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }

        //paging
        public int PageIndex { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 2;

        public IList<OilPaintingArt> OilPaintingArt { get; set; } = default!;

        public async Task OnGetAsync(int pageIndex = 1)
        {
            var result = await _service.GetList(searchTerm, pageIndex, PageSize);

            OilPaintingArt = result.OilPaintingArts;
            PageIndex = result.PageIndex;
            TotalPages = result.TotalPages;
        }
    }
}
