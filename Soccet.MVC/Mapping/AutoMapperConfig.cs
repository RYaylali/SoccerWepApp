using AutoMapper;
using Soccer.EntityLayer.Concrete;
using Soccet.MVC.Models.Dtos.PlayerDtos;
using Soccet.MVC.Models.Dtos.TeamDtos;

namespace Soccet.MVC.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultTeamDto, Team>().ReverseMap();
            CreateMap<UpdateTeamDTO, Team>().ReverseMap();
            CreateMap<CreateTeamDto, Team>().ReverseMap();

            CreateMap<ResultPlayerDto, Player>().ReverseMap();
            CreateMap<UpdatePlayerDto, Player>().ReverseMap();
            CreateMap<CreatePlayerDto, Player>().ReverseMap();
        }
    }
}
