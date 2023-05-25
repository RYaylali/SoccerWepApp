using Soccer.DataAccessLayer.Abstract;
using Soccer.DataAccessLayer.Concrete;
using Soccer.DataAccessLayer.Repository;
using Soccer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer.DataAccessLayer.EntityFramework
{
    public class EFTeamDal : GenericRepository<Team>, ITeamDal
    {
        public EFTeamDal(Context context) : base(context)
        {
        }
    }
}
