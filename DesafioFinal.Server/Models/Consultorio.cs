using System.ComponentModel.DataAnnotations;

namespace DesafioFinal.Server.Models
{
    public class Consultorio
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Sala deve ser obrigatória")]
        public int Sala { get; set; }

        public ICollection<SenhasConsultorios>? SenhasConsultorios { get; set; }
    }
}