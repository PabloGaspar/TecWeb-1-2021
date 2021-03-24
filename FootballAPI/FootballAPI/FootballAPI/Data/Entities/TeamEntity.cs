using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Data.Entities
{
    public class TeamEntity
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public DateTime? FundationDate { get; set; }
        public string City { get; set; }
        public string DTName { get; set; }
        public IEnumerable<PlayerEntity> Players { get; set; }
    }
}
