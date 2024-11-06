using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Service;

namespace EuroDb2023_TranGiaPhuc.Pages.EuroTeam
{
    public class EditModel : PageModel
    {
        private readonly TeamService _teamService;
        private readonly GroupTeamService _groupService;

        public EditModel(TeamService teamService, GroupTeamService groupService)
        {
            _teamService = teamService;
            _groupService = groupService;
        }


        [BindProperty]
        public Team Team { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _teamService.GetTeamById(id ?? default(int));
            if (team == null)
            {
                return NotFound();
            }
            Team = team;

            var listItems = await _groupService.GetList();

            ViewData["GroupId"] = new SelectList(listItems, "GroupId", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(Team.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
