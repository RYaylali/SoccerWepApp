using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer.EntityLayer.Concrete
{
    public class Team
    {
        public Guid TeamID { get; set; }
        public string TeamName { get; set; }
        public string? LogoUrl { get; set; }
        public List<Player> Players { get; set; }
    }
}
