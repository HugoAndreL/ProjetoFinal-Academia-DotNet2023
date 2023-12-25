using System.ComponentModel.DataAnnotations;

namespace DesafioFinal.Server.Models
{
    public class Login
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
