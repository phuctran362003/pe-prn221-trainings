using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Service;

namespace EuroDb2023_TranGiaPhuc.Pages.EuroTeam
{
    public class DetailsModel : PageModel
    {
        private readonly TeamService _teamService;
        public DetailsModel(TeamService teamService)
        {
            _teamService = teamService;
        }

        public Team Team { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _teamService.GetTeamByIdAsync(id ?? default(int));
            if (team == null)
            {
                return NotFound();
            }
            else
            {
                Team = team;
            }
            return Page();
        }
    }
}
