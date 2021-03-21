using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Services
{
    public interface ITeamsService
    {
        public IEnumerable<TeamModel> GetTeams(string orderBy = "Id");
        public TeamWithPlayerModel GetTeam(long teamId);
        public TeamModel CreateTeam(TeamModel newTeam);
        public bool DeleteTeam(long teamId);
        public TeamModel UpdateTeam(long teamId, TeamModel updatedTeam);
    }
}
