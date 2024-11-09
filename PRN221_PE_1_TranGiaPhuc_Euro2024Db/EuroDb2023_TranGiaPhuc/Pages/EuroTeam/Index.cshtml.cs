using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Entities;
using Service;

namespace EuroDb2023_TranGiaPhuc.Pages.EuroTeam
{
    public class IndexModel : PageModel
    {
        private readonly TeamService _teamService;
        public IndexModel(TeamService service)
        {
            _teamService = service;
        }

        //search
        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }

        //paging
        public int PageIndex { get; set; } = 1;

        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 8;

        public IList<Team> Team { get; set; } = default!;

        public async Task OnGetAsync(int pageIndex = 1)
        {
            var result = await _teamService.GetList(searchTerm, pageIndex, PageSize);

            Team = result.EuroTeams;
            PageIndex = result.PageIndex;
            TotalPages = result.TotalPages;
        }
    }
}
