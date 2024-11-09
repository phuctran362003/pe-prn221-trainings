using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Service;

namespace OilPaintingArt_TranGiaPhuc.Pages.OilPainting
{
    public class DetailsModel : PageModel
    {
        private readonly OilPaintingArtService _service;

        public DetailsModel(OilPaintingArtService service)
        {
            _service = service;
        }

        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            OilPaintingArt = await _service.GetArtByIdAsync(id ?? default(int));
            return Page();
        }
    }
}
