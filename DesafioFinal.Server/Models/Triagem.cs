using System.ComponentModel.DataAnnotations;

namespace DesafioFinal.Server.Models
{
    public class Triagem
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Sala deve ser obrigátoria!")]
        public int Sala { get; set; }

        public virtual ICollection<SenhasTriagem>? SenhasTriagem { get; set; }
    }
}
