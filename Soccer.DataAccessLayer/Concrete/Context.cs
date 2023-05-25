using Microsoft.EntityFrameworkCore;
using Soccer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer.DataAccessLayer.Concrete
{
    public class Context :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-491CL38\\YAYLALISERVER22;database=SoccerDB;Trusted_Connection=True;");
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
