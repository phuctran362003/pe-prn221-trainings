using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    public class GroupTeamRepository : DataAccessObject<GroupTeam>
    {
        public GroupTeamRepository(Euro2024DbContext context) : base(context) { }


        public async Task<List<GroupTeam>> GetGroupTeams()
        {
            return await _context.GroupTeams.ToListAsync();
        }
    }
}
