using FootballAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Data.Repositories
{
    public class FootballRepository : IFootballRepository
    {
        private  List<TeamEntity> _teams;
        private  List<PlayerEntity> _players;

        public FootballRepository()
        {
            _teams = new List<TeamEntity>();

            _teams.Add(new TeamEntity()
            {
                Id = 1,
                City = "Barcelona",
                DTName = "someone",
                FundationDate = new DateTime(1887, 3, 12),
                Name = "Barcelona FC"
            });
            _teams.Add(new TeamEntity()
            {
                Id = 2,
                City = "Liverpool",
                DTName = "Jurgen Klóp ",
                FundationDate = new DateTime(1888, 5, 22),
                Name = "Liverpool FC"
            });
           

            _players = new List<PlayerEntity>();

            _players.Add(new PlayerEntity()
            {
                Id = 1,
                LastName = "Messi",
                Name = "Leo",
                Number = 10,
                Position = "front player",
                Salary = 5000000,
                TeamId = 1
            });

            _players.Add(new PlayerEntity()
            {
                Id = 2,
                LastName = "Griezman",
                Name = "Antoinee",
                Number = 20,
                Position = "right front player",
                Salary = 3500000,
                TeamId = 1
            });

            _players.Add(new PlayerEntity()
            {
                Id = 3,
                LastName = "Salah",
                Name = "Mohamed",
                Number = 14,
                Position = "left front player",
                Salary = 4500000,
                TeamId = 2
            });

            _players.Add(new PlayerEntity()
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
        
        public PlayerEntity CreatePlayer(long teamId, PlayerEntity newPlayer)
        {
            throw new NotImplementedException();
        }

        public TeamEntity CreateTeam(TeamEntity newTeam)
        {
            var nextId = _teams.OrderByDescending(t => t.Id).FirstOrDefault().Id + 1;
            newTeam.Id = nextId;
            _teams.Add(newTeam);
            return newTeam;
        }

        public void DeletePlayer(long teamId, long playerId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(long teamId)
        {
            var teamToDelete = _teams.First(t => t.Id == teamId);
            _teams.Remove(teamToDelete);
        }

        public PlayerEntity GetPlayer(long teamId, long playerId)
        {
            return _players.FirstOrDefault(p => p.TeamId == teamId && p.Id == playerId);
        }

        public IEnumerable<PlayerEntity> GetPlayers(long teamId)
        {
            throw new NotImplementedException();
        }

        public TeamEntity GetTeam(long teamId)
        {
            return _teams.FirstOrDefault(t => t.Id == teamId);
        }

        public IEnumerable<TeamEntity> GetTeams(string orderBy = "Id")
        {
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

        public PlayerEntity UpdatePlayer(long teamId, long playerId, PlayerEntity updatedPlayer)
        {
            throw new NotImplementedException();
        }

        public TeamEntity UpdateTeam(long teamId, TeamEntity updatedTeam)
        {
            updatedTeam = _teams.First(t => t.Id == teamId);
            updatedTeam.Id = teamId;
            var team = GetTeam(teamId);
            team.Name = updatedTeam.Name ?? team.Name;
            team.City = updatedTeam.City ?? team.City;
            team.DTName = updatedTeam.DTName ?? team.DTName;
            team.FundationDate = updatedTeam.FundationDate ?? team.FundationDate;
            return updatedTeam;
        }
    }
}
