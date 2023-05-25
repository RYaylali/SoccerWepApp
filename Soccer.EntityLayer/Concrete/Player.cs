using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer.EntityLayer.Concrete
{
    public class Player
    {
        public Guid PlayerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        //tABLO BAĞLATISI
        public Guid TeamID { get; set; }
        public Team Team { get; set; }
    }
}
