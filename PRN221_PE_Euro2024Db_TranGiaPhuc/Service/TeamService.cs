using Repository;
using Repository.Entities;

namespace Service
{
    public class TeamService
    {
        private readonly TeamRepository _teamRepository;

        public TeamService(Euro2024DbContext context)
        {
            _teamRepository = new TeamRepository(context);
        }

        public Task AddTeam(Team team)
        {
            return _teamRepository.AddTeam(team);
        }

        public async Task<List<Team>> GetTeams()
        {
            return await _teamRepository.GetList();
        }

        public Task<TeamRepository.TeamResponse> GetList(string searchTerm, int pageIndex, int pageSize)
        {
            return _teamRepository.GetList(searchTerm, pageIndex, pageSize);
        }

        public Task<Team> GetTeamById(int id)
        {
            return _teamRepository.GetTeamById(id);
        }

        public Task UpdateTeam(Team team)
        {
            return _teamRepository.UpdateTeam(team);
        }

        public Task DeleteTeam(int id)
        {
            return _teamRepository.DeleteTeant(id);
        }





    }
}
