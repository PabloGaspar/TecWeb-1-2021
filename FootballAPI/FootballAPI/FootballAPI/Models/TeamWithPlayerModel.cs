using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Models
{
    public class TeamWithPlayerModel : TeamModel
    {
        public IEnumerable<PlayerModel> Players { get; set; }

        public TeamWithPlayerModel(TeamModel team)
        {
            this.City = team.City;
            this.DTName = team.DTName;
            this.FundationDate = team.FundationDate;
            this.Id = team.Id;
            this.Name = team.Name;
        }
    }
}
