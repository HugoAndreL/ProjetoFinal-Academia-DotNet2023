using System.ComponentModel.DataAnnotations;

namespace DesafioFinal.Server.Models
{
    public class Login
    {
        public string? Email { get; set; }

        [StringLength(50, ErrorMessage = "Senha só permite 50 caractéres!")]
        public string Senha { get; set; }
    }
}
