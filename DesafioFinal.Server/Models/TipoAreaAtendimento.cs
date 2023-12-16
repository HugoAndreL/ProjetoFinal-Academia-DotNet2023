using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DesafioFinal.Server.Models
{
    public class TipoAreaAtendimento
    {
        [Key]
        [Required]
        [JsonIgnore]
        public int COD { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual ICollection<AreaAtendimento>? AreasAtendimento { get; set; }
    }
}
