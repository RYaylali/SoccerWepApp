namespace Soccet.MVC.Models.Dtos.TeamDtos
{
    public class UpdateTeamDTO
    {
        public Guid TeamID { get; set; }
        public string TeamName { get; set; }
        public string? LogoUrl { get; set; }
    }
}
