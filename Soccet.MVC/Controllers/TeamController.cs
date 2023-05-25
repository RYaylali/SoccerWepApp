using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Soccer.BusinessLayer.Abstract;
using Soccer.EntityLayer.Concrete;
using Soccet.MVC.Models.Dtos.TeamDtos;

namespace Soccet.MVC.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;

        public TeamController(ITeamService teamService, IMapper mapper)
        {
            _teamService = teamService;
            _mapper = mapper;
        }
		public IActionResult Default()
		{
			return View();
		}
		public IActionResult TeamList()
        {
            var teamList = _teamService.TGetList();
            return View(teamList);
        }
        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTeam(CreateTeamDto model)
        {
            var createModel= _mapper.Map<Team>(model);
            _teamService.TInsert(createModel);
            return View();
        }
        [HttpPost]
        public IActionResult UpdateTeam(UpdateTeamDTO model)
        {
            var updateModel = _mapper.Map<Team>(model);
            _teamService.TUpdate(updateModel);
            return View();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            var values = _teamService.TGetByID(id);
            _teamService.TDelete(values);
            return View();
        }
    }
}
