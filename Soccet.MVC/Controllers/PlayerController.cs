using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using Soccer.BusinessLayer.Abstract;
using Soccer.EntityLayer.Concrete;
using Soccet.MVC.Models.Dtos.PlayerDtos;
using Soccet.MVC.Models.Dtos.TeamDtos;
using System.Diagnostics;

namespace Soccet.MVC.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerService playerService, IMapper mapper, ITeamService teamService)
        {
            _playerService = playerService;
            _mapper = mapper;
            _teamService = teamService;
        }

        public IActionResult PlayerList()
        {
            var playerList = _playerService.TGetList();
			var teamList = _teamService.TGetList();
			var mapPlayerList = _mapper.Map<List<ResultPlayerDto>>(playerList);
			foreach (var item in mapPlayerList)
			{
				if (item.TeamID != null)
				{
					var team = teamList.FirstOrDefault(t => t.TeamID == item.TeamID);
					if (team != null)
					{
						item.TeamName = team.TeamName;
					}
				}
			}
			return View(mapPlayerList);
        }
        [HttpGet]
        public IActionResult CreatePlayer()
        {
            var values=_teamService.TGetList();
            List<SelectListItem> teamList = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.TeamName,
                                                Value = x.TeamID.ToString()
                                            }).ToList();
            ViewBag.teamList = teamList;
            return View();
        }
        [HttpPost]
        public IActionResult CreatePlayer(CreatePlayerDto model)
        {
            model.PlayerID = Guid.NewGuid();
            var createModel = _mapper.Map<Player>(model);
            _playerService.TInsert(createModel);
            return RedirectToAction("PlayerList");
        }
        [HttpGet]
        public IActionResult UpdatePlayer(Guid id)
        {
            var values = _playerService.TGetByID(id);
            var teamvalues = _teamService.TGetList();
            List<SelectListItem> teamList = (from x in teamvalues
                                             select new SelectListItem
                                             {
                                                 Text = x.TeamName,
                                                 Value = x.TeamID.ToString()
                                             }).ToList();
            ViewBag.teamList = teamList;
            var updateModel = _mapper.Map<UpdatePlayerDto>(values);
            return View(updateModel);
        }
        [HttpPost]
        public IActionResult UpdatePlayer(UpdatePlayerDto model)
        {
            var updateModel = _mapper.Map<Player>(model);
            _playerService.TUpdate(updateModel);
            return RedirectToAction("PlayerList");
        }
        [HttpDelete]
        public IActionResult DeletePlayer(Guid id)
        {
            var values = _playerService.TGetByID(id);
            _playerService.TDelete(values);
            return Ok(id);
        }
    }
}
