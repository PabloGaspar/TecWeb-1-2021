using AutoMapper;
using FootballAPI.Data.Repositories;
using FootballAPI.Exceptions;
using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Services
{
    public class PlayersService : IPlayersService
    {
        private ICollection<PlayerModel> _players;
        private IFootballRepository _footballRepository;
        private IMapper _mapper;

        public PlayersService(IFootballRepository footballRepository, IMapper mapper)
        {
            _footballRepository = footballRepository;
            _mapper = mapper;
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
            var playerEntity = _footballRepository.GetPlayer(teamId, playerId);
            if (playerEntity == null)
            {
                throw new NotFoundItemException($"The player with id: {playerId} does not exist in team with id:{teamId}.");
            }
            return _mapper.Map<PlayerModel>(playerEntity);
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
            var team = _footballRepository.GetTeam(teamId);
            if (team == null)
            {
                throw new NotFoundItemException($"The team with id: {teamId} does not exists.");
            }
        }
    }
}
