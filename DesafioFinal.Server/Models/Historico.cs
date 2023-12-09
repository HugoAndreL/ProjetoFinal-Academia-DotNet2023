using System.ComponentModel.DataAnnotations;

namespace DesafioFinal.Server.Models
{
    public class Historico
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public virtual ICollection<Senhas> SenhasHistorico { get;}
    }
}
