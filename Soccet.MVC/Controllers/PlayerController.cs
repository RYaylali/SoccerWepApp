using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Soccer.BusinessLayer.Abstract;
using Soccer.EntityLayer.Concrete;
using Soccet.MVC.Models.Dtos.PlayerDtos;
using Soccet.MVC.Models.Dtos.TeamDtos;

namespace Soccet.MVC.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }

        public IActionResult TeamList()
        {
            var teamList = _playerService.TGetList();
            return View(teamList);
        }
        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePlayer(CreatePlayerDto model)
        {
            var createModel = _mapper.Map<Player>(model);
            _playerService.TInsert(createModel);
            return View();
        }
        [HttpPost]
        public IActionResult UpdatePlayer(UpdatePlayerDto model)
        {
            var updateModel = _mapper.Map<Player>(model);
            _playerService.TUpdate(updateModel);
            return View();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(int id)
        {
            var values = _playerService.TGetByID(id);
            _playerService.TDelete(values);
            return View();
        }
    }
}
