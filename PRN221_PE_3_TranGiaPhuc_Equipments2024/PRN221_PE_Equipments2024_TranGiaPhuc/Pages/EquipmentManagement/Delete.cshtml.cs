﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace PRN221_PE_Equipments2024_TranGiaPhuc.Pages.EquipmentManagement
{
    public class DeleteModel : PageModel
    {
        private readonly Repository.Entities.Equipments2024DbContext _context;

        public DeleteModel(Repository.Entities.Equipments2024DbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment != null)
            {
                Equipment = equipment;
                _context.Equipments.Remove(Equipment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
