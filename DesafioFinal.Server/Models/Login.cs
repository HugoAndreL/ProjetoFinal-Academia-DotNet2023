using System.ComponentModel.DataAnnotations;

namespace DesafioFinal.Server.Models
{
    public class Login
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email inválido! Tente novamente.")]
        [StringLength(30, ErrorMessage = "O Email só pode conter 30 caractéres! Tente novamente.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha inválida! Tente novamente.")]
        [StringLength(15, ErrorMessage = "Senha só pode conter de 8 à 15 caractéres! Tente novamente.", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
