using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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




        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            Team = team;
            var listItems = await _groupService.GetList();

            ViewData["GroupId"] = new SelectList(listItems, "GroupId", "GroupName");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _teamService.UpdateTeam(Team);
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
