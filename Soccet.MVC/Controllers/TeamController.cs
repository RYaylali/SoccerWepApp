using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
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
        [HttpGet]
        public IActionResult TeamList()
        {
            var teamList = _teamService.TGetList();
            var mapTeamList = _mapper.Map<List<ResultTeamDto>>(teamList);
            return View(mapTeamList);
        }
        [HttpGet]
        public IActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeam(CreateTeamDto model)
        {
            model.TeamID = Guid.NewGuid();
            var createModel = _mapper.Map<Team>(model);
            createModel.LogoUrl = await FillLogoPath(model.LogoFile);
            _teamService.TInsert(createModel);
            return RedirectToAction("TeamList");
        }
        [HttpGet]
        public IActionResult UpdateTeam(Guid id)
        {
            var values = _teamService.TGetByID(id);
            var updateModel = _mapper.Map<UpdateTeamDTO>(values);
            updateModel.LogoUrl=values.LogoUrl;
            return View(updateModel);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTeam(UpdateTeamDTO model)
        {

            var updateModel = _mapper.Map<Team>(model);
            if (model.LogoFile != null)
            {
                updateModel.LogoUrl = await FillLogoPath(model.LogoFile);
            }
           
            _teamService.TUpdate(updateModel);

            return RedirectToAction("TeamList");
        }
        [HttpDelete]
        public IActionResult DeleteTeam(Guid id)
        {
            var values = _teamService.TGetByID(id);
            _teamService.TDelete(values);
            return Ok(id);
        }
        public async Task<string> FillLogoPath(IFormFile formFile)
        {
            if (formFile != null)
            {
                using var image = Image.Load(formFile.OpenReadStream());
                //Dosyayı yolunu okuduk

                image.Mutate(x => x.Resize(140, 140));//Resim boyutu ayarladık

                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/img/{guid}.jpg");
                return $"/img/{guid}.jpg";
            }
            return $"/img/default.jpeg";
        }
    }
}
