using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace PRN221_PE_Equipments2024_TranGiaPhuc.Pages.EquipmentManagement
{
    public class IndexModel : PageModel
    {
        private readonly Repository.Entities.Equipments2024DbContext _context;

        public IndexModel(Repository.Entities.Equipments2024DbContext context)
        {
            _context = context;
        }

        public IList<Equipment> Equipment { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Equipment = await _context.Equipments
                .Include(e => e.Room).ToListAsync();
        }
    }
}
