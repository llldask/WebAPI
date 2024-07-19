using System.ComponentModel.DataAnnotations;
namespace WebApplication2.Models.Request
{
    public class NewGameRequest
    {
        [Required]
        public int width { get; set; }

        [Required]
        public int height { get; set; }

        [Required]
        public int mines_count { get; set; }

        public bool CheckСonditions()
        {
            if (height > 30 || width > 30 || mines_count > height * width - 1)
                return false;
            return true;
        }
    }
}
