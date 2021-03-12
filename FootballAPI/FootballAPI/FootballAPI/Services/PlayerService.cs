using FootballAPI.Exceptions;
using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Services
{
    public class PlayerService : IPlayersService
    {
        private ICollection<PlayerModel> _players;
        private ITeamsService _teamsService;

        public PlayerService(ITeamsService teamsService)
        {
            _teamsService = teamsService;

            _players = new List<PlayerModel>();

            _players.Add(new PlayerModel() 
            {
                Id = 1,
                LastName = "Messi",
                Name = "Leo",
                Number = 10,
                Position = "front player",
                Salary = 5000000,
                TeamId = 1
            });

            _players.Add(new PlayerModel()
            {
                Id = 2,
                LastName = "Griezman",
                Name = "Antoinee",
                Number = 20,
                Position = "right front player",
                Salary = 3500000,
                TeamId = 1
            });

            _players.Add(new PlayerModel()
            {
                Id = 3,
                LastName = "Salah",
                Name = "Mohamed",
                Number = 14,
                Position = "left front player",
                Salary = 4500000,
                TeamId = 2
            });

            _players.Add(new PlayerModel()
            {
                Id = 4,
                LastName = "Mane",
                Name = "Sadio",
                Number = 10,
                Position = "right front player",
                Salary = 4000000,
                TeamId = 2
            });
        }
        
        
        public PlayerModel CreatePlayer(long teamId, PlayerModel newPlayer)
        {
            ValidateTeam(teamId);
            newPlayer.TeamId = teamId;
            var nextId = _players.OrderByDescending(p => p.Id).FirstOrDefault().Id + 1;
            newPlayer.Id = nextId;
            _players.Add(newPlayer);
            return newPlayer;
        }

        public bool DeletePlayer(long teamId, long playerId)
        {
            var playerToDelete = GetPlayer(teamId, playerId);
            _players.Remove(playerToDelete);
            return true;
        }

        public PlayerModel GetPlayer(long teamId, long playerId)
        {
            ValidateTeam(teamId);
            var player = _players.FirstOrDefault(p => p.TeamId == teamId && p.Id == playerId);
            if (player == null)
            {
                throw new NotFoundItemException($"The player with id: {playerId} does not exist in team with id:{teamId}.");
            }
            return player;
        }

        public IEnumerable<PlayerModel> GetPlayers(long teamId)
        {
            ValidateTeam(teamId);
            return _players.Where(p => p.TeamId == teamId);
        }

        public PlayerModel UpdatePlayer(long teamId, long playerId, PlayerModel updatedPlayer)
        {
            var playerToUpdate = GetPlayer(teamId, playerId);
            playerToUpdate.LastName = updatedPlayer.LastName ?? playerToUpdate.LastName;
            playerToUpdate.Name = updatedPlayer.Name ?? playerToUpdate.Name;
            playerToUpdate.Number = updatedPlayer.Number ?? playerToUpdate.Number;
            playerToUpdate.Position = updatedPlayer.Position ?? playerToUpdate.Position;
            playerToUpdate.Salary = updatedPlayer.Salary ?? playerToUpdate.Salary;
            return playerToUpdate;
        }

        private void ValidateTeam(long teamId)
        {
            _teamsService.GetTeam(teamId);
        }
    }
}
