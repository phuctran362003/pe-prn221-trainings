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

        public async Task AddTeam(Team team)
        {
            try
            {
                var exsistingTeam = await GetByIdAsync(team.Id);
                if (exsistingTeam != null)
                {
                    throw new Exception("Team is exsit");
                }

                _context.Teams.Add(team);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw e;
            }
        }



        public async Task<Team> GetTeamById(int id)
        {
            var team = await _context.Teams
                                     .Include(x => x.Group)
                                     .FirstOrDefaultAsync(m => m.GroupId == id);

            if (team == null)
            {
                throw new KeyNotFoundException($"Team with GroupId {id} not found.");
            }

            return team;
        }

        public async Task UpdateTeam(Team team)
        {
            try
            {
                var exsistingTeam = await GetByIdAsync(team.Id);
                if (exsistingTeam == null)
                {
                    throw new Exception("Does not exist");
                }

                exsistingTeam.TeamName = team.TeamName;
                exsistingTeam.Point = team.Point;
                exsistingTeam.Position = team.Position;

                var group = await _context.GroupTeams.FirstOrDefaultAsync(x => x.GroupId == exsistingTeam.GroupId);
                if (group == null)
                {
                    throw new Exception("Supplier does not exist");
                }
                exsistingTeam.GroupId = team.GroupId;

                _context.Teams.Update(exsistingTeam);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task DeleteTeant(int id)
        {
            try
            {
                var existArt = _context.Teams.FirstOrDefault(m => m.Id == id);
                if (existArt == null)
                {
                    throw new Exception("Art not found");
                }
                _context.Teams.Remove(existArt);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }









    }
}
