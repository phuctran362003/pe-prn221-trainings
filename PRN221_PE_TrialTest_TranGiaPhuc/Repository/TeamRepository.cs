using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    public class TeamRepository : DataAccessObject<Team>
    {
        public TeamRepository()
        {

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
