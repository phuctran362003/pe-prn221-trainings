using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    public class TeamRepository : DataAccessObject<Team>
    {
        public TeamRepository(Euro2024DbContext context) : base(context) { }

        public class TeamResponse
        {
            public List<Team> EuroTeams { get; set; }
            public int TotalPages { get; set; }
            public int PageIndex { get; set; }
        }


        public async Task<TeamResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            var query = _context.Teams.Include(x => x.Group).AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Position.ToString().Contains(searchTerm.ToLower()) || x.Group.GroupName.ToLower().Contains(searchTerm.ToLower()));
            }

            int count = await query.CountAsync(); //11
            int totalPages = (int)Math.Ceiling(count / (double)pageSize); //3

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new TeamResponse
            {
                EuroTeams = await query.ToListAsync(),
                TotalPages = totalPages,
                PageIndex = pageIndex
            };
        }


        public async Task<List<Team>> GetList()
        {
            return await _context.Teams.Include(x => x.Group).ToListAsync();
        }

        public List<Team> Search(string position, string groupName)
        {
            var teams = _context.Teams
                .Include(t => t.Group)
                .Where(t =>
                    (t.Position.ToString().Contains(position) || string.IsNullOrEmpty(position)) &&
                    (t.Group.GroupName.Contains(groupName) || string.IsNullOrEmpty(groupName))
                )
                .ToList();

            return teams;
        }


    }
}
