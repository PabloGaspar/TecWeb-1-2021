using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Data.Entities
{
    public class PlayerEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Number { get; set; }
        public string Position { get; set; }
        public float? Salary { get; set; }
        public long TeamId { get; set; }
    }
}
