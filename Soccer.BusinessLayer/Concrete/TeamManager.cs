﻿using Soccer.BusinessLayer.Abstract;
using Soccer.DataAccessLayer.Abstract;
using Soccer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Soccer.BusinessLayer.Concrete
{
    public class TeamManager : ITeamService
    {
        private readonly ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public void TDelete(Team entity)
        {
            _teamDal.Delete(entity);
        }

        public Team TGetByID(Guid id)
        {
            return _teamDal.GetByID(id);
        }

        public List<Team> TGetList()
        {
            return _teamDal.GetList();
        }

        public void TInsert(Team entity)
        {
            _teamDal.Insert(entity);
        }

        public void TUpdate(Team entity)
        {
            _teamDal.Update(entity);
        }
    }
}
