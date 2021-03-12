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
        private IList<TeamModel> _teams;

        private HashSet<string> _allowedOrderByValues = new HashSet<string>()
        {
            "id",
            "name",
            "city"
        };

        public TeamsService()
        {
            _teams = new List<TeamModel>();

            _teams.Add(new TeamModel()
            {
                Id = 1,
                City = "Barcelona",
                DTName = "someone",
                FundationDate = new DateTime(1887, 3, 12),
                Name = "Barcelona FC"
            });
            _teams.Add(new TeamModel()
            {
                Id = 2,
                City = "Liverpool",
                DTName = "Jurgen Klóp ",
                FundationDate = new DateTime(1888, 5, 22),
                Name = "Liverpool FC"
            });
        }

        public TeamModel CreateTeam(TeamModel newTeam)
        {
            var nextId = _teams.OrderByDescending(t => t.Id).FirstOrDefault().Id + 1;
            newTeam.Id = nextId;
            _teams.Add(newTeam);
            return newTeam;
        }

        public bool DeleteTeam(long teamId)
        {
            var teamToDelete = GetTeam(teamId);
            _teams.Remove(teamToDelete);
            return true;
        }

        public TeamModel GetTeam(long teamId)
        {
            var team = _teams.FirstOrDefault(t => t.Id == teamId);
            if (team == null)
            {
                throw new NotFoundItemException($"The team with id: {teamId} does not exists.");
            }
            return team;
        }

        public IEnumerable<TeamModel> GetTeams(string orderBy = "Id")
        {
            if (!_allowedOrderByValues.Contains(orderBy.ToLower()))
                throw new InvalidOperationItemException($"The Orderby value: {orderBy} is invalid, please use one of {String.Join(',', _allowedOrderByValues.ToArray())}");

            switch (orderBy.ToLower())
            {
                case "name":
                    return _teams.OrderBy(t => t.Name);
                case "city":
                    return _teams.OrderBy(t => t.City);
                default:
                    return _teams.OrderBy(t => t.Id);
            }
        }

        public TeamModel UpdateTeam(long teamId, TeamModel updatedTeam)
        {
            updatedTeam.Id = teamId;
            var team = GetTeam(teamId);
            team.Name = updatedTeam.Name ?? team.Name;
            team.City = updatedTeam.City ?? team.City;
            team.DTName = updatedTeam.DTName ?? team.DTName;
            team.FundationDate = updatedTeam.FundationDate ?? team.FundationDate;

            return team;
        }
    }
}
