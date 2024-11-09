using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Entities;
using Service;

namespace OilPaintingArt_TranGiaPhuc.Pages.OilPainting
{
    public class EditModel : PageModel
    {
        private readonly OilPaintingArtService _oilPaintingArtService;
        private readonly SupplierCompanyService _supplierCompanyService;
        public EditModel(OilPaintingArtService oilPaintingArtService, SupplierCompanyService supplierCompanyService)
        {
            _oilPaintingArtService = oilPaintingArtService;
            _supplierCompanyService = supplierCompanyService;
        }


        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oilpaintingart = await _oilPaintingArtService.GetArtByIdAsync(id ?? default(int));
            if (oilpaintingart == null)
            {
                return NotFound();
            }
            OilPaintingArt = oilpaintingart;

            var list = await _supplierCompanyService.GetList();

            ViewData["SupplierId"] = new SelectList(list, "SupplierId", "CompanyName");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _oilPaintingArtService.UpdatePainting(OilPaintingArt);
                TempData["Message"] = "Update Succesfull";

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
