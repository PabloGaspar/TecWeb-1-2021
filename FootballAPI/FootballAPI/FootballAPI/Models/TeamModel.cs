using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Models
{
    public class TeamModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime FundationDate { get; set; }
        public string City { get; set; }
        public string DTName { get; set; }
    }
}
