using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Entities;
using Service;

namespace OilPaintingArt_TranGiaPhuc.Pages.OilPainting
{
    public class CreateModel : PageModel
    {

        private readonly OilPaintingArtService _oilPaintingArtService;
        private readonly SupplierCompanyService _supplierCompanyService;
        public CreateModel(OilPaintingArtService oilPaintingArtService, SupplierCompanyService supplierCompanyService)
        {
            _oilPaintingArtService = oilPaintingArtService;
            _supplierCompanyService = supplierCompanyService;
        }

        public async Task<IActionResult> OnGet()
        {
            var listItems = await _supplierCompanyService.GetList();
            ViewData["SupplierId"] = new SelectList(listItems, "SupplierId", "RoomName");
            return Page();
        }



        [BindProperty]
        public OilPaintingArt OilPaintingArt { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _oilPaintingArtService.AddOilPaintingArt(OilPaintingArt);
                TempData["Message"] = "Create Succesfull";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return await OnGet();
            }
        }
    }
}
