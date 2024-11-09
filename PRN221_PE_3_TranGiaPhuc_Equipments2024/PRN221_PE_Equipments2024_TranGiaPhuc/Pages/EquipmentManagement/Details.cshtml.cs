using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace PRN221_PE_Equipments2024_TranGiaPhuc.Pages.EquipmentManagement
{
    public class DetailsModel : PageModel
    {
        private readonly Repository.Entities.Equipments2024DbContext _context;

        public DetailsModel(Repository.Entities.Equipments2024DbContext context)
        {
            _context = context;
        }

        public Equipment Equipment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments.FirstOrDefaultAsync(m => m.EqId == id);
            if (equipment == null)
            {
                return NotFound();
            }
            else
            {
                Equipment = equipment;
            }
            return Page();
        }
    }
}
