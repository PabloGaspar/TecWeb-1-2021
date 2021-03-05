using FootballAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Controllers
{
    [Route("api/[controller]")]
    public class TeamsController : Controller
    {
        static private IList<TeamModel> _teams = new List<TeamModel>() 
        {new TeamModel()
            {
                Id = 1,
                City = "London",
                DTName = "ARsenal DT",
                FundationDate = new DateTime(1887, 3, 12),
                Name = "Arsenal FC"
            } ,
            new TeamModel()
            {
                Id = 2,
                City = "Liverpool",
                DTName = "Jurgen Klóp ",
                FundationDate = new DateTime(1888, 5 , 22),
                Name = "Liverpool FC"
            }
        };
        
        // api/teams
        [HttpGet]
        public IEnumerable<TeamModel> GetTeams()
        {
            return _teams;
        }

        // api/teams/2
        [HttpGet("{teamId:long}")]
        public TeamModel GetTeam(long teamId)
        {
            var team = _teams.First(t => t.Id == teamId);
            return team;
        }

        [HttpPost]
        public TeamModel CreateTeam([FromBody] TeamModel newTeam)
        {
            var nextId = _teams.OrderByDescending(t => t.Id).FirstOrDefault().Id + 1;
            newTeam.Id = nextId;

            _teams.Add(newTeam);

            return newTeam;
        }
    }
}
