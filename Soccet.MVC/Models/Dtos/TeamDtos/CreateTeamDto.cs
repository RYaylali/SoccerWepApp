namespace Soccet.MVC.Models.Dtos.TeamDtos
{
    public class CreateTeamDto
    {
        public Guid TeamID { get; set; }
        public string TeamName { get; set; }
        public string? LogoUrl { get; set; }
    }
}
