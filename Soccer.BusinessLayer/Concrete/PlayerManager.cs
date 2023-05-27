using Soccer.BusinessLayer.Abstract;
using Soccer.DataAccessLayer.Abstract;
using Soccer.EntityLayer.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer.BusinessLayer.Concrete
{
    public class PlayerManager :IPlayerService
    {
        private readonly IPlayerDal _playerDal;

        public PlayerManager(IPlayerDal playerDal)
        {
            _playerDal = playerDal;
        }

        public void TDelete(Player entity)
        {
            _playerDal.Delete(entity);
        }

        public Player TGetByID(Guid id)
        {
            return _playerDal.GetByID(id);
        }

        public List<Player> TGetList()
        {
            return _playerDal.GetList();
        }

        public void TInsert(Player entity)
        {
            _playerDal.Insert(entity);
        }

        public void TUpdate(Player entity)
        {
            _playerDal.Update(entity);
        }
    }
}
