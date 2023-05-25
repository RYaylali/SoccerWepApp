namespace Soccet.MVC.Models.Dtos.PlayerDtos
{
    public class ResultPlayerDto
    {
        public Guid PlayerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        //tABLO BAĞLATISI
        public Guid TeamID { get; set; }

    }
}
