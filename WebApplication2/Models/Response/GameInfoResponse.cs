using System.ComponentModel.DataAnnotations;
namespace WebApplication2.Models.Response
{
    public class GameInfoResponse
    {


        public GameInfoResponse(string Game_id, int Width, int Height, int Mines_count, List<List<string>> Field, bool Completed = false)
        {
            game_id = Game_id;
            width = Width;
            height = Height;
            mines_count = Mines_count;
            field = Field;
            Completed = completed;
        }


        [Required]
        public string game_id { get; set; }

        [Required]
        public int width { get; set; }

        [Required]
        public int height { get; set; }

        [Required]
        public int mines_count { get; set; }


        [Required]
        public List<List<string>> field { get; set; }

        public bool completed { get; set; }



    }


}
