using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.DB
{
    public class PlaySession
    {
        [Key]
        public string GameId { get; set; }

        public string UserField { get; set; }

        public string ServerField { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }

        public int MinesCount { get; set; }

        public bool OneMove { get; set; }
    }
}
