using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository.Entities;
using Service;

namespace EuroDb2023_TranGiaPhuc.Pages.EuroTeam
{
    public class CreateModel : PageModel
    {
        private readonly TeamService _teamService;
        private readonly GroupTeamService _groupService;

        public CreateModel(TeamService teamService, GroupTeamService groupService)
        {
            _teamService = teamService;
            _groupService = groupService;
        }

        public async Task<IActionResult> OnGet()
        {
            var listItems = await _groupService.GetList();
            ViewData["GroupId"] = new SelectList(listItems, "GroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Team Team { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _teamService.AddTeam(Team);
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
