using System.ComponentModel.DataAnnotations;

namespace DesafioFinal.Server.Models
{
    public class Guiche
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Número deve ser obrigatório!")]
        public int Numero { get; set; }

        public ICollection<SenhasGuiches>? SenhasGuiches { get; set; }
    }
}
