using System.ComponentModel.DataAnnotations;

namespace HOTELNAPOLI.Models

{
    public class Login
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Password { get; set; }
    }
}
