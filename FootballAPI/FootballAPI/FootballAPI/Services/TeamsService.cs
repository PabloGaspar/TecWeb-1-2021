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
    public class TeamsService : ITeamsService
    {

        private IFootballRepository _foootballRepository;
        private IMapper _mapper;

        private HashSet<string> _allowedOrderByValues = new HashSet<string>()
        {
            "id",
            "name",
            "city"
        };

        public TeamsService(IFootballRepository foootballRepository, IMapper mapper)
        {
            _foootballRepository = foootballRepository;
            _mapper = mapper;
        }

        public TeamModel CreateTeam(TeamModel newTeam)
        {
            var createdTeam = _foootballRepository.CreateTeam(_mapper.Map<TeamEntity>(newTeam));
            return _mapper.Map<TeamModel>(createdTeam);
        }

        public bool DeleteTeam(long teamId)
        {
            var teamToDelete = GetTeam(teamId);
            _foootballRepository.DeleteTeam(teamId);
            return true;
        }

        public TeamWithPlayerModel GetTeam(long teamId)
        {
            var team = _foootballRepository.GetTeam(teamId);

            if (team == null)
            {
                throw new NotFoundItemException($"The team with id: {teamId} does not exists.");
            }

            
            return _mapper.Map< TeamWithPlayerModel>(team);
        }

        public IEnumerable<TeamModel> GetTeams(string orderBy = "Id")
        {
            if (!_allowedOrderByValues.Contains(orderBy.ToLower()))
                throw new InvalidOperationItemException($"The Orderby value: {orderBy} is invalid, please use one of {String.Join(',', _allowedOrderByValues.ToArray())}");
            var entityList = _foootballRepository.GetTeams(orderBy.ToLower());
            var modelList = _mapper.Map<IEnumerable<TeamModel>>(entityList);
            return modelList;
        }

        public TeamModel UpdateTeam(long teamId, TeamModel updatedTeam)
        {
            ValidateTeam(teamId);
            updatedTeam.Id = teamId;
            var updatedTeamEntity = _foootballRepository.UpdateTeam(teamId, _mapper.Map<TeamEntity>(updatedTeam));
            return _mapper.Map<TeamModel>(updatedTeamEntity);
        }

        private void ValidateTeam(long teamId)
        {
            GetTeam(teamId);
        }
    }
}
