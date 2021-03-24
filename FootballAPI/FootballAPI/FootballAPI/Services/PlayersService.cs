using AutoMapper;
using FootballAPI.Data.Entities;
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
            var createdPlayer = _footballRepository.CreatePlayer(teamId, _mapper.Map<PlayerEntity>(newPlayer));
            return _mapper.Map<PlayerModel>(createdPlayer);
        }

        public bool DeletePlayer(long teamId, long playerId)
        {
            ValidateTeamAndPlater(teamId, playerId);
            _footballRepository.DeletePlayer(teamId, playerId);
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
            var players = _footballRepository.GetPlayers(teamId);
            return _mapper.Map<IEnumerable<PlayerModel>>(players);
        }

        public PlayerModel UpdatePlayer(long teamId, long playerId, PlayerModel updatedPlayer)
        {
            var playerEntity = _footballRepository.UpdatePlayer(teamId, playerId, _mapper.Map<PlayerEntity>(updatedPlayer));
            return _mapper.Map<PlayerModel>(playerEntity);
        }

        private void ValidateTeam(long teamId)
        {
            var team = _footballRepository.GetTeam(teamId);
            if (team == null)
            {
                throw new NotFoundItemException($"The team with id: {teamId} does not exists.");
            }
        }

        private void ValidateTeamAndPlater(long teamId, long playerId)
        {
            var player = GetPlayer(teamId, playerId);
        }
    }
}
