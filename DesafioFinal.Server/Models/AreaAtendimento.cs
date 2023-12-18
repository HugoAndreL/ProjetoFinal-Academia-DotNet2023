using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    public class AreaAtendimento
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int Numero { get; set; }

        [Required]
        public string Nome { get; set; }

        public int TipoAreaAtendimentoId { get; set; }
        [JsonIgnore]
        public virtual TipoAreaAtendimento? TipoAreaAtendimento { get; set; }
    }
}
