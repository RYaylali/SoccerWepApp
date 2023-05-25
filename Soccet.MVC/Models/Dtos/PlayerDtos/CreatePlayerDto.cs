namespace Soccet.MVC.Models.Dtos.PlayerDtos
{
    public class CreatePlayerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        //tABLO BAĞLATISI
        public Guid TeamID { get; set; }
    }
}
