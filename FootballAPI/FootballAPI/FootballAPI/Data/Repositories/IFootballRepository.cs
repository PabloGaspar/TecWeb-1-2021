using FootballAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Data.Repositories
{
    public interface IFootballRepository
    {

        //teams
        public IEnumerable<TeamEntity> GetTeams(string orderBy = "Id");
        public TeamEntity GetTeam(long teamId);
        public TeamEntity CreateTeam(TeamEntity newTeam);
        public void DeleteTeam(long teamId);
        public TeamEntity UpdateTeam(long teamId, TeamEntity updatedTeam);

        //players
        public IEnumerable<PlayerEntity> GetPlayers(long teamId);
        public PlayerEntity GetPlayer(long teamId, long playerId);
        public PlayerEntity CreatePlayer(long teamId, PlayerEntity newPlayer);
        public void DeletePlayer(long teamId, long playerId);
        public PlayerEntity UpdatePlayer(long teamId, long playerId, PlayerEntity updatedPlayer);
    }
}
