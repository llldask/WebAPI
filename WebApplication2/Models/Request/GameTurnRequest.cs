using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models.Request
{
    public class GameTurnRequest
    {
        [Required]
        public string game_id { get; set; }

        [Required]
        public int col { get; set; }

        [Required]
        public int row { get; set; }
    }
}
