using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Services
{
    public interface IPlayersService
    {
        public IEnumerable<PlayerModel> GetPlayers(long teamId);
        public PlayerModel GetPlayer(long teamId, long playerId);
        public PlayerModel CreatePlayer(long teamId, PlayerModel newPlayer);
        public bool DeletePlayer(long teamId, long playerId);
        public PlayerModel UpdatePlayer(long teamId, long playerId, PlayerModel updatedPlayer);
    }
}
