using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Service;

namespace OilPaintingArt_TranGiaPhuc.Pages.OilPainting
{
    public class DeleteModel : PageModel
    {
        private readonly OilPaintingArtService _service;
        public DeleteModel(OilPaintingArtService service)
        {
            _service = service;
        }

        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oilpaintingart = await _service.GetArtByIdAsync(id ?? default(int));

            if (oilpaintingart == null)
            {
                return NotFound();
            }
            else
            {
                OilPaintingArt = oilpaintingart;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                await _service.DeletePainting(id ?? default(int));
                TempData["Message"] = "Delete Succesfull";

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Page();
            }
        }
    }
}
