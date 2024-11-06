using Repository;
using Repository.Entities;

namespace Service
{
    public class GroupTeamService
    {
        private readonly GroupTeamRepository _groupTeamRepository;

        public GroupTeamService(Euro2024DbContext context)
        {
            _groupTeamRepository = new GroupTeamRepository(context);
        }

        public async Task<List<GroupTeam>> GetList()
        {
            return await _groupTeamRepository.GetGroupTeams();
        }
    }
}
