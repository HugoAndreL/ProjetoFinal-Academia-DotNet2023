using System.ComponentModel.DataAnnotations;

namespace DesafioFinal.Server.Models
{
    public class Senhas
    {
        [Key]
        [Required(ErrorMessage = "Senha deve ser obrigatória!")]
        public int Senha { get; set; }

        public int? HistoricoId { get; set; }
        public virtual Historico? Historico { get; set; }

        public virtual ICollection<SenhasTriagem>? SenhasTriagem { get; set; }

        public virtual ICollection<SenhasGuiches>? SenhasGuiches { get; set; }

        public virtual ICollection<SenhasConsultorios>? SenhasConsultorios { get; set; }
    }
}
